using CqrsDesing.WebUserInterface.CQRS.Queries.Category;
using CqrsDesing.WebUserInterface.CQRS.Results.Category;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;

namespace CqrsDesing.WebUserInterface.CQRS.Handlers.Category.Read
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public GetCategoryByIdQueryHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }
        public GetCategoryByIdQueyResult Handle(GetCategoryByIdQuery getCategoryByIdQuery)
        {
            var values = _cqrsDesingDb.Categories.Find(getCategoryByIdQuery.CategoryId);
            return new GetCategoryByIdQueyResult
            {
                CategoryId = values.CategoryId,
                Name = values.Name,
                Description = values.Description,
            };
        }
    }
}
