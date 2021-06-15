using FrontEnd.Data;
using FrontEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDbContext _repoContext;
        // create constructor to inject repo
        public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }

        IOutcomeRepository _outcomes;

        public IOutcomeRepository Outcomes
        {
            get
            {
                if (_outcomes == null)
                {
                    _outcomes = new OutcomeRepository(_repoContext);
                }
                return _outcomes;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
