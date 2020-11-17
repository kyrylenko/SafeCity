const CLIENT_ID = '674253053711-5kesmhgnisu9hukdgf7l6v8k9scs85s8.apps.googleusercontent.com';

declare global {
    interface Window {
        gapi: any;
    }
}

function loadScript(callback: any) {
    const script = document.createElement('script');

    script.src = `https://apis.google.com/js/api.js`;
    script.async = true;

    document.head.appendChild(script);
    script.onload = callback
};

function getToken() {
    return window.gapi ? window.gapi.auth2.getAuthInstance().currentUser.get().getAuthResponse().id_token : undefined;
};

function signIn() {
    window.gapi.auth2.getAuthInstance().signIn()
        .then(() => console.log('signed in'));
};

function signOut() {
    window.gapi.auth2.getAuthInstance().signOut()
        .then(() => console.log('User signed out.'));
};

export default {
    load: (updateSigninStatus: Function) => loadScript(() => {
        window.gapi.load('auth2', () => {
            window.gapi.auth2.init({
                clientId: CLIENT_ID,
            }).then(() => {
                window.gapi.auth2.getAuthInstance().isSignedIn.listen(updateSigninStatus);
                updateSigninStatus(window.gapi.auth2.getAuthInstance().isSignedIn.get());
            }, (error: any) => {
                console.log('failed to initialize google API client ', error);
            });
        });
    }),
    getToken: getToken,
    signIn:signIn,
    signOut:signOut,
}