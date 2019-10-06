using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Models
{
    public class Outgoing : BaseModel
    {
        public int Id { get; set; }
        public int Vist_Id { get; set; }
        public float OutGoing { get; set; }
        public string Details { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
    }
}
