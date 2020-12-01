import auth from './auth';

enum Method {
    GET = 'GET',
    POST = 'POST',
    PUT = 'PUT',
    DELETE = 'DELETE',
}

export async function get(url: string) {
    const options = getOptions(Method.GET);
    
    return new Promise((resolve, reject) => {
        fetch(url, options)
            .then(res => {
                if (!res.ok) {
                    reject({
                        response: res,
                        message: `Something went wrong during GET: ${res.statusText}`
                    });
                }
                return res.json();
            })
            .then(res => resolve(res))
            .catch(error => reject(error));
    });
};

export async function post(url:string, entity:any) {
    return await action(url, Method.POST, entity);
};

export async function put(url:string, entity:any) {
    return await action(url, Method.PUT, entity);
};

export async function del(url:string) {
    const options = getOptions(Method.DELETE);

    return new Promise((resolve, reject) => {
        fetch(url, options)
            .then(res => {
                if (!res.ok) {
                    throw new Error(`Something went wrong during deletion: ${res.statusText}`)
                }
                resolve();
            })
            .catch(error => reject(error));
    });
};

function getOptions(method:Method, entity:any|undefined = undefined): RequestInit{
    const idToken = auth.getToken();

    const options = {
        method,
    } as RequestInit;

    if(idToken){
        options.headers = {
            'Authorization': `Bearer ${idToken}`,
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        };
    }
    if(entity){
        options.body = JSON.stringify(entity);
    }

    return options;
};

async function action(url:string, method:Method, entity:any) {
    const options = getOptions(method, entity);

    return new Promise((resolve, reject) => {
        fetch(url, options)
            .then(parseJSON)
            .then((response:any) => {
                if (response.ok) {
                    return resolve(response.json);
                }
                console.log('crud:response.json ', response.json)
                // extract the error from the server's json
                return reject(response.json);
            })
            .catch((error) => reject({
                networkError: error.message,
            }));
    });
};
/**
 * Parses the JSON returned by a network request
 *
 * @param  {object} response A response from a network request
 *
 * @return {object}          The parsed JSON, status from the response
 */
function parseJSON(response:any) {
    return new Promise((resolve) => response.json()
        .then((json:any) => resolve({
            status: response.status,
            ok: response.ok,
            json,
        })));
}

