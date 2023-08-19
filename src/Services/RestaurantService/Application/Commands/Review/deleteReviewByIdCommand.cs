using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Review
{
    public class deleteReviewByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }

    }
}