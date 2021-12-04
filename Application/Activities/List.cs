using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Application.core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<Activity>>>
        {



        }
        public class Handler : IRequestHandler<Query, Result<List<Activity>>>
        {

            private readonly Datacontext _context;

            public Handler(Datacontext context)
            {
                _context = context;

            }

            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.ToListAsync();
                if(activity == null) return null;
                return Result<List<Activity>>.Success(activity) ;
            }
        }

    }
}