using Microsoft.AspNetCore.Mvc;
using ProjetFinalTrans2.Data;
using ProjetFinalTrans2.Data.Cart;
using ProjetFinalTrans2.Data.Services;
using ProjetFinalTrans2.Data.ViewModels;
using ProjetFinalTrans2.Models;

namespace ProjetFinalTrans2.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly AppDbContext _context;
        private readonly IOrdersService _ordersService;

        public OrdersController(ShoppingCart shoppingCart, AppDbContext context, IOrdersService ordersService)
        {
            _shoppingCart = shoppingCart;
            _context = context;
            _ordersService = ordersService;
        }

        // Affiche le panier
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        // Ajouter au panier
        public IActionResult AddItemToShoppingCart(int id)
        {
            var produit = _context.Realisations.FirstOrDefault(n => n.Id == id);

            if (produit != null)
            {
                _shoppingCart.AddItemToCart(produit);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        // Retirer du panier
        public IActionResult RemoveItemFromShoppingCart(int id)
        {
            var produit = _context.Realisations.FirstOrDefault(n => n.Id == id);

            if (produit != null)
            {
                _shoppingCart.RemoveItemFromCart(produit);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        // Vider le panier
        public async Task<IActionResult> ClearShoppingCart()
        {
            await _shoppingCart.ClearShoppingCartAsync();
            return RedirectToAction(nameof(ShoppingCart));
        }

        // Commander : enregistrer la commande dans la base
        public async Task<IActionResult> Commander()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (items.Count == 0)
            {
                TempData["Message"] = "Votre panier est vide !";
                return RedirectToAction("ShoppingCart");
            }

            // Fake UserId et Email pour le moment (car pas encore d'authentification)
            string userId = "test_user_id";
            string userEmailAddress = "client@example.com";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);

            await _shoppingCart.ClearShoppingCartAsync();
            TempData["Message"] = "Commande enregistrée avec succès !";

            return View("OrderCompleted");
        }
    }
}
