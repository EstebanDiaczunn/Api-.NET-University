using Api_esteban.Models.DataModels;

namespace Api_esteban.Services;

public interface IStudentsServices
{
    IEnumerable<Student> GetStudentsWithCourses();
    IEnumerable<Student> GetStudentsWithNoCourses();
}