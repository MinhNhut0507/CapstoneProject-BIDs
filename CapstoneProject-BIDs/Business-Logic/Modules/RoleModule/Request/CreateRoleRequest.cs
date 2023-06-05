using FluentValidation;
using System;

namespace Business_Logic.Modules.RoleModule.Request
{
    public class CreateRoleRequest
    {
        //public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        //public bool Status { get; set; }
    }
    public class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest>
    {
        public CreateRoleRequestValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().NotNull();
            //RuleFor(x => x.Status).NotEmpty().NotNull();
        }
    }
}
