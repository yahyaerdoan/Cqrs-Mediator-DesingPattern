using CqrsDesing.WebUserInterface.CQRS.Commands.Category;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;

namespace CqrsDesing.WebUserInterface.CQRS.Handlers.Category.Write
{
    public class DeleteCategoryCommandHandler
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public DeleteCategoryCommandHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }

        public void Handle(DeleteCategoryCommand deleteCategoryCommand)
        {
            var values = _cqrsDesingDb.Categories.Find(deleteCategoryCommand.CategoryId);
            _cqrsDesingDb.Remove(values);
            _cqrsDesingDb.SaveChanges();
        }
    }
}
