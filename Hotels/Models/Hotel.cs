using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Models
{
    public class Hotel : BaseModel
    {
        public int Id { get; set; }
        public int TanksCount { get; set; }
        public int TankSize { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
