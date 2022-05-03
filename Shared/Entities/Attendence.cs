
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Shared.Entities
{
    public class Attendence 
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int EmployeeId { get; set; }
        public bool Status { get; set; }
        public string Remarks { get; set; }
    }
}
