using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql.api.Schema
{
    public class InstructorType
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public double Salary { get; set; }
    }
}