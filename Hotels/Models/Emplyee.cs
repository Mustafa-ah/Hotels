using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Models
{
    public class Emplyee : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Moble { get; set; }
        public float Salary { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
