using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetFinalTrans2.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Realisation Produit { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
