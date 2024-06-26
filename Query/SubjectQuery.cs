using eStudent.Data;
using eStudent.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace eStudent.Query
{
    public class SubjectQuery
    {
        public List<int>? Ids { get; set; }

        public IQueryable<Subject> GetSubjectQuery(IQueryable<Subject> query)
        {

            if (Ids is not null && Ids.Count is not 0)
                query = query.Where(x => Ids.Contains(x.Id));

            return query;
        }
    }
}