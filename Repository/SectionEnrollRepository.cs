using Contracts;
using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class SectionEnrollRepository : RepositoryBase<SectionEnroll>, ISectionEnrollRepository
    {
        public SectionEnrollRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public IEnumerable<SectionEnroll> GetAllEnrollSections(bool trackChanges) =>
         FindAll(trackChanges)
        .OrderBy(c => c.user_id)
        .ToList();
    }
}
