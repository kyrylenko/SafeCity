enum ProjectState {
    suggested = 0,
    fundRaising = 1,
    inProgress = 2,
    completed = 3,
    rejected = 4
}

export const ProjectStateLabel = new Map<number, string>([
    [ProjectState.suggested, 'Suggested'],
    [ProjectState.fundRaising, 'Fundraising'],
    [ProjectState.inProgress, 'In progress'],
    [ProjectState.completed, 'Completed'],
    [ProjectState.rejected, 'Rejected']
  ]);

export default ProjectState;