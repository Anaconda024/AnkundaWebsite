using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkundaWebsite2.Data;

namespace AnkundaWebsite2.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepositoryBase<Interact> Interacts { get; }
        
        Task Save();
    }
}
