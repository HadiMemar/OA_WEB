using Microsoft.EntityFrameworkCore;
using OA_WEB.Common.Exceptions;
using OA_WEB.DataAccess.DTO;
using OA_WEB.DataAccess.Models.CompundTransactions;
using OA_WEB.Repository.AppDbContext;
using OA_WEB.Repository.UnitOfWork;
using OA_WEB.Service.Interface;
using OA_WEB.Service.Interface.Repository;
using System;
using System.Linq;

namespace OA_WEB.Repository.Repository
{
    public class SORepository : GenericRepository<SO>, ISORepository
    {
        public SORepository(ApplicationDbContext context) : base(context)
        {
        }

        public SO AddSO(POSODTO soDto)
        {
            var entries = soDto.Entries;
            if (entries == null)
            {
                throw new Exception("error");
            }
            SO newSo = new SO
            {
                Date = soDto.Date,
                Direction = soDto.Direction,
                TargetId = soDto.TargetId,
                HubId = soDto.HubId,
            };
            newSo.CreateTransactionForItems(entries);

            var x = _context.Set<SO>().Add(newSo);

            return x.Entity;
        }

        public SO GetSODetails(int id)
        {
            var result = this._context.Sos.AsNoTracking().Where(p => p.Id == id).Include(p => p.LeafTransactions).SingleOrDefault();
            if (result == null)
            {
                throw new NotFoundException("So transaction not found", "403");
            }
            return result;
        }

        public SO Post(int id)
        {
            IUnitOfWork _unitOfWork = new UnitOfWorks(_context);

            var result = _context.Sos.AsNoTracking().Where(so => so.Id == id).Include(so => so.LeafTransactions).SingleOrDefault();
            if (result == null)
            {
                throw new NotFoundException("So transaction not found", "403");
            }
            result.LeafTransactions.ForEach(t =>
            {
                _unitOfWork.Transactions.Post(t);
            });
            return result;
        }
    }
}