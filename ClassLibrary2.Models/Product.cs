using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Models
{
 public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description{ get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1,10000)]
        public double ListPrise{ get; set; }
        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1,10000)]
        public double Price{ get; set; }
          [Required]
        [Display(Name = "Price for 51-100")]
        [Range(1,10000)]
        public double Prise50{ get; set; }
        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1,10000)]
        public double Price100{ get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public category Category{ get; set; }
        [Required]
        [Display(Name ="CoverType")]
        public int  CoverTypeId { get; set; }
        [ValidateNever]
        public CoverType CoverType { get; set; }


    }
}
