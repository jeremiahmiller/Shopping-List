using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingList.Models
{
    public class ListShopping
    {
        [Key]
        public int shoppingListId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [Display(Name = "Shopping List")]
        public string ListName { get; set; }
        public string Color { get; set; }
<<<<<<< HEAD
       
        [Display(Name = "Creation Date")]
        public DateTimeOffset CreatedUtc { get; set; }
       
=======
        
        [Display(Name = "Creation Date")]
        public DateTimeOffset CreatedUtc { get; set; }
        
>>>>>>> b213295eddc5b8350c472b9c0f7722e64cfc7a79
        [Display(Name = "Edited Date")]
        public DateTimeOffset? ModifiedUtc { get; set; }


    }
}