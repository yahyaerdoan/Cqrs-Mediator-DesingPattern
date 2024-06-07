using CqrsDesing.WebUserInterface.MediatorDesingPattern.Results.Employee;
using MediatR;

namespace CqrsDesing.WebUserInterface.MediatorDesingPattern.Queries.Employee
{
    public class GetEmployeeQuery : IRequest<List<GetEmployeeQueryResult>>
    {
    }
}
