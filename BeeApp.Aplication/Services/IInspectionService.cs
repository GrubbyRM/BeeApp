using BeeApp.Domain.Entities;

namespace BeeApp.Aplication.Services
{
    public interface IInspectionService
    {
        Task Create(Domain.Entities.Inspection inspection);
        Task<IEnumerable<Domain.Entities.Inspection>> GetAll();
    }
}