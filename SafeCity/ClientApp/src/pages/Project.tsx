import React from 'react';
import ProjectDetails from '../components/ProjectDetails';
import projectService from '../services/projectService';
import Loading from '../components/Loading';
import useGetApi from '../hooks/useGetApi';

const Project = (props: any) => {
    const project = useGetApi(projectService.getById, props.match.params.id);

    if (!project) {
        return <Loading />;
    }

    return <ProjectDetails project={project} />
}

export default Project;