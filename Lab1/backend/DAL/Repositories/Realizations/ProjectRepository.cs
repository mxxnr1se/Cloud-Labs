using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Realizations;

public class ProjectRepository : GenericRepositoryWithIncludes<Project>, IProjectRepository
{
    public ProjectRepository(DbContext context) : base(context)
    {
    }

    protected override IQueryable<Project> DbSetWithAllProperties()
    {
        return DbSet
               .Include(p => p.Tasks)
               .Include(p => p.Users);
    }
}