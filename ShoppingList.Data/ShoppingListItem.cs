using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DefaultValue(false)]
        public bool IsChecked { get; set; }

        [Display(Name = "Creation Date")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Edited Date")]
        public DateTimeOffset? ModifiedUtc { get; set; }


    }
}