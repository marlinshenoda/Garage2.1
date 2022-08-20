using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage2._0.Services
{
    public interface IMemberSelectService
    {
        Task<IEnumerable<SelectListItem>> GetMembersAsync();
    }
}
