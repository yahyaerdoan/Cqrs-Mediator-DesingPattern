using CqrsDesing.WebUserInterface.CQRS.Results.Category;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;
using Microsoft.EntityFrameworkCore;

namespace CqrsDesing.WebUserInterface.CQRS.Handlers.Category.Read
{
    public class GetCategoryQueryHandler
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public GetCategoryQueryHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }

        public List<GetCategoryQueryResult> Handle()
        {
            var values = _cqrsDesingDb.Categories.AsNoTracking().Select(x => new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
            return values;
        }
    }
}
