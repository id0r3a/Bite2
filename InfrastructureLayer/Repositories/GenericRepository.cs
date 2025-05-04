using ApplicationLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace InfrastructureLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly Bite2DbContext _context;

        public GenericRepository(Bite2DbContext context)
        {
            _context = context;
        }

        // Hämtar alla poster
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        // Hämtar en specifik post med ID
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        // Lägger till en ny post
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        // Uppdaterar en post
        public Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.CompletedTask;
        }
        //Ta bort en post
        public Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        // Returnerar en IQueryable för avancerade queries
        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }

        // Sparar ändringar
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // 🆕 Extra: Hämtar första matchande post baserat på en expression
        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
        }
    }
}
