using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;
using CqrsDesing.WebUserInterface.MediatorDesingPattern.Commands.Employee;
using CqrsDesing.WebUserInterface.Migrations;
using MediatR;

namespace CqrsDesing.WebUserInterface.MediatorDesingPattern.Handlers.Employee.Write
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public DeleteEmployeeCommandHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }

        public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var values = await _cqrsDesingDb.Employees.FindAsync(request.EmployeeId);
            _cqrsDesingDb.Remove(values);
            await _cqrsDesingDb.SaveChangesAsync();
        }
    }
}
