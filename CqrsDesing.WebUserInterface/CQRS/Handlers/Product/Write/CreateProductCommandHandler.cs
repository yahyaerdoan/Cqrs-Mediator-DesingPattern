using CqrsDesing.WebUserInterface.CQRS.Commands.Category;
using CqrsDesing.WebUserInterface.CQRS.Commands.Product;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Entities;

namespace CqrsDesing.WebUserInterface.CQRS.Handlers.Product.Write
{
    public class CreateProductCommandHandler
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public CreateProductCommandHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }

        public void Handle(CreatePoductCommand createPoductCommand)
        {
            var product = new CqrsDesing.DataAccessLayer.Entities.Product
            {
               Name = createPoductCommand.Name,
               Price = createPoductCommand.Price,
               Description = createPoductCommand.Description,
               CategoryId = createPoductCommand.CategoryId,
            };
            _cqrsDesingDb.Products.Add(product);
            _cqrsDesingDb.SaveChanges();
        }
    }
}
