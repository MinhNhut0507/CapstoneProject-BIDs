using FluentValidation;
using System;

namespace Business_Logic.Modules.RoleModule.Request
{
    public class UpdateRoleRequest
    {
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public bool Status { get; set; }
    }
    public class UpdateRoleRequestValidator : AbstractValidator<UpdateRoleRequest>
    {
        public UpdateRoleRequestValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty().NotNull();
            RuleFor(x => x.RoleName).NotEmpty().NotNull();
            RuleFor(x => x.Status).NotEmpty().NotNull();
        }
    }
}
