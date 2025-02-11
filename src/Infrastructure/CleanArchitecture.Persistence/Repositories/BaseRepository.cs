using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    // Injeção de Dependência
    protected readonly ApplicationDbContext Context;

    public BaseRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public void Create(T entity)
    {
        try
        {
            entity.DateCreated = DateTime.Now;
            Context.Add(entity);
        }
        catch
        {
            throw;
        }
    }

    public void Update(T entity)
    {
        try
        {
            entity.DateUpdated = DateTime.Now;
            Context.Update(entity);
        }
        catch
        {
            throw;
        }
    }
    
    public void Delete(T entity)
    {
        try
        {
            entity.DateDeleted = DateTime.Now;
            Context.Remove(entity);
        }
        catch
        {
            throw;
        }
    }

    public async Task<T?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    public async Task<List<T>?> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Context.Set<T>().ToListAsync(cancellationToken);
    }
}
