using Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Gateway.EF
{
    public class EFGateway : IGateway<DbContext>
    {
        private readonly DbContext _db;
        public DbContext Instance { get => _db; }
        public EFGateway(DbContext db) => _db = db;
    }
}