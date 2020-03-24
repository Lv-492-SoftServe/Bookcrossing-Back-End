﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.IRepositories;
using Infastructure;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RequestRepository:BaseRepository<Request>, IRequestRepository
    {
        public RequestRepository(BookCrossingContext context) : base(context)
        {

        }
    }
}
