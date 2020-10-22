import React from 'react';
import projectService from '../services/projectService';
import useGetApi from '../hooks/useGetApi';
import ProjectList from '../components/ProjectList';
import Loading from '../components/Loading';

const Projects = (props: any) => {
    const projects = useGetApi(projectService.getAll);
    if (!projects) {
        return <Loading />;
    }
    return <ProjectList projects={projects} />;
}

export default Projects;