using DatabaseAPI.Infra;
using DatabaseAPI.Interfaces;
using Domain;

namespace DatabaseAPI.Application
{    
    public class FuturesDeltaRepository : IFuturesDeltaRepository
    {
        private readonly FuturesDbContext _context;

        public FuturesDeltaRepository(FuturesDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(FuturesDeltaEntity delta)
        {
            _context.FuturesDeltaEntities.Add(delta);
            await _context.SaveChangesAsync();
        }
    }
}
