using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;
using CqrsDesing.WebUserInterface.MediatorDesingPattern.Queries.Employee;
using CqrsDesing.WebUserInterface.MediatorDesingPattern.Results.Employee;
using MediatR;

namespace CqrsDesing.WebUserInterface.MediatorDesingPattern.Handlers.Employee.Read
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult>
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public GetEmployeeByIdQueryHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }

        public async Task<GetEmployeeByIdQueryResult> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _cqrsDesingDb.Employees.FindAsync(request.EmployeeId);
            return new GetEmployeeByIdQueryResult
            {
                EmployeeId = values.EmployeeId,
                FirstName = values.FirstName,
                LastName = values.LastName,
                Salary = values.Salary,
            };
        }
    }
}
