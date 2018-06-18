using Database.Repository.Interface;
using System.Threading.Tasks;

namespace Database
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        ILocationRepository LocationRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IClassRepository ClassRepository { get; }
        IStudentRepository StudentRepository { get; }
    }
}
