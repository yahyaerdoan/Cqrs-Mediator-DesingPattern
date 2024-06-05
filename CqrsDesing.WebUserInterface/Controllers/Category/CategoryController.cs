using CqrsDesing.WebUserInterface.CQRS.Commands.Category;
using CqrsDesing.WebUserInterface.CQRS.Handlers.Category.Read;
using CqrsDesing.WebUserInterface.CQRS.Handlers.Category.Write;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDesing.WebUserInterface.Controllers.Category
{
    public class CategoryController : Controller
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly DeleteCategoryCommandHandler _deleteCategoryCommandHandler;
        public CategoryController(GetCategoryQueryHandler getCategoryQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, DeleteCategoryCommandHandler deleteCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _deleteCategoryCommandHandler = deleteCategoryCommandHandler;
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
    }
}
