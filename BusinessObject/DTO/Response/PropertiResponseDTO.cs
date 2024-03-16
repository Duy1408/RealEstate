using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.Response
{
   public class PropertiResponseDTO
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public bool Status { get; set; }
        public int RealEstateID { get; set; }
        
    }
}
