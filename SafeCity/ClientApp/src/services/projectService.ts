import { get } from './crud';

const baseUrl = '/api/v1/projects';

async function getAll(): Promise<any> {
    return await get(`${baseUrl}`);
};

async function getById(id: number): Promise<any> {
    return await get(`${baseUrl}/${id}`);
};

export default {
    getAll: getAll,
    getById: getById,
}