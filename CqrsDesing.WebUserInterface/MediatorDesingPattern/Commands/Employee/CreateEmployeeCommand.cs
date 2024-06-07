using MediatR;

namespace CqrsDesing.WebUserInterface.MediatorDesingPattern.Commands.Employee
{
    public class CreateEmployeeCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }
}
