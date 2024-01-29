using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;

namespace Data.Repositories {
    public interface IRepositoryInventoryRecord : IRepository<InventoryRecord> {
        Task<InventoryRecord> GetRecordOfProductInWarehouse(int pid, int wid);
    }
}
