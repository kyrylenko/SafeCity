import { get } from './crud';

const baseUrl = '/api/v1/auth';

async function getMe(): Promise<any> {
    return await get(`${baseUrl}`);
};

export default {
    getMe: getMe,
}