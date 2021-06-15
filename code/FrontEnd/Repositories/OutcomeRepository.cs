using FrontEnd.Data;
using FrontEnd.Interfaces;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Repositories
{
    public class OutcomeRepository : Repository<Outcome>, IOutcomeRepository
    {
        public OutcomeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
