using CqrsDesing.WebUserInterface.CQRS.Commands.Category;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;

namespace CqrsDesing.WebUserInterface.CQRS.Handlers.Category.Write
{
    public class CreateCategoryCommandHandler
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public CreateCategoryCommandHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }

        public void Handle(CreateCategoryCommand createCategoryCommand)
        {
            var category = new CqrsDesing.DataAccessLayer.Entities.Category
            {   
                Name = createCategoryCommand.Name,
                Description = createCategoryCommand.Description 
            };
            _cqrsDesingDb.Categories.Add(category);   
            _cqrsDesingDb.SaveChanges();
        }
    }
}
