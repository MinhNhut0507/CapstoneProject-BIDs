using System;
using System.Collections.Generic;

namespace Data_Access.Entities;

public partial class Staff
{
    public Guid StaffId { get; set; }

    public Guid RoleId { get; set; }

    public string AccountName { get; set; }

    public string StaffName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public DateTime DateOfBirth { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public string Notification { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Item> Items { get; } = new List<Item>();

    public virtual Role Role { get; set; }
}
