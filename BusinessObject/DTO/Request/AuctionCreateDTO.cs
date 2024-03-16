using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.Request
{
    public class AuctionCreateDTO
    {
        //[Required(ErrorMessage = "DateStart is required.")]
        //[DataType(DataType.DateTime, ErrorMessage = "Invalid date format for DateStart.")]
        public DateTime DateStart { get; set; }
        //[Required(ErrorMessage = "DateEnd is required.")]
        //[DataType(DataType.DateTime, ErrorMessage = "Invalid date format for DateEnd.")]
        public DateTime DateEnd { get; set; }
        //[Required(ErrorMessage = "AuctionType is required.")]
        public bool AuctionType { get; set; }
        //[Required(ErrorMessage = "FeeAmount is required.")]
        //[Range(0, double.MaxValue, ErrorMessage = "FeeAmount must be greater than or equal to 0.")]
        public double DepositeAmount { get; set; }
        //[Required(ErrorMessage = "FeeAmount is required.")]
        //[Range(0, double.MaxValue, ErrorMessage = "FeeAmount must be greater than or equal to 0.")]
        public double FeeAmount { get; set; }
        //[Required(ErrorMessage = "Bid is required.")]
        public int BidID { get; set; }
        //[Required(ErrorMessage = "RealEstate is required.")]
        public int RealEstateID { get; set; }
    }
}
