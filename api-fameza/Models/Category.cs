using System;
using System.Collections.Generic;

namespace api_fameza.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? SuperCategoryId { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();

    public virtual SuperCategory? SuperCategory { get; set; }
}
