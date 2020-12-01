
import { observable, configure } from 'mobx';

configure({enforceActions: 'observed'});

const authStore = observable({
    user: null,

    setUser(u?: any) {
        this.user = u
    },
});

export default authStore;