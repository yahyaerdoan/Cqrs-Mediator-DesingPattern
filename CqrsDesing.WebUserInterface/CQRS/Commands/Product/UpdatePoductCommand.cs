namespace CqrsDesing.WebUserInterface.CQRS.Commands.Product
{
    public class UpdatePoductCommand
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }
}
