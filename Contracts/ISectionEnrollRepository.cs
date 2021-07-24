using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface ISectionEnrollRepository
    {
        IEnumerable<SectionEnroll> GetAllEnrollSections(bool trackChanges);

    }
}
