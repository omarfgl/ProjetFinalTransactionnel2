using System.ComponentModel.DataAnnotations;

namespace ProjetFinalTrans2.Models
{
    public class Realisation
    {
        public int Id { get; set; }

        [Required]
        public string Titre { get; set; }

        public string Description { get; set; }

        public string Categorie { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "Prix (€)")]
        public decimal Prix { get; set; }
    }
}
