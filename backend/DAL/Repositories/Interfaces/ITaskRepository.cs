using DAL.Interfaces;
using Task = Entities.Task;

namespace DAL.Repositories.Interfaces;

public interface ITaskRepository : IRepository<Task>
{
}