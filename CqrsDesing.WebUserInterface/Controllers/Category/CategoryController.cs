using CqrsDesing.WebUserInterface.CQRS.Commands.Category;
using CqrsDesing.WebUserInterface.CQRS.Commands.Product;
using CqrsDesing.WebUserInterface.CQRS.Handlers.Category.Read;
using CqrsDesing.WebUserInterface.CQRS.Handlers.Category.Write;
using CqrsDesing.WebUserInterface.CQRS.Queries.Category;
using CqrsDesing.WebUserInterface.CQRS.Results.Category;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDesing.WebUserInterface.Controllers.Category
{
    public class CategoryController : Controller
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly DeleteCategoryCommandHandler _deleteCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        public CategoryController(GetCategoryQueryHandler getCategoryQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, DeleteCategoryCommandHandler deleteCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _deleteCategoryCommandHandler = deleteCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
        }

        public IActionResult CategoryList()
        {
            var values = _getCategoryQueryHandler.Handle();
            return View(values);

        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            _createCategoryCommandHandler.Handle(createCategoryCommand);
            return RedirectToAction("CategoryList");

        }

        public IActionResult DeleteCategory(int id)
        {
            _deleteCategoryCommandHandler.Handle(new DeleteCategoryCommand(id));
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return View(new UpdateCategoryCommand()
            {
                CategoryId = values.CategoryId,
                 Name = values.Name,
                 Description = values.Description,
            });
        }
        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            _updateCategoryCommandHandler.Handle(updateCategoryCommand);
            return RedirectToAction("CategoryList");
        }
    }
}
