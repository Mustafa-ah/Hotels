using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Models
{
    public class Vist : BaseModel
    {
        public int Id { get; set; }
        public int Hotel_Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public string Emplyees { get; set; }
        public string Vist_Id { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
