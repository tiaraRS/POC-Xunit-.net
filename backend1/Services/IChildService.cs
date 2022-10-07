using backend1.Models;

namespace backend1.Services
{
    public interface IChildService
    {
        public Task<IEnumerable<ChildModel>> GetChildrenAsync();
        public Task<ChildModel> CreateChildAsync(ChildModel child);
    }
}
