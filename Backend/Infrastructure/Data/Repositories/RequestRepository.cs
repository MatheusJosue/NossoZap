using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Infrastructure.Repositories
{
    public class RequestRepository : GenericRepository<Request, int>
    {
        public readonly MySQLContext _context;
        public RequestRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Request>> ListPendentRequestsByUserId(string username)
        {
            return await _context.Request.Where(x => x.toUsername == username && x.accepted == false).ToListAsync();
        }
    }
}
