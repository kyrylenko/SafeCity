import ProjectState from './ProjectState';

export default interface IProject {
    id: number;
    name: string;
    shortDescription: string;
    longDescription: string;
    lat: number;
    lon: number;
    addressName: string;
    logo: string;
    images: [string];
    state: ProjectState;
    requiredAmount: number;
    raised: number;
}