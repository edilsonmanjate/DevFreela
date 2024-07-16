using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastruture.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        public readonly DevFreelaDbContext  _devFreelaDbContext;

        public ProjectService(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext = devFreelaDbContext;
        }

        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdCliente, inputModel.IdFreelancer, inputModel.TotalCost);
            _devFreelaDbContext.Projects.Add(project);
            return  project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdUser, inputModel.IdUser);
            _devFreelaDbContext.ProjectComments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Cancel();
        }


        public void Finish(int id)
        {
            var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Finish();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _devFreelaDbContext.Projects;
            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Id,p.Title,p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
            if (project == null) return null;
            var projectDetailsViewModel = new ProjectDetailsViewModel(
                        project.Id, 
                        project.Title, 
                        project.Description, 
                        project.TotalCost,
                        project.StartedAt.Value,
                        project.FinishedAt.Value

                        );
            return projectDetailsViewModel;

        }

        public void Start(int id)
        {
            var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Start();
        }

        public void Update(int id, UpdateProjectInputModel inputModel)
        {
            var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);
            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
            
        }
    }
}
