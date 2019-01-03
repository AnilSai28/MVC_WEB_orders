using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mvc_web_api_orders.Models;

namespace mvc_web_api_orders.Controllers
{
    public class ordersapiController : ApiController
    {
        mydbcontext db = new mydbcontext();
        // GET: api/ordersapi
        public IEnumerable<ordermodel> Get()
        {
            return db.orders.ToList();
        }

        // GET: api/ordersapi/5
        public ordermodel Get(int id)
        {
            return db.orders.FirstOrDefault(o=>o.orderid==id);
        }

        // POST: api/ordersapi
        public bool  Post([FromBody]ordermodel value)
        {
            db.orders.Add(value);
            db.SaveChanges();
            return true;
        }

        // PUT: api/ordersapi/5
        public void Put(int id, [FromBody]ordermodel value)
        {
            var dbmodel = db.orders.FirstOrDefault(o => o.orderid == id);
            dbmodel.customermobileno = value.customermobileno;
            dbmodel.itemname = value.itemname;
            dbmodel.itemprice = value.itemprice;
            dbmodel.itemquantity = value.itemquantity;
            db.SaveChanges();
        }

        // DELETE: api/ordersapi/5
        public void Delete(int id)
        {
            var model = (from o in db.orders
                         where o.orderid == id
                         select o).FirstOrDefault();
            db.orders.Remove(model);
            db.SaveChanges();
        }
        [Route("api/ordersapi/search/{key}")]
        [HttpPost]
        public IEnumerable<ordermodel>search(string key)
        {
            var model = db.orders.Where(o => o.customermobileno.Contains(key) ||
              o.itemname.Contains(key)).ToList();
            return model;
        }
    }
}
