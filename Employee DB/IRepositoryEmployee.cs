
namespace Employee_DB
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll() =>
            _context.Employees.Include(e => e.Department).ToList();
    }
}
