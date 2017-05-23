using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingList.Models
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        public int shoppingItemId { get; set; }

        public string Bodu { get; set; }
       
        [Display(Name = "Creation Date")]
        public DateTimeOffset CreatedUtc { get; set; }
       
        [Display(Name = "Edited Date")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}