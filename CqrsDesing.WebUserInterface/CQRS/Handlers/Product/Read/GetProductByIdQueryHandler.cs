using CqrsDesing.WebUserInterface.CQRS.Queries.Product;
using CqrsDesing.WebUserInterface.CQRS.Results.Product;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;
using Microsoft.EntityFrameworkCore;

namespace CqrsDesing.WebUserInterface.CQRS.Handlers.Product.Read
{
    public class GetProductByIdQueryHandler
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public GetProductByIdQueryHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }

        public GetProductByIdQueryResult Handle(GetProductByIdQuery getProductByIdQuery)
        {
            var values = _cqrsDesingDb.Products.Include(x=> x.Category).FirstOrDefault(x=> x.ProductId == getProductByIdQuery.ProductId);
            return new GetProductByIdQueryResult
            {
                ProductId = values.ProductId,
                Name = values.Name,
                Price = values.Price,
                Description = values.Description,
                CategoryName = values.Category.Name,
                CategoryId = values.CategoryId
            };
        }
    }
}
