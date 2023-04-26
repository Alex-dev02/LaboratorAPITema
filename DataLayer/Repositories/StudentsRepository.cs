using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class StudentsRepository : RepositoryBase<Student>
    {
        private readonly AppDbContext dbContext;

        public StudentsRepository(AppDbContext dbContext) : base(dbContext) 
        {
            this.dbContext = dbContext;
        }

        public Student GetByIdWithGrades(int studentId, CourseType type)
        {
            var result = dbContext.Students
               .Select(e => new Student
               {
                    FirstName= e.FirstName,
                    LastName= e.LastName,
                    Id = e.Id,
                    ClassId= e.ClassId,
                    Grades = e.Grades
                        .Where(g => g.Course == type)
                        .OrderByDescending(g => g.Value)
                        .ToList()
               })
               .FirstOrDefault(e => e.Id == studentId);

            return result;
        }
        public Student GetByEmail(string email)
        {
            return dbContext.Students.FirstOrDefault(e => e.Email == email);
        }
        public List<string> GetClassStudents(int classId)
        {
            var results = dbContext.Students
                .Include(e => e.Grades.Where(e => e.Value > 5))

                .Where(e => e.ClassId == classId)

                .OrderByDescending(e => e.FirstName)
                    .ThenByDescending(e => e.LastName)

                .Select(e => e.FirstName + "" + e.LastName)

                .ToList();

            return results;
        }

        public Dictionary<int, List<Student>> GetGroupedStudents()
        {
            var results = dbContext.Students
                .GroupBy(e => e.ClassId)
                .Select(e => new { ClassId = e.Key, Students = e.ToList() })
                .ToDictionary(e => e.ClassId, e => e.Students);

            return results;
        }

        public List<GradeDto> GetAllGrades(int studentId)
        {
            var result = _dbContext.Grades.Where(g => g.StudentId == studentId);
            return result.Select(g => new GradeDto{
                Value = g.Value,
                Course = g.Course
            }).ToList();
        }

        public List<GradeDto> GetAllStudentsGrades()
        {
            return _dbContext.Grades.Select(g => new GradeDto
            {
                Course = g.Course,
                Value = g.Value
            }).ToList();
        }
    }
}
