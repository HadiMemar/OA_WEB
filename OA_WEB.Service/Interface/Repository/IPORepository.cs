using OA_WEB.DataAccess.DTO;
using OA_WEB.DataAccess.Models.CompundTransactions;

namespace OA_WEB.Service.Interface.Repository
{
    public interface IPORepository : IGenericRepository<PO>
    {
        PO AddPO(PODTO po);

        PO Post(int id);

        PO GetPODetails(int id);

        //PO PreparePO(int id, List<ItemEntry> itemEntries);
    }
}