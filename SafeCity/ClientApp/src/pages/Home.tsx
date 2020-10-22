import React from 'react';
import projectService from '../services/projectService';
import useGetApi from '../hooks/useGetApi';
import IProject from '../types/IProject';
import ProjectList from '../components/ProjectList';

const Home = () => {
    const projects = useGetApi(projectService.getAll) as IProject[];

    return <>
        <section className='intro'>
            <div className='container'>
                <div className='tree'>
                    <div className='row'>
                        <div className='col-lg-6'>
                            <h2>Сохраним историческое наследие России</h2>
                            <div style={{ paddingRight: '75px' }}>
                                <p className='typograph_me'>Ежедневно в России в больших и малых городах уничтожают историческое наследие.</p>
                                <p className='typograph_me'>Этого никто не замечает, все уже привыкли, и никого не возмущает, что сносят памятники архитектуры, что в здания XIX века вставляют металлические двери и пластиковые окна, что старые фонари и ограды отправляют на переплавку. Так продолжаться больше не может. Мы открыли Фонд Внимание, чтобы эту ситуацию изменить.</p>
                            </div>

                            <div className='buttons-row'>
                                <a href='/#section-projects' className='btn btn-default'>Active projects</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section id='section-projects'>
            {projects && <ProjectList projects={projects} />}
        </section>
    </>
}

export default Home;