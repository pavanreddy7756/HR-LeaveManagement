using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagemet.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagemet.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly HRDatabaseContext context;

        public GenericRepository(HRDatabaseContext  context)
        {
            this.context=context;
        }
        public async Task CreateAsync(T entity)
        {
            context.AddAsync(entity);
           await context.SaveChangesAsync();

        }

        public async Task DeleteAsync(T entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q=>q.Id==Id);
        }

        public async Task UpdateAsync(T entity)
        {
            //context.Update(entity);
            context.Entry(entity).State=EntityState.Modified;
            await context.SaveChangesAsync();
        }


    }
}
