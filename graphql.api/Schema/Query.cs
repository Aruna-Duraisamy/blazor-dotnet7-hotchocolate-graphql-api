using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;

namespace graphql.api.Schema
{
    public class Query
    {
        private readonly Faker<InstructorType> _instructorFaker;
        private readonly Faker<StudentType> _studentFaker;
        private readonly Faker<CourseType> _coursesFaker;

        public Query()
        {
             _instructorFaker = new Faker<InstructorType>()
            .RuleFor(x => x.Id, Guid.NewGuid)
            .RuleFor(x => x.FirstName, y=> y.Person.FirstName)
            .RuleFor(x => x.LastName, y=> y.Person.LastName)
            .RuleFor(x => x.Salary, y=> y.Random.Double(0,10000));

             _studentFaker = new Faker<StudentType>()
            .RuleFor(x => x.Id, Guid.NewGuid)
            .RuleFor(x => x.FirstName, y => y.Person.FirstName)
            .RuleFor(x => x.LastName, y => y.Person.LastName)
            .RuleFor(x => x.GPA, y => y.Random.Double(1,4));

            _coursesFaker = new Faker<CourseType>()
            .RuleFor(x => x.Id, Guid.NewGuid)
            .RuleFor(x => x.CourseName, y => y.Name.JobTitle())
            .RuleFor(x => x.Subject, y => y.PickRandom<Subject>())
            .RuleFor(x => x.Instructor, _instructorFaker.Generate())
            .RuleFor(x => x.Students, _studentFaker.Generate(3));
        }
        //resolver
        public IEnumerable<CourseType> GetCourses()
        {
            return _coursesFaker.Generate(5);
        }

        public CourseType GetCourseById(Guid id)
        {
            CourseType course = _coursesFaker.Generate();
            course.Id = id;
            return course;
        }

        [GraphQLDeprecated("No longer supported")]
        public string Message => "Hello World!";
    }
}