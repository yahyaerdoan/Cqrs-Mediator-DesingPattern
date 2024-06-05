using CqrsDesing.WebUserInterface.CQRS.Commands.Category;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;

namespace CqrsDesing.WebUserInterface.CQRS.Handlers.Category.Write
{
    public class UpdateCategoryCommandHandler
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public UpdateCategoryCommandHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }
        public void Handle(UpdateCategoryCommand updateCategoryCommand)
        {
            var values = _cqrsDesingDb.Categories.Find(updateCategoryCommand.CategoryId);
            values.Name = updateCategoryCommand.Name;      
            values.Description = updateCategoryCommand.Description;
            _cqrsDesingDb.SaveChanges();
        }
    }
}
