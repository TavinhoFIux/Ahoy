using Domain.Repositorys;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public Repository(ApplicationDbContext context, ILogger<Repository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all instances of {EntityType}", typeof(T).Name);
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all instances of {EntityType}", typeof(T).Name);
                throw;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching {EntityType} by id: {Id}", typeof(T).Name, id);
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    _logger.LogWarning("{EntityType} with id {Id} not found", typeof(T).Name, id);
                }
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching {EntityType} by id: {Id}", typeof(T).Name, id);
                throw;
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("{EntityType} added", typeof(T).Name);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding {EntityType}", typeof(T).Name);
                throw;
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _logger.LogInformation("{EntityType} updated", typeof(T).Name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating {EntityType}", typeof(T).Name);
                throw;
            }
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("{EntityType} deleted", typeof(T).Name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting {EntityType}", typeof(T).Name);
                throw;
            }
        }
    }
}
