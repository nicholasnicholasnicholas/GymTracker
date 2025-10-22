// Minimal Leaflet helper for Blazor
(function () {
    window.geolocationMap = {
        initMap: function (elementId, centerLat, centerLng, zoom) {
            if (!window.L) {
                console.error('Leaflet not loaded');
                return null;
            }

            const el = document.getElementById(elementId);
            if (!el) return null;

            // Destroy existing map if any
            if (el._leaflet_map) {
                try { el._leaflet_map.remove(); } catch (e) { }
            }

            const map = L.map(elementId).setView([centerLat, centerLng], zoom || 13);

            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                maxZoom: 19,
                attribution: '© OpenStreetMap contributors'
            }).addTo(map);

            el._leaflet_map = map;
            return true;
        },

        addMarkers: function (elementId, markers) {
            const el = document.getElementById(elementId);
            if (!el || !el._leaflet_map) return null;
            const map = el._leaflet_map;

            // Clear existing markers layer
            if (el._markers_layer) {
                try { map.removeLayer(el._markers_layer); } catch (e) { }
            }

            const layer = L.featureGroup();
            markers.forEach(m => {
                const marker = L.marker([m.latitude, m.longitude]).bindPopup(`<b>${m.name}</b><br/>${m.address}`);
                layer.addLayer(marker);
            });

            layer.addTo(map);
            el._markers_layer = layer;

            // Fit bounds to markers if any
            if (markers.length) {
                map.fitBounds(layer.getBounds().pad(0.2));
            }

            return true;
        }
        ,

        addUserMarker: function (elementId, lat, lng, options) {
            const el = document.getElementById(elementId);
            if (!el || !el._leaflet_map) return null;
            const map = el._leaflet_map;

            // Remove existing user marker
            if (el._user_marker) {
                try { map.removeLayer(el._user_marker); } catch (e) { }
            }

            // Use a divIcon with pulsing dot for user location (styled via app.css)
            // Add color overrides via inline styles if provided
            const dotStyle = (options && options.color) ? `style="background:${options.color};"` : '';
            const ringStyle = (options && options.ringColor) ? `style="background:${options.ringColor};"` : '';
            const html = `<div class="user-pulse-icon"><div class="pulse-ring" ${ringStyle}></div><div class="pulse-dot" ${dotStyle}></div></div>`;
            const icon = L.divIcon({ html: html, className: '', iconSize: [24, 24], iconAnchor: [12, 12] });
            const marker = L.marker([lat, lng], { icon: icon }).bindPopup(options && options.popup ? options.popup : 'You are here');

            marker.addTo(map);
            el._user_marker = marker;

            // Optionally pan/zoom to user
            try {
                if (options && options.zoom) {
                    // Smoothly fly to the user's location when zooming
                    map.flyTo([lat, lng], options.zoom, { animate: true, duration: 0.75 });
                } else if (options && options.pan) {
                    map.panTo([lat, lng]);
                }

                // Add bounce CSS to the icon container for one animation cycle
                try {
                    const iconEl = el._user_marker.getElement();
                    if (iconEl) {
                        const pulseEl = iconEl.querySelector('.user-pulse-icon');
                        if (pulseEl) {
                            pulseEl.classList.add('bounce');
                            setTimeout(() => pulseEl.classList.remove('bounce'), 700);
                        }
                    }
                } catch (e) { /* ignore */ }
            }
            catch (e) { /* ignore */ }

            return true;
        }
    };
})();
