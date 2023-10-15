using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.UoWs;

public sealed class EfUoW : IUoW
{
    private readonly DbContext _context;

    private bool _disposed;

    public EfUoW(DbContext context, IProjectRepository projectRepository, ITaskRepository taskRepository,
                 UserManager<User> userManager)
    {
        _context = context;
        UserManager = userManager;
        Tasks = taskRepository;
        Projects = projectRepository;
    }

    public UserManager<User> UserManager { get; }
    public ITaskRepository Tasks { get; }
    public IProjectRepository Projects { get; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}