using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CourseSectionRepository : RepositoryBase<CourseSection>, ICourseSectionRepository
    {
        public CourseSectionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public void CreateSection(int id, CourseSection section) 
        {
            section.courseid = id;
            Create(section);
        }

        public void DeleteSection(CourseSection section)
        {
            Delete(section);
        }

        public IEnumerable<CourseSection> GetAllSections(int cid, bool trackChanges) =>
         FindByCondition(c=> c.courseid.Equals(cid), trackChanges)
        .OrderBy(c => c.courseid)
        .ToList();

        public CourseSection GetSectionById(int cid, int csid, bool trackChanges) =>
            FindByCondition(c => c.courseid.Equals(cid) &&
                            c.cs_id.Equals(csid), trackChanges)
            .SingleOrDefault();


    }
}
