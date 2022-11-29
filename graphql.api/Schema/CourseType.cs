using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql.api.Schema
{
    public enum Subject
    {
        Mathematics,
        Science,
        SocialScience,
        History,
        English
    }

    public class CourseType
    {
        public Guid Id { get; set; }
        public string? CourseName { get; set; }
        public Subject Subject { get; set; }
        public InstructorType? Instructor { get; set; }
        public IEnumerable<StudentType>? Students { get; set; }
    }
}