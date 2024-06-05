using CqrsDesing.WebUserInterface.CQRS.Commands.Product;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;

namespace CqrsDesing.WebUserInterface.CQRS.Handlers.Product.Write
{
    public class UpdateProductCommandHandler
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public UpdateProductCommandHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }
        public void Handle(UpdateProductCommand updatePoductCommand)
        {
            var values = _cqrsDesingDb.Products.Find(updatePoductCommand.ProductId);
            values.Name = updatePoductCommand.Name;
            values.Description = updatePoductCommand.Description;
            values.Price = updatePoductCommand.Price;
            _cqrsDesingDb.SaveChanges();
        }
    }
}
