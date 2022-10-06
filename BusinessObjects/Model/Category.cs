﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Model
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}