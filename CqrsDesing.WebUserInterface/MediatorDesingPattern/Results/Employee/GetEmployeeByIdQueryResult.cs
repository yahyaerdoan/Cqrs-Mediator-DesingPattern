namespace CqrsDesing.WebUserInterface.MediatorDesingPattern.Results.Employee
{
    public class GetEmployeeByIdQueryResult
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }
}
