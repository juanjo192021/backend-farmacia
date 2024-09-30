using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api_fameza.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? Status { get; set; }

    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
