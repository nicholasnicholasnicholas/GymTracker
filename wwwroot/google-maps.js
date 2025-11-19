(function () {
  // Keep map state in closure
  let map = null;
  let markers = [];
  let userMarker = null;
  let infoWindow = null;
  // queue of pending marker requests when map isn't ready yet
  let pendingMarkerRequests = [];
  let isMapReady = false;
  let _ensureReadyResolve = null;
  let ensureReadyPromise = new Promise((res) => { _ensureReadyResolve = res; });

  console.debug('google-maps.js loaded, _GOOGLE_MAP_ID=', window._GOOGLE_MAP_ID);

  async function initMap(elementId, lat, lng, zoom = 14) {
    const el = document.getElementById(elementId);
    if (!el) {
      console.error('initMap: element not found', elementId);
      return;
    }
    // Wait for google.maps and google.maps.Map to be available
    let attempts = 0;
    while (!(window.google && window.google.maps && typeof window.google.maps.Map === 'function')) {
      if (attempts++ > 50) {
        console.error('initMap: google.maps.Map constructor not available after waiting');
        return;
      }
      await new Promise(r => setTimeout(r, 100));
    }
    const center = { lat: lat, lng: lng };
    const mapOptions = {
      center,
      zoom,
      streetViewControl: false,
      mapTypeControl: false,
    };

    // Use configured Map ID when provided (required for some Advanced Marker features)
    try {
      if (window._GOOGLE_MAP_ID) {
        mapOptions.mapId = window._GOOGLE_MAP_ID;
      }
    } catch (e) {
      // ignore if window isn't accessible
    }

    map = new google.maps.Map(el, mapOptions);

    if (!mapOptions.mapId) {
      console.warn('Map initialized without a Map ID. Advanced Marker features may be limited.');
    }
    infoWindow = new google.maps.InfoWindow();
    // mark ready and resolve any waiters
    isMapReady = true;
    try { if (_ensureReadyResolve) _ensureReadyResolve(true); } catch (e) {}

    // Drain any pending marker requests queued while the map wasn't ready
    if (pendingMarkerRequests.length) {
      console.debug('Draining', pendingMarkerRequests.length, 'pending marker request(s)');
      const copy = pendingMarkerRequests.slice();
      pendingMarkerRequests = [];
      // update pending count for debugging
      try { window.googleMaps && (window.googleMaps._pendingCount = pendingMarkerRequests.length); } catch (e) {}
      copy.forEach(req => {
        try {
          addMarkers(req);
        } catch (e) {
          console.error('Error while processing queued addMarkers request', e, req);
        }
      });
    }
  }

  function clearMarkers() {
    markers.forEach(m => m.setMap(null));
    markers = [];
  }

  function addMarkers(gyms) {
    // Immediate entry log to help debug missing JS-side logs
    try {
      console.debug('googleMaps.addMarkers invoked - type=', typeof gyms, 'isArray=', Array.isArray(gyms), 'length=', gyms && gyms.length);
    } catch (e) {
      // swallow logging errors
    }

    if (!map) {
      // queue the request and return early; it will be drained once initMap runs
      try { console.warn('addMarkers: map not initialized - queueing request'); } catch (e) {}
      pendingMarkerRequests.push(gyms);
      // expose pending count for debugging
      try { window.googleMaps && (window.googleMaps._pendingCount = pendingMarkerRequests.length); } catch (e) {}
      return;
    }

    try {

    // Blazor interop can sometimes pass collections as plain objects; normalize to an array
    if (!Array.isArray(gyms)) {
      console.debug('googleMaps.addMarkers: gyms is not an array, attempting to coerce. typeof=', typeof gyms, 'value=', gyms);
      try {
        if (gyms && typeof gyms === 'object') {
          gyms = Object.values(gyms);
        } else {
          gyms = [];
        }
      } catch (e) {
        console.error('Failed to coerce gyms to array', e, gyms);
        gyms = [];
      }
    }

      console.debug('googleMaps.addMarkers called, gyms length=', (gyms || []).length);
      clearMarkers();
    const bounds = new google.maps.LatLngBounds();
    gyms.forEach((g, idx) => {
      const rawLat = g.latitude ?? g.Latitude ?? 0;
      const rawLng = g.longitude ?? g.Longitude ?? 0;
      let pos = { lat: rawLat, lng: rawLng };
      console.debug('adding marker pos=', pos, 'name=', g.name ?? g.Name);

      // If multiple gyms have identical coordinates, apply a tiny deterministic offset so markers don't perfectly overlap
      const duplicateCount = markers.filter(m => {
        const p = m.getPosition ? m.getPosition() : (m.position || null);
        if (!p) return false;
        // p may be a LatLng literal or a LatLng object
        const plat = (typeof p.lat === 'function') ? p.lat() : p.lat;
        const plng = (typeof p.lng === 'function') ? p.lng() : p.lng;
        return Math.abs(plat - rawLat) < 1e-7 && Math.abs(plng - rawLng) < 1e-7;
      }).length;
      if (duplicateCount > 0) {
        const offset = 0.00002 * duplicateCount; // ~2 meters per duplicate
        pos = { lat: rawLat + offset, lng: rawLng + offset };
        console.debug('offset duplicate marker to', pos);
      }
      let marker;
      // Use AdvancedMarkerElement with a pin SVG icon and number label for gym markers
      const pinSvg = `
        <svg xmlns='http://www.w3.org/2000/svg' width='32' height='32' viewBox='0 0 32 32' fill='none'>
          <circle cx='16' cy='16' r='10' fill='#4285F4' stroke='white' stroke-width='3'/>
          <rect x='14' y='22' width='4' height='8' rx='2' fill='#4285F4'/>
          <text x='16' y='20' text-anchor='middle' font-size='13' font-family='Arial' fill='white' font-weight='bold'>${idx + 1}</text>
        </svg>
      `;
      const contentEl = document.createElement('div');
      contentEl.innerHTML = pinSvg;
      contentEl.style.width = '32px';
      contentEl.style.height = '32px';
      contentEl.title = g.name ?? g.Name;

      marker = new google.maps.marker.AdvancedMarkerElement({
        map,
        position: pos,
        title: g.name ?? g.Name,
        content: contentEl
      });
        // Attach extra info for info window
        marker._info = {
          address: g.address ?? g.Address ?? "",
          rating: g.rating ?? g.Rating ?? "",
          hours: g.hours ?? g.Hours ?? ""
        };
      marker.addListener('click', () => {
        const content = `<div style=\"min-width:180px\"><strong>${escapeHtml(g.name ?? g.Name)}</strong><br/>${escapeHtml(g.address ?? g.Address ?? '')}</div>`;
        infoWindow.setContent(content);
        infoWindow.open({ anchor: null, map, shouldFocus: false });
        infoWindow.setPosition(pos);
      });
      markers.push(marker);
      bounds.extend(pos);
    });
    try {
      if (!bounds.isEmpty()) {
        map.fitBounds(bounds);
      }
    } catch (e) {
      // fitBounds may throw if bounds invalid
      console.warn('fitBounds failed', e);
    }
    return;
    } catch (outerErr) {
      console.error('Unhandled exception in googleMaps.addMarkers', outerErr, gyms);
      // surface for debugging
      window.__lastGoogleMapsAddMarkersError = outerErr && outerErr.toString ? outerErr.toString() : outerErr;
    }
  }

  function addUserMarker(lat, lng) {
    if (!map) return;

    // Ensure high accuracy for GPS coordinates
    navigator.geolocation.getCurrentPosition(
        (position) => {
            console.debug('Raw GPS Data:', position);
            const pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            if (userMarker) userMarker.setMap(null);

            const canUseAdvanced = (google.maps && google.maps.marker && typeof google.maps.marker.AdvancedMarkerElement === 'function') && (map && map.mapId || window._GOOGLE_MAP_ID);
            if (canUseAdvanced) {
                const el = document.createElement('div');
                el.className = 'gm-user-marker';
                el.innerHTML = `
                    <div class="pulse-dot" style="background:#4285F4;border-radius:50%;width:12px;height:12px;"></div>
                `;
                userMarker = new google.maps.marker.AdvancedMarkerElement({
                    position: pos,
                    map,
                    title: 'You are here',
                    content: el
                });
                map.panTo(pos);
            } else {
                const svg = {
                    path: 'M12 2C8.13 2 5 5.13 5 9c0 5.25 7 13 7 13s7-7.75 7-13c0-3.87-3.13-7-7-7z',
                    fillColor: '#4285F4',
                    fillOpacity: 1,
                    strokeWeight: 0,
                    scale: 1.2,
                    anchor: new google.maps.Point(12, 22)
                };
                userMarker = new google.maps.Marker({
                    position: pos,
                    map,
                    icon: svg,
                    title: 'You are here',
                    zIndex: 999
                });
                map.panTo(pos);
            }
        },
        (error) => {
            console.error('Error retrieving GPS location:', error);
        },
        { enableHighAccuracy: true }
    );
  }

  function escapeHtml(unsafe) {
    if (!unsafe) return '';
    return String(unsafe)
      .replace(/&/g, '&amp;')
      .replace(/</g, '&lt;')
      .replace(/>/g, '&gt;')
      .replace(/"/g, '&quot;');
  }

  function panToMarker(index) {
    if (!map || !markers[index]) return;
    const marker = markers[index];
    const pos = marker.position || (marker.getPosition && marker.getPosition());
    if (pos) {
      map.panTo(pos);
      map.setZoom(17); // Zoom in for clarity
      if (infoWindow) {
        let name = marker.title || "";
        let address = marker._info?.address || "";
        let rating = marker._info?.rating ? `Rating: ${marker._info.rating}` : "";
        let hours = marker._info?.hours;
        let photoUrl = marker._info?.photoUrl;
        let directionsUrl = address ? `https://www.google.com/maps/dir/?api=1&destination=${encodeURIComponent(address)}` : null;
        let content = `<div class=\"card shadow-sm border-0\" style=\"min-width:240px;\">
          <div class=\"card-body p-3\">
            ${photoUrl ? `<img src=\"${photoUrl}\" alt=\"Photo of ${escapeHtml(name)}\" class=\"img-fluid rounded mb-2\" style=\"max-height:140px;object-fit:cover;\">` : ""}
            <h6 class=\"card-title mb-1\">${escapeHtml(name)}</h6>
            <div class=\"card-subtitle mb-2 text-muted\">${escapeHtml(address)}</div>
            ${rating ? `<div class=\"mb-1\"><span class=\"badge bg-primary\">${escapeHtml(rating)}</span></div>` : ""}
            <div>${hours && hours.trim() ? escapeHtml(hours) : '<span class=\"text-muted\">Hours not available</span>'}</div>
            ${directionsUrl ? `<div class=\"mt-2\"><a href=\"${directionsUrl}\" target=\"_blank\" rel=\"noopener\" class=\"btn btn-sm btn-success\">Get Directions</a></div>` : ""}
          </div>
        </div>`;
        infoWindow.setContent(content);
        infoWindow.open({ anchor: null, map, shouldFocus: false });
        infoWindow.setPosition(pos);
      }
    }
  }

  window.googleMaps = {
    initMap,
    addMarkers,
    clearMarkers,
    addUserMarker,
    panToMarker
  };
  // expose some diagnostic helpers
  try {
    window.googleMaps._isMapReady = function () { return isMapReady; };
    window.googleMaps._pendingCount = pendingMarkerRequests.length;
    window.googleMaps.ensureReady = function () { return isMapReady ? Promise.resolve(true) : ensureReadyPromise; };
  } catch (e) { /* ignore */ }
})();
