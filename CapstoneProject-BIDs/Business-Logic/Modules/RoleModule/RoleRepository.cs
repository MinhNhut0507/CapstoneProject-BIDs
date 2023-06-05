using Business_Logic.Modules.RoleModule.Interface;
using Common.Utils.Repository;
using Data_Access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Modules.RoleModule
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly BidsContext _db;

        public RoleRepository(BidsContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ICollection<Role>> GetRolesBy(
            Expression<Func<Role, bool>> filter = null,
            Func<IQueryable<Role>, ICollection<Role>> options = null,
            string includeProperties = null
        )
        {
            IQueryable<Role> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return options != null ? options(query).ToList() : await query.ToListAsync();
        }
    }
}
