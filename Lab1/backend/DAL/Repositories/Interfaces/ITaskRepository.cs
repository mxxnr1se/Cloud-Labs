using DAL.Interfaces;
using Task = DAL.Entities.Task;

namespace DAL.Repositories.Interfaces;

public interface ITaskRepository : IRepository<Task>
{
}