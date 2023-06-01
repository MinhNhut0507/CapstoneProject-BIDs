using System;
using System.Collections.Generic;

namespace Data_Access.Entities;

public partial class User
{
    public Guid UserId { get; set; }

    public string AccountName { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Cccdnumber { get; set; }

    public byte[] CccdfrontImage { get; set; }

    public byte[] CccdbackImage { get; set; }

    public DateTime UpdateDate { get; set; }

    public DateTime CreateDate { get; set; }

    public string Notification { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<BanHistory> BanHistories { get; } = new List<BanHistory>();

    public virtual ICollection<BidderPrice> BidderPrices { get; } = new List<BidderPrice>();

    public virtual ICollection<Item> Items { get; } = new List<Item>();

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();
}
