using eStudent.Data;
using eStudent.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace eStudent.Query
{
    public class UserQuery
    { 
        public int? RoleId { get; set; }
        public string? FirstName { get; set; }
        public List<int>? Ids { get; set; }

        public IQueryable<User> GetUserQuery(IQueryable<User> query) 
        {
            if (RoleId is not null) 
                query=query.Where(x => x.RoleId == RoleId);

            if(!FirstName.IsNullOrEmpty())
                query = query.Where(x => x.FirstName.Contains(FirstName));

            if(Ids is not null && Ids.Count is not 0)
                query = query.Where(x => Ids.Contains(x.Id));

            return query;        
        }
    }
}
