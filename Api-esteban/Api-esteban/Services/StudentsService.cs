using Api_esteban.DataAccess;
using Api_esteban.Services;
using Microsoft.EntityFrameworkCore;

namespace Api_esteban.Models.DataModels;

public class StudentsServices : IStudentsServices
{
    private static UniversityDBContext? _context;

    public StudentsServices(UniversityDBContext context)
    {
        _context = context;
    }

    //Search users by email
    public static async Task<List<User>> SearchByEmail(string email)
    {
        if (_context?.Users != null)
        {
            var UserEmail = await _context.Users.Where(u => u.Email == email).ToListAsync();
            return UserEmail;
        }

        return null;
    }

    //Search for students of legal age
    public static async Task<List<Student>> SearchLegalAge()
    {
        if (_context?.Students != null)
        {
            int legalAge = 18;
            
            DateTime currentDate = DateTime.Today;
            
            var ListOfStudents = await _context.Students.Where(s => (currentDate.Year - s.Dob.Year > legalAge) ||
                                                                   ((currentDate.Year - s.Dob.Year == legalAge) &&
                                                                    (s.Dob.Month < currentDate.Month ||
                                                                     (s.Dob.Month == currentDate.Month && s.Dob.Day <= currentDate.Day))))
                .ToListAsync();
            return ListOfStudents;  
        }

        return null;
    }

    //Find students who have at least one course
    public static async Task<IEnumerable<Student>> SearchStudentsWithCourses()
    {
        if (_context?.Students != null)
        {
            
            var studentsWithCourses = await _context.Students.Include(s => s.Courses).ToListAsync();
            return studentsWithCourses;
        }

        return null;
    }

    //Find courses at a given level that have at least one student enrolled

    public static async Task<IEnumerable<Course>> SearchCoursesAtLevel(string levelType)
    {
        if (_context?.Courses != null)
        {
            var coursesAtLevel = await _context.Courses.Include(c => c.Students).Where(c => c.Level.Equals(levelType)).ToListAsync();
            return coursesAtLevel;
        }
        return null;
    }
    
    //Find courses at a given level that are in a given category
    public static async  Task<IEnumerable<Course>> SearchCoursesAtLevelAndCategory(string levelType, string categoryRequired)
    {  
            if (_context?.Courses != null)
            {
                var coursesAtLevelAndCategory = await _context.Courses.Include(c => c.Level.Equals(levelType)
                    &&c.Categories.Equals(categoryRequired)).ToListAsync();
            return coursesAtLevelAndCategory;
            }
            return null;
    }
    
    //Find courses without students
    public static async  Task<IEnumerable<Course>> SearchCoursesWithoutStudents()
    {
            if (_context?.Courses != null)
            {
                var coursesWithoutStudents = await _context.Courses.Include(c => c.Students).Where(c => c.Students.Count == 0).ToListAsync();
                return coursesWithoutStudents;
            }
            return null;
    }

        //TODO: resolve methods
    public IEnumerable<Student> GetStudentsWithCourses()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Student> GetStudentsWithNoCourses()
    {
        throw new NotImplementedException();
    }
}




