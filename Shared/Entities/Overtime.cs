
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Shared.Entities
{
   
    public class Overtime
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Months Months { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
    }
}
