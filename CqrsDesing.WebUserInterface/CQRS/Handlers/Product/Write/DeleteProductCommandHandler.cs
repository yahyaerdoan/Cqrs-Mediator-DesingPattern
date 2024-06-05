using CqrsDesing.WebUserInterface.CQRS.Commands.Product;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;

namespace CqrsDesing.WebUserInterface.CQRS.Handlers.Product.Write
{
    public class DeleteProductCommandHandler
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public DeleteProductCommandHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }

        public void Handle(DeleteProductCommand deleteProductCommand)
        {
            var values = _cqrsDesingDb.Products.Find(deleteProductCommand.ProductId);
            _cqrsDesingDb.Remove(values);
            _cqrsDesingDb.SaveChanges();
        }
    }
}
