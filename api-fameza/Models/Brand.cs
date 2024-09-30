using System;
using System.Collections.Generic;

namespace api_fameza.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
