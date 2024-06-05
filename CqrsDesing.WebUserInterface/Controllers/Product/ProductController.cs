using CqrsDesing.WebUserInterface.CQRS.Commands.Product;
using CqrsDesing.WebUserInterface.CQRS.Handlers.Product.Read;
using CqrsDesing.WebUserInterface.CQRS.Handlers.Product.Write;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDesing.WebUserInterface.Controllers.Product
{
    public class ProductController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly DeleteProductCommandHandler _deleteProductCommandHandler;


        public ProductController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, DeleteProductCommandHandler deleteProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
        }

        public IActionResult ProductList()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CreateProduct(CreatePoductCommand createPoductCommand)
        {
            _createProductCommandHandler.Handle(createPoductCommand);
            return RedirectToAction("ProductList");
        }

        public IActionResult DeleteProduct(int id)
        {
            _deleteProductCommandHandler.Handle(new DeleteProductCommand(id));
            return RedirectToAction("ProductList");
        }
    }
}
