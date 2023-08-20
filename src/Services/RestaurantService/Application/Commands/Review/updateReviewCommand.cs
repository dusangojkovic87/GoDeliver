using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Review
{
    public class updateReviewCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public float Rating { get; set; }

    }
}