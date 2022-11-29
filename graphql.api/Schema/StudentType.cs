using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql.api.Schema
{
    public class StudentType
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [GraphQLName("gpa")]
        public double GPA { get; set; }
    }
}
