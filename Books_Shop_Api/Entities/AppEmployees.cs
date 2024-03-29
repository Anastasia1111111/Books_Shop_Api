using System.ComponentModel.DataAnnotations;

namespace Books_Shop_Api.Entities
{
    public class AppEmployees
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public string Surname { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public DateTime Hirу_Date { get; set; }
        public DateTime? Date_of_Dismissal { get; set; }
        public string Job_Title { get; set; }
    }
}
