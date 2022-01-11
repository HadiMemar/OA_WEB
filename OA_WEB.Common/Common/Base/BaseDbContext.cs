using Microsoft.EntityFrameworkCore;

namespace OA_WEB.Common.Base
{
    public class BaseDbContext : DbContext
    {
        #region Constructors

        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        #endregion Constructors
    }
}