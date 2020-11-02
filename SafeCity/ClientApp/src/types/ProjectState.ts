enum ProjectState {
    suggested = 0,
    fundRaising = 1,
    inProgress = 2,
    completed = 3,
    rejected = 4
}

export const ProjectStateLabel = new Map<number, string>([
    [ProjectState.suggested, 'Suggested'],
    [ProjectState.fundRaising, 'Збір коштів'],
    [ProjectState.inProgress, 'В процесі'],
    [ProjectState.completed, 'Завершені'],
    [ProjectState.rejected, 'Відхилені']
  ]);

export default ProjectState;