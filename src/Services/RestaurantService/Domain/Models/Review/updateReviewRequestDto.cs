using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.Review
{
    public class updateReviewRequestDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public float Rating { get; set; }
    }
}