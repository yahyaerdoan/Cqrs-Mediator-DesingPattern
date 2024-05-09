namespace CqrsDesing.WebUserInterface.CQRS.Results.Product
{
    public class GetProductQueryResult
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
    }
}
