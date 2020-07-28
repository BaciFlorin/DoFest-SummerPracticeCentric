using DoFest.Entities.Authentication;

namespace DoFest.Persistence.Authentication
{
    public class StudentRepository:Repository<Student>, IStudentRepository
    {
        public StudentRepository(DoFestContext context) : base(context)
        {

        }
    }
}