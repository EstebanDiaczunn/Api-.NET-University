using System.Security.Cryptography.X509Certificates;
namespace LinqSnippets
{
    public class Enterprice
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }

        public Employee[]? Employees { get; set; } = new Employee();
    }
}