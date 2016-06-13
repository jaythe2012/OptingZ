using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class CategoryMaster
    {
        public int ID { get; set; }

        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}