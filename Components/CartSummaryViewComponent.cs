using Mike05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mike05.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        //passes on the Cart to the View method to generate the fragment of HTML that will be included in the layout
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
