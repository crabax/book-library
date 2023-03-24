const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/api/Books",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7234',
        secure: false,
    });

    app.use(appProxy);
};
