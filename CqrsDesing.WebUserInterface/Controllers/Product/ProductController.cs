using CqrsDesing.WebUserInterface.CQRS.Commands.Product;
using CqrsDesing.WebUserInterface.CQRS.Handlers.Product.Read;
using CqrsDesing.WebUserInterface.CQRS.Handlers.Product.Write;
using CqrsDesing.WebUserInterface.CQRS.Queries.Product;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDesing.WebUserInterface.Controllers.Product
{
    public class ProductController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly DeleteProductCommandHandler _deleteProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;


        public ProductController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, DeleteProductCommandHandler deleteProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
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

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            GetProductByIdQuery getProductByIdQuery = new GetProductByIdQuery(id);

            var values = _getProductByIdQueryHandler.Handle(getProductByIdQuery);

            return View(new UpdateProductCommand()
            {
                ProductId = values.ProductId,
                Name = values.Name,
                Price = values.Price,
                Description = values.Description,
                CategoryId = values.CategoryId,               

            });
        }
        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand updatePoductCommand)
        {
            _updateProductCommandHandler.Handle(updatePoductCommand);
            return RedirectToAction("ProductList");
        }
    }
}
