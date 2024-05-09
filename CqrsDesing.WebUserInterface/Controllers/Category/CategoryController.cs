using CqrsDesing.WebUserInterface.CQRS.Handlers.Category.Read;
using CqrsDesing.WebUserInterface.CQRS.Results.Category;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDesing.WebUserInterface.Controllers.Category
{
    public class CategoryController : Controller
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        public CategoryController(GetCategoryQueryHandler getCategoryQueryHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
        }

        public IActionResult CategoryList()
        {
            var values = _getCategoryQueryHandler.Handle();
            return View(values);

        }
    }
}
