using System;
using System.Collections.Generic;

namespace DemoVar9.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronimyc { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role RoleNavigation { get; set; } = null!;
}
