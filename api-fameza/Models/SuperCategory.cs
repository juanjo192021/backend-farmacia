using System;
using System.Collections.Generic;

namespace api_fameza.Models;

public partial class SuperCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
