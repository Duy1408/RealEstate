using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.ViewModels
{
    public class CommentVM
    {
        public int CommentID { get; set; }
        public DateTime CommentDate { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public string? RealEstateName { get; set; }
    }
}
