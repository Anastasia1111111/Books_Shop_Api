namespace Books_Shop_Api.Helpers
{
    public class EmployeesParams
    {
        public DateTime? fromEmployeeDateOfBirth { get; set; }
        public DateTime? toEmployeeDateOfBirth { get; set; }
        public DateTime? fromEmployeeHiryDate { get; set; }
        public DateTime? toEmployeeHiryDate { get; set; }
        public DateTime? fromEmployeeDateOfDismissal { get; set; }
        public DateTime? toEmployeeDateOfDismissal { get; set; }
        public string? employeeJobTitle { get; set; }
    }
}
