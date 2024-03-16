using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.Request
{
    public class RealEstateCreateDTO
    {
        [Required(ErrorMessage = "RealEstateName is required.")]
        public string? RealEstateName { get; set; }
        [Required(ErrorMessage = "RealEstateAddress is required.")]
        public string RealEstateAddress { get; set; }
        [Required(ErrorMessage = "Estimation is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Estimation must be greater than or equal to 0.")]
        public double Estimation { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "Image is required.")]
        public string Image { get; set; }
        [Required(ErrorMessage = "User is required.")]
        public int UserID { get; set; }

    }
}
