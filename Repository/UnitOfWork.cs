using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkundaWebsite2.Contracts;
using AnkundaWebsite2.Data;


namespace AnkundaWebsite2.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private  IGenericRepositoryBase<Interact> _interacts;
        

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGenericRepositoryBase<Interact> Interacts
            => _interacts ??= new GenericRepository<Interact>(_context);             
        

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            { _context.Dispose(); 
            };
            
        }

        public async  Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
