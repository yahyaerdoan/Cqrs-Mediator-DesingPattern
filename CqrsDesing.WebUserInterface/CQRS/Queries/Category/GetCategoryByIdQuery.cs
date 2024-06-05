namespace CqrsDesing.WebUserInterface.CQRS.Queries.Category
{
    public class GetCategoryByIdQuery
    {
        public int CategoryId { get; set; }

        public GetCategoryByIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
