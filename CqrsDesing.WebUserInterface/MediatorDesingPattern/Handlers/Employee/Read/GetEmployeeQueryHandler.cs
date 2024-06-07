using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;
using CqrsDesing.WebUserInterface.MediatorDesingPattern.Queries.Employee;
using CqrsDesing.WebUserInterface.MediatorDesingPattern.Results.Employee;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsDesing.WebUserInterface.MediatorDesingPattern.Handlers.Employee.Read
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<GetEmployeeQueryResult>>
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public GetEmployeeQueryHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }

        public async Task<List<GetEmployeeQueryResult>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _cqrsDesingDb.Employees.Select(x => new GetEmployeeQueryResult
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Salary = x.Salary,
            }).ToListAsync();
        }
    }
}
