using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ShopBridgeWebAPI.Models.DAL
{
   [CustomExceptionFilter]
    public class InventoryRepository : IStoreBridgeRepository
    {
        private DBContext _context;

        public InventoryRepository(DBContext context)
        {
            this._context = context;
        }

        public void DeleteInventory(int Id)
        {
            Inventory objinventory = _context.Inventorys.Find(Id);

            if (objinventory == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Entered id is not present in DB :{0}", Id)),
                    ReasonPhrase = "Invalid Id."
                };
                throw new HttpResponseException(msg);
            }
            _context.Inventorys.Remove(objinventory);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Inventory GetInventoryById(int id)
        {
            return _context.Inventorys.Find(id);
        }

        public IEnumerable<Inventory> GetInventoryDetails()
        {
            var data = _context.Inventorys.ToList();

            if (data == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Data is not present in databases.")),
                    ReasonPhrase = "Empty data."
                };
                throw new HttpResponseException(msg);

            }

            return _context.Inventorys.ToList();
        }

        public void InsertInventory(Inventory inventory)
        {
            _context.Inventorys.Add(inventory);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateInventory(Inventory inventory)
        {
            _context.Entry(inventory).State = System.Data.Entity.EntityState.Modified;
        }
    }
}