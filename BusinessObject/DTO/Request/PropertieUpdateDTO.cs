using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.Request
{
    public class PropertieUpdateDTO
    {
        public int PID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public bool Status { get; set; }
        public int RealEstateID { get; set; }

    }
}
