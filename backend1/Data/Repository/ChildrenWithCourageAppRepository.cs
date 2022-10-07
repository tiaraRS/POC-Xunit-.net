using backend1.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend1.Data.Repository
{
    public class ChildrenWithCourageAppRepository: IChildrenWithCourageAppRepository
    {
        private ChildrenWithCourageDBContext _dbContext;
        public ChildrenWithCourageAppRepository(ChildrenWithCourageDBContext childrenDBContext)
        {
            _dbContext = childrenDBContext;
        }
        public virtual void CreateChild(ChildEntity child)
        {

            _dbContext.Children.Add(child);
        }
        public virtual async Task<IEnumerable<ChildEntity>> GetChildrenAsync()
        {
            IQueryable<ChildEntity> query = _dbContext.Children;
            query = query.AsNoTracking();
            query = query.OrderBy(d => d.Id);

            var result = await query.ToListAsync(); //aqui va recien a bd

            return result;
        }
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
