export default (baseUrl, requestedResource, options, headers) => {
    return fetch(
        `${baseUrl}/${requestedResource}`,
        Object.assign({
            headers: new Headers(Object.assign({
            }, headers)),
        }, options),  
    );
};
