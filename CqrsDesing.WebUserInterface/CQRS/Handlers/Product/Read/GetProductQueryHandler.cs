using CqrsDesing.WebUserInterface.CQRS.Results.Product;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;
using Microsoft.EntityFrameworkCore;

namespace CqrsDesing.WebUserInterface.CQRS.Handlers.Product.Read
{
    public class GetProductQueryHandler
    {
        private readonly CqrsDesingDb _cqrsDesingDb;
        public GetProductQueryHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }

        public List<GetProductQueryResult> Handle()
        {
            var values = _cqrsDesingDb.Products.Include(x=> x.Category). AsNoTracking().Select(x => new GetProductQueryResult
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                CategoryName = x.Category.Name,
            }).ToList();
            return values;
        }
    }
}
