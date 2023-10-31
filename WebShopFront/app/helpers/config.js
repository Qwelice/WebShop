const config = {
    apiUrl: (port=7223) => {
        return 'https://localhost:' + port;
    }
}

module.exports = config;