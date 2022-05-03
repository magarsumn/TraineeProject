
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Shared.Entities
{
    public class BonusDeduction
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Months Months { get; set; }
        public string Bonus { get; set; }
        public string Deduction { get; set; }
        public string Remarks { get; set; }

    }

    public enum Months
    {
        Baishak = 1,
        Jestha = 2,
        Ashar = 3,
        Sharawn = 4,
        Bhadra = 5,
        Ashoj = 6,
        Kartik = 7,
        Mangsir = 8,
        Poush = 9,
        Magh = 10,
        Falgun = 11,
        Chaitra = 12,
    }
}
