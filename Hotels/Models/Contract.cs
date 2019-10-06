using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Models
{
    public class Contract : BaseModel
    {
        public int Id { get; set; }
        public int Hotel_Id { get; set; }
        public int Vists_count { get; set; }
        public string Hotel_Name { get; set; }
        public string Notes { get; set; }

        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

        public float Price { get; set; }
    }
}
