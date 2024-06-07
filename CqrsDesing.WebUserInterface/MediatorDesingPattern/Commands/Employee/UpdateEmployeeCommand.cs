using MediatR;

namespace CqrsDesing.WebUserInterface.MediatorDesingPattern.Commands.Employee
{
    public class UpdateEmployeeCommand : IRequest
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }
}
