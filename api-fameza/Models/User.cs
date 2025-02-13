﻿using System;
using System.Collections.Generic;

namespace api_fameza.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateOnly? DateBirth { get; set; }

    public string? CellPhone { get; set; }

    public int? RoleId { get; set; }

    public bool? Status { get; set; }

    public virtual Role? Role { get; set; }
}
