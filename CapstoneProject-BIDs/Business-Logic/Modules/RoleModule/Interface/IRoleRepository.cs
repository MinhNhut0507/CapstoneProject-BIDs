using Common.Utils.Repository.Interface;
using Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Modules.RoleModule.Interface
{
    public interface IRoleRepository : IRepository<Role>
    {
        public Task<ICollection<Role>> GetRolesBy(
               Expression<Func<Role, bool>> filter = null,
               Func<IQueryable<Role>, ICollection<Role>> options = null,
               string includeProperties = null
           );
    }
}
