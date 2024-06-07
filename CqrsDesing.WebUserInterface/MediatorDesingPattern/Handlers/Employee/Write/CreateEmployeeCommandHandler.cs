using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx;
using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Entities;
using CqrsDesing.WebUserInterface.MediatorDesingPattern.Commands.Employee;
using MediatR;

namespace CqrsDesing.WebUserInterface.MediatorDesingPattern.Handlers.Employee.Write
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly CqrsDesingDb _cqrsDesingDb;

        public CreateEmployeeCommandHandler(CqrsDesingDb cqrsDesingDb)
        {
            _cqrsDesingDb = cqrsDesingDb;
        }

        public async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _cqrsDesingDb.AddAsync(new CqrsDesing.DataAccessLayer.Entities.Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Salary = request.Salary,
            });
            await _cqrsDesingDb.SaveChangesAsync();
        }
    }
}
