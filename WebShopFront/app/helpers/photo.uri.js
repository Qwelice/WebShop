function getUri(photoData){
    return `data:image/jpeg;base64,${photoData}`;
}

module.exports = getUri;