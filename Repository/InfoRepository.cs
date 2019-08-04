using Entities;
using LoggerContracts;
using RepositoryContract;

namespace Repository
{
    public class InfoRepository : RepositoryBase<Info>, IInfoRepository
    {
        public InfoRepository(AppDbContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext.Db.GetCollection<Info>("Infos"), logger)
        {
        }
    }
}
