using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.Response
{
    public class AuctionResponseDTO
    {
        public int AuctionID { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public bool AuctionType { get; set; }
        public double DepositeAmount { get; set; }
        public double FeeAmount { get; set; }

        public bool Status { get; set; }

        public int BidID { get; set; }
     

        public int RealEstateID { get; set; }
        
    }
}
