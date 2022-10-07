using backend1.Data.Entity;

namespace backend1.Data.Repository
{
    public interface IChildrenWithCourageAppRepository
    {
        Task<bool> SaveChangesAsync();
        public void CreateChild(ChildEntity child);
        public Task<IEnumerable<ChildEntity>> GetChildrenAsync();
        
    }
}
