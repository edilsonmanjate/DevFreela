using Dapper;

using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastruture.Persistence;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        public readonly DevFreelaDbContext  _devFreelaDbContext;
        private readonly string _connectionString;

        public ProjectService(DevFreelaDbContext devFreelaDbContext, IConfiguration configuration)
        {
            _devFreelaDbContext = devFreelaDbContext;
            _connectionString = configuration.GetConnectionString("DeveFreelaCs");
        }

        //public int Create(NewProjectInputModel inputModel)
        //{
        //    var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdCliente, inputModel.IdFreelancer, inputModel.TotalCost);
        //    _devFreelaDbContext.Projects.Add(project);
        //    _devFreelaDbContext.SaveChanges();
        //    return  project.Id;
        //}

        //public void CreateComment(CreateCommentInputModel inputModel)
        //{
        //    var comment = new ProjectComment(inputModel.Content, inputModel.IdUser, inputModel.IdUser);
        //    _devFreelaDbContext.ProjectComments.Add(comment);
        //    _devFreelaDbContext.SaveChanges();

        //}

        //public void Delete(int id)
        //{
        //    var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        //    project.Cancel();
        //    _devFreelaDbContext.SaveChanges();

        //}


        public void Finish(int id)
        {
            var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Finish();
            _devFreelaDbContext.SaveChanges();

        }

        //public List<ProjectViewModel> GetAll(string query)
        //{
        //    var projects = _devFreelaDbContext.Projects;
        //    var projectsViewModel = projects
        //        .Select(p => new ProjectViewModel(p.Id,p.Title,p.CreatedAt))
        //        .ToList();

        //    return projectsViewModel;
        //}

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _devFreelaDbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == id);

            if (project == null) return null;
            var projectDetailsViewModel = new ProjectDetailsViewModel(
                        project.Id, 
                        project.Title, 
                        project.Description, 
                        project.TotalCost,
                        project.StartedAt.Value,
                        project.FinishedAt.Value,
                        project.Client.FullName,
                        project.Freelancer.FullName

                        );
            return projectDetailsViewModel;

        }

        public void Start(int id)
        {
            var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Start();

            //_devFreelaDbContext.SaveChanges();
            
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var script = "UPDATE Projects SET Status = @status WHERE Id = @id";
                sqlConnection.Execute(script, new { status = project.Status, id = project.Id });
            }

        }

        //public void Update(int id, UpdateProjectInputModel inputModel)
        //{
        //    var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);
        //    project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        //    _devFreelaDbContext.SaveChanges();
        //}
    }
}
