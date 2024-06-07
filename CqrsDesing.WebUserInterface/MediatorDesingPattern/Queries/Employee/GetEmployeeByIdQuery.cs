using CqrsDesing.WebUserInterface.MediatorDesingPattern.Results.Employee;
using MediatR;

namespace CqrsDesing.WebUserInterface.MediatorDesingPattern.Queries.Employee
{
    public class GetEmployeeByIdQuery : IRequest<GetEmployeeByIdQueryResult>
    {
        public int EmployeeId { get; set; }

        public GetEmployeeByIdQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
