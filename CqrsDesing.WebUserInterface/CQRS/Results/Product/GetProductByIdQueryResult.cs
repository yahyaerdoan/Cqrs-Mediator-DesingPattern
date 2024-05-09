namespace CqrsDesing.WebUserInterface.CQRS.Results.Product
{
    public class GetProductByIdQueryResult
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }
}
