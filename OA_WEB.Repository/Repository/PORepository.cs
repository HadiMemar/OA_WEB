using Microsoft.EntityFrameworkCore;
using OA_WEB.Common.Exceptions;
using OA_WEB.DataAccess.DTO;
using OA_WEB.DataAccess.Models.CompundTransactions;
using OA_WEB.Repository.AppDbContext;
using OA_WEB.Repository.UnitOfWork;
using OA_WEB.Service.Interface.Repository;
using System;
using System.Linq;

namespace OA_WEB.Repository.Repository
{
    public class PORepository : GenericRepository<PO>, IPORepository
    {
        public PORepository(ApplicationDbContext context) : base(context)
        {
        }

        public PO GetPODetails(int id)
        {
            var result = this._context.POs.AsNoTracking().Where(p => p.Id == id).Include(p => p.LeafTransactions).SingleOrDefault();
            if (result == null)
            {
                throw new NotFoundException("Po transaction not found", "403");
            }
            return result;
        }

        public PO AddPO(POSODTO poDto)
        {
            var entries = poDto.Entries;
            if (entries == null)
            {
                throw new Exception("error");
            }
            PO newPo = new PO
            {
                Date = poDto.Date,
                Direction = poDto.Direction,
                TargetId = poDto.TargetId,
                HubId = poDto.HubId,
            };
            newPo.CreateTransactionForItems(entries);

            var x = _context.Set<PO>().Add(newPo);

            return x.Entity;
        }

        public PO Post(int id)
        {
            UnitOfWorks _unitOfWork = new UnitOfWorks(_context);

            var result = _context.POs.AsNoTracking().Where(p => p.Id == id).Include(p => p.LeafTransactions).SingleOrDefault();
            if (result == null)
            {
                throw new NotFoundException("Po transaction not found", "403");
            }
            result.LeafTransactions.ForEach(t =>
            {
                _unitOfWork.Transactions.Post(t);
            });
            return result;
        }
    }
}