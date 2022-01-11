using OA_WEB.DataAccess.DTO;
using OA_WEB.DataAccess.Models.CompundTransactions;

namespace OA_WEB.Service.Interface.Repository
{
    public interface ISORepository : IGenericRepository<SO>
    {
        SO AddSO(POSODTO soDto);

        SO GetSODetails(int id);

        SO Post(int id);
    }
}