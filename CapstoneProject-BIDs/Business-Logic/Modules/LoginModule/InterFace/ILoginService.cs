using Business_Logic.Modules.LoginModule.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Modules.LoginModule.InterFace
{
    public interface ILoginService
    {
        public Task<string> Login(LoginRequest loginRequest);
    }
}
