namespace CqrsDesing.WebUserInterface.CQRS.Commands.Category
{
    public class UpdateCategoryCommand
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
