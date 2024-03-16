using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class CommentDTO
    {
        public int CommentID { get; set; }
        [Required(ErrorMessage = "CommentDate is required.")]
        public DateTime CommentDate { get; set; }
        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Rate is required.")]
        public int Rate { get; set; }
        [Required(ErrorMessage = "RealEstateID is required.")]
        public int RealEstateID { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "UserID is required.")]
        public int UserID { get; set; }
    }
}
