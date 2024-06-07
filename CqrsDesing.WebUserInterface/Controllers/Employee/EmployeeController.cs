using CqrsDesing.WebUserInterface.MediatorDesingPattern.Commands.Employee;
using CqrsDesing.WebUserInterface.MediatorDesingPattern.Queries.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDesing.WebUserInterface.Controllers.Employee
{
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async  Task<IActionResult> EmployeeList()
        {
            var values = await _mediator.Send(new GetEmployeeQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand createEmployeeCommand)
        {
            await _mediator.Send(createEmployeeCommand);
            return RedirectToAction("EmployeeList");
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _mediator.Send(new DeleteEmployeeCommand(id));
            return RedirectToAction("EmployeeList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var values = await _mediator.Send(new GetEmployeeByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeCommand updateEmployeeCommand)
        {
            await _mediator.Send(updateEmployeeCommand);
            return RedirectToAction("EmployeeList");
        }
    }
}
