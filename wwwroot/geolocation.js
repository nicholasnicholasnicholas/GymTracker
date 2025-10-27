// Indicate the JS file loaded (useful for debugging in the browser console)
console.log("geolocation.js loaded");

// Expose a global function so it can be called from Blazor via IJSRuntime
window.getUserLocation = function () {
    return new Promise((resolve, reject) => {
        if (!navigator.geolocation) {
            reject("Geolocation not supported.");
        } else {
            navigator.geolocation.getCurrentPosition(
                (pos) => {
                    console.log("Got position:", pos.coords.latitude, pos.coords.longitude);
                    // Return property names that map nicely to the .NET Geolocation class
                    resolve({
                        Latitude: pos.coords.latitude,
                        Longitude: pos.coords.longitude
                    });
                },
                (err) => reject(err?.message ?? err)
            );
        }
    });
};

// Small helper to let Blazor check whether the function is present
window.isGetUserLocationAvailable = function () {
    return typeof window.getUserLocation === 'function';
};
