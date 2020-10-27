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
                            <h2>Гарний слоган про міську інфраструктуру</h2>
                            <div style={{ paddingRight: '75px' }}>
                                <p className='typograph_me'>Щодня в Українї у великих і малих містах знищують історичну спадщину.</p>
                                <p className='typograph_me'>Цього ніхто не помічає, все вже звикли, і нікого не обурює, що зносять пам'ятники архітектури, що в будівлі XIX століття вставляють металеві двері і пластикові вікна, що старі ліхтарі та огорожі відправляють на переплавку. Так тривати не може. Ми відкрили Фонд Увага, щоб цю ситуацію змінити.</p>
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