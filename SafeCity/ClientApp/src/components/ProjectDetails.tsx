import React from 'react';
import Carousel from 'react-bootstrap/Carousel';
import IProject from '../types/IProject';
import ProgressPanel from './ProgressPanel';
import DonationPanel from './DonationPanel';
import { ProjectStateLabel } from '../types/ProjectState';
import '../carousel.css';

const ProjectDetails = (props: { project: IProject }) => {
    const { project } = props;

    return <section className='project-section'>
        <div className='container'>
            <h1 className='projectname'>
                <span className='lbl lbl-fundraising'>{ProjectStateLabel.get(project.state)}</span>
                <span className='projectname-span'>{project.name}</span>
            </h1>
            <div>
                <img className='address-pin' src='https://developers.google.com/maps/images/maps-icon.svg' alt={project.addressName}></img>
                <a className='project-address'
                    title='Open in google maps'
                    href={`https://www.google.com/maps/@${project.lat},${project.lon},15z`}
                    target='_blank' rel="noopener noreferrer">
                    {project.addressName}
                </a>
            </div>

            <div className='row'>
                <div className='col-lg-7'>
                    <div className='opened-project-wrapper'>
                        <Carousel slide={true}>
                            {project.images.map((x, i) => <Carousel.Item key={x}>
                                <img src={x} className={`d-block w-100`} alt={x}></img>
                            </Carousel.Item>)}
                        </Carousel>
                    </div>
                    <h3>Описання</h3>
                    <div>{project.longDescription}</div>
                </div>

                <div className='col-lg-5'>
                    <ProgressPanel total={project.requiredAmount} raised={project.raised} />
                    <DonationPanel projectId={project.id} projectName={project.name} />
                </div>
            </div>
        </div>
    </section>
}

export default ProjectDetails;