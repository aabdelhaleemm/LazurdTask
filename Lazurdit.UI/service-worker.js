importScripts('https://storage.googleapis.com/workbox-cdn/releases/6.2.4/workbox-sw.js');

if (workbox) {
    console.log('Workbox is loaded');

    // Cache the HTML page and assets
    workbox.routing.registerRoute(
        ({ request }) => request.destination === 'document',
        new workbox.strategies.NetworkFirst()
    );

    // Cache other assets like CSS, JS, images, etc.
    workbox.routing.registerRoute(
        ({ request }) => request.destination === 'script' ||
            request.destination === 'style' ||
            request.destination === 'image',
        new workbox.strategies.StaleWhileRevalidate()
    );
} else {
    console.log('Workbox failed to load');
}