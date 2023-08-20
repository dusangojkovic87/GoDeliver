using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.Review
{
    public class deleteReviewRequestDto
    {
        public int Id { get; set; }
        public string userEmail { get; set; }

    }
}