using System;
using System.Collections.Generic;

namespace Data_Access.Entities;

public partial class Role
{
    public Guid RoleId { get; set; }

    public string RoleName { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Staff> Staff { get; } = new List<Staff>();
}
