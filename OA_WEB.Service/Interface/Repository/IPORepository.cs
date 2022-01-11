using OA_WEB.DataAccess.DTO;
using OA_WEB.DataAccess.Models.CompundTransactions;

namespace OA_WEB.Service.Interface.Repository
{
    public interface IPORepository : IGenericRepository<PO>
    {
        PO AddPO(POSODTO po);

        PO GetPODetails(int id);

        PO Post(int id);

        //PO PreparePO(int id, List<ItemEntry> itemEntries);
    }
}