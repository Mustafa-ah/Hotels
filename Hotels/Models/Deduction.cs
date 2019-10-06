using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Models
{
    public class Deduction : BaseModel
    {
        public int Id { get; set; }
        public int Emplyee_Id { get; set; }
        public string Emplyee_Name { get; set; }
        public string Reson { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public float DeductionValue { get; set; }
    }
}
