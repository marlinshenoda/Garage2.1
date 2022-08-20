using Microsoft.AspNetCore.Mvc.Rendering;
using Garage2._0.Data;
using Microsoft.EntityFrameworkCore;

namespace Garage2._0.Services
{
    public class MemberSelectServices :IMemberSelectService
    {
        private readonly Garage2_0Context db;

        public MemberSelectServices(Garage2_0Context db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<SelectListItem>> GetMembersAsync()
        {
            return await db.Member
                        .Select(m => new SelectListItem
                        {
                            Text = m.PerNr.ToString(),
                            Value = m.Id.ToString()
                        })
                        .ToListAsync();
        }  
    
    }
}
