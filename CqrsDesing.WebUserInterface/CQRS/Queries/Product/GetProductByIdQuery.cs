namespace CqrsDesing.WebUserInterface.CQRS.Queries.Product
{
    public class GetProductByIdQuery
    {
        public int ProductId { get; set; }

        public GetProductByIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
