using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class GetActivity
    {
        public class Query : IRequest<Result<Activity>>
        {

            public Guid Id { get; set; }



        }

        public class Handler : IRequestHandler<Query, Result<Activity>>
        {
            private readonly Datacontext _context;
            public Handler(Datacontext context)
            {
                _context = context;
            }

            public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity =  await _context.Activities.FindAsync(request.Id);
                if(activity == null) return null;

                return Result<Activity>.Success(activity);


            }
        }



    }
}