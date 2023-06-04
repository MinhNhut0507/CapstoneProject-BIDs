using Business_Logic.Modules.StaffModule.Request;
using Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Modules.StaffModule.Interface
{
    public interface IStaffService
    {
        public Task<Guid?> AddNewStaff(CreateStaffRequest StaffCreate);

        public Task UpdateStaff(UpdateStaffRequest StaffUpdate);

        public Task DeleteStaff(Guid? StaffDeleteID);

        public Task<ICollection<Staff>> GetAll();

        public Task<Staff> GetStaffByID(Guid? id);

        public Task<Staff> GetStaffByName(string Name);

        public Task AcceptCreateAccount(Guid? CreateAccountID);

        public Task BanUser(Guid? BanUserID);

        public Task UnbanUser(Guid? UnbanUserID);
    }
}
