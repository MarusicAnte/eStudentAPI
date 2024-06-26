using eStudent.Models;

namespace eStudent.Query
{
    public class CollegeDepartmentQuery
    {
        public List<int>? Ids { get; set; }

        public IQueryable<CollegeDepartment> GetCollegeDepartmentQuery(IQueryable<CollegeDepartment> query)
        {

            if (Ids is not null && Ids.Count is not 0)
                query = query.Where(x => Ids.Contains(x.Id));

            return query;
        }
    }
}
