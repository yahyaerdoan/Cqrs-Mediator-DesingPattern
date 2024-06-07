using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;
using CqrsDesing.WebUserInterface.MediatorDesingPattern.Commands.Employee;
using MediatR;

namespace CqrsDesing.WebUserInterface.MediatorDesingPattern.Handlers.Employee.Write
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public UpdateEmployeeCommandHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }

        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var values = await _cqrsDesingDb.Employees.FindAsync(request.EmployeeId);
            values.EmployeeId = request.EmployeeId;
            values.FirstName = request.FirstName;
            values.LastName = request.LastName;
            values.Salary = request.Salary;

            await _cqrsDesingDb.SaveChangesAsync();
        }
    }
}
