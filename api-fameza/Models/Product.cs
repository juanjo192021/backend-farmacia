using System;
using System.Collections.Generic;

namespace api_fameza.Models;

public partial class Product
{
    public int Id { get; set; }

    public int? Sku { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public int? Stock { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? BrandId { get; set; }

    public int? SubCategoryId { get; set; }

    public bool? Status { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual SubCategory? SubCategory { get; set; }
}
