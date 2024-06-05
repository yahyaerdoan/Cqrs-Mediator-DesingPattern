namespace CqrsDesing.WebUserInterface.CQRS.Commands.Category
{
    public class DeleteCategoryCommand
    {
        public int CategoryId { get; set; }
        public DeleteCategoryCommand(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
