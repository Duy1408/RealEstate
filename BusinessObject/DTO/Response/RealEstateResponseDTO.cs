using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.Response
{
    public class RealEstateResponseDTO
    {

        public int RealEstateID { get; set; }
        public string? RealEstateName { get; set; }

        public string RealEstateAddress { get; set; }

        public double Estimation { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
        public string UserName { get; set; }

    }
}
