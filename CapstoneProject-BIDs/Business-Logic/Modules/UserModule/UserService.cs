using Business_Logic.Modules.UserModule.Interface;
using Business_Logic.Modules.UserModule.Request;
using Data_Access.Constant;
using Data_Access.Entities;
using FluentValidation.Results;

namespace Business_Logic.Modules.UserModule
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _UserRepository.GetAll(options: o => o.OrderByDescending(x => x.UpdateDate).ToList());
        }

        public Task<ICollection<User>> GetUsersIsNotBan()
        {
            return _UserRepository.GetUsersBy(x => x.Status == true, options: o => o.OrderByDescending(x => x.UpdateDate).ToList());
        }

        public async Task<User> GetUserByID(Guid? id)
        {
            if (id == null)
            {
                throw new Exception(ErrorMessage.CommonError.ID_IS_NULL);
            }
            var user = await _UserRepository.GetFirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                throw new Exception(ErrorMessage.UserError.USER_NOT_FOUND);
            }
            return user;
        }

        public async Task<User> GetUserByName(String userName)
        {
            if (userName == null)
            {
                throw new Exception(ErrorMessage.CommonError.NAME_IS_NULL);
            }
            var user = await _UserRepository.GetFirstOrDefaultAsync(x => x.UserName == userName);
            if (user == null)
            {
                throw new Exception(ErrorMessage.UserError.USER_NOT_FOUND);
            }
            return user;
        }

        public async Task<Guid?> AddNewUser(CreateUserRequest userRequest)
        {

            ValidationResult result = new CreateUserRequestValidator().Validate(userRequest);
            if (!result.IsValid)
            {
                throw new Exception(ErrorMessage.CommonError.INVALID_REQUEST);
            }

            User userCheckAccountName = _UserRepository.GetFirstOrDefaultAsync(x => x.AccountName == userRequest.AccountName).Result;
            if (userCheckAccountName != null)
            {
                throw new Exception(ErrorMessage.CommonError.ACCOUNT_NAME_IS_EXITED);
            }
            User userCheckEmail = _UserRepository.GetFirstOrDefaultAsync(x => x.Email == userRequest.Email).Result;
            if (userCheckEmail != null)
            {
                throw new Exception(ErrorMessage.CommonError.EMAIL_IS_EXITED);
            }
            User userCheckPhone = _UserRepository.GetFirstOrDefaultAsync(x => x.Phone == userRequest.Phone).Result;
            if (userCheckPhone != null)
            {
                throw new Exception(ErrorMessage.CommonError.PHONE_IS_EXITED);
            }
            User userCheckCCCDNumber = _UserRepository.GetFirstOrDefaultAsync(x => x.Cccdnumber == userRequest.Cccdnumber).Result;
            if (userCheckCCCDNumber != null)
            {
                throw new Exception(ErrorMessage.CommonError.CCCD_NUMBER_IS_EXITED);
            }

            if (!userRequest.Email.Contains("@"))
            {
                throw new Exception(ErrorMessage.CommonError.WRONG_EMAIL_FORMAT);
            }
            if ((!userRequest.Phone.StartsWith("09") 
                && !userRequest.Phone.StartsWith("08")
                && !userRequest.Phone.StartsWith("07")
                && !userRequest.Phone.StartsWith("05")
                && !userRequest.Phone.StartsWith("03"))
                || userRequest.Phone.Length != 10)
            {
                throw new Exception(ErrorMessage.CommonError.WRONG_PHONE_FORMAT);
            }
            if (userRequest.Cccdnumber.Length != 12
                || !userRequest.Cccdnumber.StartsWith("0"))
            {
                throw new Exception(ErrorMessage.CommonError.WRONG_CCCD_NUMBER_FORMAT);
            }

            var newUser = new User();

            newUser.UserId = Guid.NewGuid();
            newUser.AccountName = userRequest.AccountName;
            newUser.UserName = userRequest.UserName;
            newUser.Email = userRequest.Email;
            newUser.Password = userRequest.Password;
            newUser.Address = userRequest.Address;
            newUser.Phone = userRequest.Phone;
            newUser.DateOfBirth = userRequest.DateOfBirth;
            newUser.Cccdnumber = userRequest.Cccdnumber;
            newUser.CccdfrontImage = userRequest.CccdfrontImage;
            newUser.CccdbackImage = userRequest.CccdbackImage;
            newUser.CreateDate = DateTime.Now;
            newUser.UpdateDate = DateTime.Now;
            //newUser.Notification = null;            
            newUser.Status = false;

            await _UserRepository.AddAsync(newUser);
            return newUser.UserId;
        }

        public async Task UpdateUser(UpdateUserRequest userRequest)
        {
            try
            {
                var userUpdate = GetUserByID(userRequest.UserId).Result;

                if (userUpdate == null)
                {
                    throw new Exception(ErrorMessage.UserError.USER_NOT_FOUND);
                }

                ValidationResult result = new UpdateUserRequestValidator().Validate(userRequest);
                if (!result.IsValid)
                {
                    throw new Exception(ErrorMessage.CommonError.INVALID_REQUEST);
                }

                User userCheckEmail = _UserRepository.GetFirstOrDefaultAsync(x => x.Email == userRequest.Email).Result;
                if (userCheckEmail != null)
                {
                    throw new Exception(ErrorMessage.CommonError.EMAIL_IS_EXITED);
                }
                User userCheckPhone = _UserRepository.GetFirstOrDefaultAsync(x => x.Phone == userRequest.Phone).Result;
                if (userCheckPhone != null)
                {
                    throw new Exception(ErrorMessage.CommonError.PHONE_IS_EXITED);
                }

                if (!userRequest.Email.Contains("@"))
                {
                    throw new Exception(ErrorMessage.CommonError.WRONG_EMAIL_FORMAT);
                }
                if ((!userRequest.Phone.StartsWith("09")
                    && !userRequest.Phone.StartsWith("08")
                    && !userRequest.Phone.StartsWith("07")
                    && !userRequest.Phone.StartsWith("05")
                    && !userRequest.Phone.StartsWith("03"))
                    || userRequest.Phone.Length != 10)
                {
                    throw new Exception(ErrorMessage.CommonError.WRONG_PHONE_FORMAT);
                }

                userUpdate.UserName = userRequest.UserName;
                userUpdate.Password = userRequest.Password;
                userUpdate.Email = userRequest.Email;
                userUpdate.Address = userRequest.Address;
                userUpdate.Phone = userRequest.Phone;
                userUpdate.Notification = userRequest.Notification;
                //userUpdate.Status = userRequest.Status;
                userUpdate.UpdateDate = DateTime.Now;

                await _UserRepository.UpdateAsync(userUpdate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at update type: " + ex.Message);
                throw new Exception(ex.Message);
            }

        }

        public async Task DeleteUser(Guid? userDeleteID)
        {
            try
            {
                if (userDeleteID == null)
                {
                    throw new Exception(ErrorMessage.CommonError.ID_IS_NULL);
                }

                User userDelete = _UserRepository.GetFirstOrDefaultAsync(x => x.UserId == userDeleteID && x.Status == true).Result;

                if (userDelete == null)
                {
                    throw new Exception(ErrorMessage.UserError.USER_NOT_FOUND);
                }

                userDelete.Status = false;
                await _UserRepository.UpdateAsync(userDelete);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at delete type: " + ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
