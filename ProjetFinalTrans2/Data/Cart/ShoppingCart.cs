using Microsoft.EntityFrameworkCore;
using ProjetFinalTrans2.Models;

namespace ProjetFinalTrans2.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }
        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        // Récupère tous les articles du panier
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Include(n => n.Produit)
                .ToList());
        }

        // Total du panier
        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Select(n => (double)(n.Produit.Prix * n.Amount))
                .Sum();

            return total;
        }

        // Ajouter un article au panier
        public void AddItemToCart(Realisation produit)
        {
            var shoppingCartItem = _context.ShoppingCartItems
                .FirstOrDefault(n => n.Produit.Id == produit.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Produit = produit,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        // Retirer un article du panier
        public void RemoveItemFromCart(Realisation produit)
        {
            var shoppingCartItem = _context.ShoppingCartItems
                .FirstOrDefault(n => n.Produit.Id == produit.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
                _context.SaveChanges();
            }
        }

        // Nettoyer le panier
        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .ToListAsync();

            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

        // Gestion session pour identifier chaque panier
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
    }
}
