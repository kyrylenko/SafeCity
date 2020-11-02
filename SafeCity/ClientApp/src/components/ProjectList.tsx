import React, { useState } from 'react';
import IProject from '../types/IProject';
import ProjectState, { ProjectStateLabel } from '../types/ProjectState';
import { Link } from 'react-router-dom';

const getStateClass = (state: ProjectState): string => {
    const dic = new Map<number, string>([
        [ProjectState.fundRaising, 'lbl-fundraising'],
        [ProjectState.inProgress, 'lbl-recovering'],
        [ProjectState.completed, 'lbl-completed']
    ]);
    return dic.get(state) || '';
};

const ProjectItem = (props: IProject) => {
    return <div className='row object-item'>
        <div className='col-lg-7'>
            <Link to={`/projects/${props.id}`}>
                <div className='object-image crop-width'>
                    <div className={`lbl ${getStateClass(props.state)}`}>{ProjectStateLabel.get(props.state)}</div>
                    <img src={props.logo} alt={props.name}></img>
                </div>
            </Link>
        </div>
        <div className='col-lg-5'>
            <div className='object-description'>
                <h3>
                    <Link to={`/projects/${props.id}`}>{props.name}</Link>
                </h3>
                <div className='sub-text'>{props.addressName}</div>
                <p className='typograph_me'>{props.shortDescription}</p>
                <p>
                    <Link to={`/projects/${props.id}`} className='btn btn-default'>Detailed</Link>
                </p>
            </div>
        </div>
    </div>
};

const ProjectList = (props: { projects: IProject[] }) => {
    const { projects } = props;

    const [activeState, setActiveState] = useState<ProjectState | null>(ProjectState.fundRaising);

    const handleFilter = (state: ProjectState | null) => (event: any) => {
        setActiveState(state);
    };

    return <div className='container'>
        <div className='pull-left'>
            <h2 className='uppercase'>Активні проекти</h2>
        </div>
        <div className='tabs-switcher'>
            <div onClick={handleFilter(null)} className={`lbl lbl-all ${activeState === null && 'active'}`}>Всі</div>
            <div onClick={handleFilter(ProjectState.fundRaising)} className={`lbl lbl-fundraising ${activeState === ProjectState.fundRaising && 'active'}`}>
                {ProjectStateLabel.get(ProjectState.fundRaising)}
            </div>
            <div onClick={handleFilter(ProjectState.inProgress)} className={`lbl lbl-recovering ${activeState === ProjectState.inProgress && 'active'}`}>
                {ProjectStateLabel.get(ProjectState.inProgress)}
            </div>
            <div onClick={handleFilter(ProjectState.completed)} className={`lbl lbl-completed ${activeState === ProjectState.completed && 'active'}`}>
                {ProjectStateLabel.get(ProjectState.completed)}
            </div>
        </div>
        {projects && <div className='objects'>
            {(activeState ? projects.filter(x => x.state === activeState) : projects)
                .map(x => <ProjectItem key={x.id} {...x} />)}
        </div>}
    </div>
}

export default ProjectList;