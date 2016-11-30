using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_RyanWall.Models
{
    public class ShoppingList
    {

        [Key]
        public int ShoppingId { get; set; }

        [Required(ErrorMessage = "Item is Requried")]
        [Display(Name = "Shopping Item")]
        [StringLength(128, ErrorMessage = "Item is limited to 32 characters")]
        public string Item { get; set; }

        [Required(ErrorMessage = "Price is Requried")]
        [Display(Name = "Item Price")]
        public float Price { get; set; }

        public Boolean IsItFrozen { get; set; }

    }
}