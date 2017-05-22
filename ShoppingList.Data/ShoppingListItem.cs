using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingList.Models
{
    public enum Priority
        {
            Low,
            Medium,
            High,
            
        };

    public class ShoppingListItem
    {
       
        [Key]
        public int shoppingItemId { get; set; }
        public int shoppingListId { get; set; }
        public string ListContent { get; set; }
        public Priority? Priority { get; set; }
        public bool IsChecked { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd)", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation Date")]
        public DateTimeOffset CreatedUtc { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd)", ApplyFormatInEditMode = true)]
        [Display(Name = "Edited Date")]
        public DateTimeOffset ModifiedUtc { get; set; }


    }
}