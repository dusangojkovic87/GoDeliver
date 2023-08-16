using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Review
{
    public class AddReviewCommand : IRequest<bool>
    {
        public int RestaurantId { get; set; }

        public string UserName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }

        public DateTime DatePosted { get; set; }

    }
}