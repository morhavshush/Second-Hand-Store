using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class ProductModel
    {        
        public long Id { get; set; }

        [ForeignKey("OwnerID")]
        public virtual UserModel Owner { get; set; }
        [ForeignKey("UserID")]
        public virtual UserModel User { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Short Description is required.")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Long Description is required.")]
        public string LongDescription { get; set; }

        [Required]
        public DateTime DateUpload { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal Price { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public State StateProduct { get; set; }
        public DateTime? TimeInCart { get; set; }

        [NotMapped]
        public IFormFile Img1 { get; set; }
        [NotMapped]
        public IFormFile Img2 { get; set; }
        [NotMapped]
        public IFormFile Img3 { get; set; }
    }
    public enum State
    {
        Available,
        InShoppingCart,
        Buy
    }
}
