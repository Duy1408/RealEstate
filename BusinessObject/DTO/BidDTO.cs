﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class BidDTO
    {
        public int BidID { get; set; }
        [Required(ErrorMessage = "BidAmount is required.")]
        public double BidAmount { get; set; }
        public bool Status { get; set; }
    }
}
