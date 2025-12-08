// js-api-loader.js: Loads Google Maps JS API asynchronously and exposes googleMaps helpers

import { Loader } from "https://unpkg.com/@googlemaps/js-api-loader@1.16.7/dist/index.min.js";

window.googleMapsLoader = {
    loader: null,
    map: null,
    markers: [],
    load: function (options, callback) {
        if (!this.loader) {
            this.loader = new Loader(options);
        }
        this.loader.load().then(() => {
            if (callback) callback();
        });
    },
    initMap: function (elementId, mapOptions) {
        if (!window.google || !window.google.maps) {
            console.error("Google Maps API not loaded.");
            return;
        }
        this.map = new google.maps.Map(document.getElementById(elementId), mapOptions);
    },
    addMarker: function (lat, lng, title) {
        if (!this.map) {
            console.error("Map not initialized.");
            return;
        }
        var marker = new google.maps.Marker({
            position: { lat: lat, lng: lng },
            map: this.map,
            title: title || ""
        });
        this.markers.push(marker);
        return marker;
    },
    panToMarker: function (index) {
        if (!this.map) {
            console.error("Map not initialized.");
            return;
        }
        var marker = this.markers[index];
        if (!marker) {
            console.error("Marker not found at index", index);
            return;
        }
        this.map.panTo(marker.getPosition());
        try {
            if (this.map.getZoom && this.map.getZoom() < 14) this.map.setZoom(14);
        } catch (e) { }
    },
    clearMarkers: function () {
        this.markers.forEach(function (marker) {
            marker.setMap(null);
        });
        this.markers = [];
    },
    setCenter: function (lat, lng) {
        if (this.map) {
            this.map.setCenter({ lat: lat, lng: lng });
        }
    }
};

// Example usage from Blazor:
// await JS.InvokeVoidAsync('googleMapsLoader.load', { apiKey: '...', version: 'weekly', libraries: ['places'], mapIds: ['...'] }, () => { ... });
// await JS.InvokeVoidAsync('googleMapsLoader.initMap', 'mapElementId', { center: { lat: ..., lng: ... }, zoom: 12 });
// await JS.InvokeVoidAsync('googleMapsLoader.addMarker', lat, lng, 'Title');
// await JS.InvokeVoidAsync('googleMapsLoader.panToMarker', index);
// await JS.InvokeVoidAsync('googleMapsLoader.clearMarkers');
// await JS.InvokeVoidAsync('googleMapsLoader.setCenter', lat, lng);
