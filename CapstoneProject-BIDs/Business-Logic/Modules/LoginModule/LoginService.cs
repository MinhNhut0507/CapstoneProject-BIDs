using Azure.Messaging;
using Business_Logic.Modules.LoginModule.InterFace;
using Business_Logic.Modules.LoginModule.Request;
using Business_Logic.Modules.RoleModule.Interface;
using Business_Logic.Modules.StaffModule.Interface;
using Business_Logic.Modules.UserModule.Interface;
using Data_Access.Constant;
using Data_Access.Entities;
using FluentValidation.Results;

namespace Business_Logic.Modules.LoginModule
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IStaffRepository _StaffRepository;
        private readonly IRoleRepository _RoleRepository;
        public LoginService(IUserRepository UserRepository, IStaffRepository StaffRepository, IRoleRepository RoleRepository)
        {
            _UserRepository = UserRepository;
            _StaffRepository = StaffRepository;
            _RoleRepository = RoleRepository;
        }
        public async Task<string> Login(LoginRequest loginRequest)
        {
            ValidationResult result = new LoginRequestValidator().Validate(loginRequest);
            if (!result.IsValid)
            {
                throw new Exception(ErrorMessage.CommonError.INVALID_REQUEST);
            }

            User UserCheckLogin =  _UserRepository.GetFirstOrDefaultAsync(x => x.AccountName == loginRequest.AccountName
            && x.Password == loginRequest.Password).Result;

            Staff StaffCheckLogin = _StaffRepository.GetFirstOrDefaultAsync(x => x.AccountName == loginRequest.AccountName
            && x.Password == loginRequest.Password).Result;

            if(UserCheckLogin == null && StaffCheckLogin == null)
            {
                throw new Exception(ErrorMessage.LoginError.WRONG_ACCOUNT_NAME_OR_PASSWORD);
            }

            if(UserCheckLogin != null)
            {
                return "Login successfull with user";
            }
            else
            {
                Role getRole =  _RoleRepository.GetFirstOrDefaultAsync(x => x.RoleId == StaffCheckLogin.RoleId).Result;
                return "Login successfull with role " + getRole.RoleName;
            }
        }
    }
}
