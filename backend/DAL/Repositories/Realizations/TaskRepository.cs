using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = DAL.Entities.Task;

namespace DAL.Repositories.Realizations;

public class TaskRepository : GenericRepositoryWithIncludes<Task>, ITaskRepository
{
    public TaskRepository(DbContext context) : base(context)
    {
    }

    protected override IQueryable<Task> DbSetWithAllProperties()
    {
        return DbSet
               .Include(t => t.Project)
               .Include(t => t.User);
    }
}