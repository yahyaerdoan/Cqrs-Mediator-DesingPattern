using CqrsDesing.WebUserInterface.CQRS.Handlers.Product.Read;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDesing.WebUserInterface.Controllers.Product
{
    public class PoductController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;

        public PoductController(GetProductQueryHandler getProductQueryHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
        }

        public IActionResult ProductList()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }
    }
}
