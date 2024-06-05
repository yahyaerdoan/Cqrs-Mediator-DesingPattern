using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Entities;

namespace CqrsDesing.WebUserInterface.CQRS.Commands.Product
{
    public class DeleteProductCommand
    {
        public int ProductId { get; set; }
        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
