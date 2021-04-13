using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeWebAPI.Models.DAL
{
    interface IStoreBridgeRepository : IDisposable
    {
        IEnumerable<Inventory> GetInventoryDetails();

        Inventory GetInventoryById(int id);

        void InsertInventory(Inventory inventory);

        void DeleteInventory(int Id);

        void UpdateInventory(Inventory inventory);

        void Save();
    }
}
