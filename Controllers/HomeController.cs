using ShopBridgeWebAPI.Models;
using ShopBridgeWebAPI.Models.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridgeWebAPI.Controllers
{
    [CustomExceptionFilter]
    public class HomeController : ApiController
    {
        private IStoreBridgeRepository interfaceDbContext;

        public HomeController()
        {
            this.interfaceDbContext = new InventoryRepository(new DBContext());
        }


        public HttpResponseMessage GetAllInventory()

        {
           var inventory = interfaceDbContext.GetInventoryDetails();
            if (inventory.Count() == 0)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("No data is found in database."),
                    ReasonPhrase = "No Data in DB."
                };
                throw new HttpResponseException(msg);
            }

            return Request.CreateResponse(HttpStatusCode.OK, inventory);
        }


        public HttpResponseMessage PostNewInventory(Inventory inven)
        {

            if (!ModelState.IsValid)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Data Invalid."),
                    ReasonPhrase = "data entered incorrect."
                };
                throw new HttpResponseException(msg);
            }

            interfaceDbContext.InsertInventory(inven);
            interfaceDbContext.Save();

            return Request.CreateResponse(HttpStatusCode.OK, "Insert Successfully.");
        }

        public HttpResponseMessage PutExistingInventory(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Data Invalid."),
                    ReasonPhrase = "data entered incorrect."
                };
                throw new HttpResponseException(msg);
            }

            interfaceDbContext.UpdateInventory(inventory);
            interfaceDbContext.Save();

            return Request.CreateResponse(HttpStatusCode.OK, "Data updated Successfully.");
        }


        public HttpResponseMessage DeleteExistingInventory(int id)
        {
            if (id <= 0)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Not a valid id:{0}",id)),
                    ReasonPhrase = "data entered incorrect."
                };
                throw new HttpResponseException(msg);
            }

            interfaceDbContext.DeleteInventory(id);
            interfaceDbContext.Save();

            return Request.CreateResponse(HttpStatusCode.OK, "Data deleted Successfully.");
        }
    }
}
