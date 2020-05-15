using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApplication.Controllers
{
    public class ShopCartController : ApiController
    {
        // GET: api/ShopCart
        public int Get()
        {
            List<ViewModels.ShopCartViewModel> list = new List<ViewModels.ShopCartViewModel>();
            var sessions = System.Web.HttpContext.Current.Session;

            if (sessions["ShopCart"] != null)
            {
                list = sessions["ShopCart"] as List<ViewModels.ShopCartViewModel>;
            }

            return list.Sum(current => current.Count);
        }

        // GET: api/ShopCart/5
        public int Get(int id)
        {
            List<ViewModels.ShopCartViewModel> list = new List<ViewModels.ShopCartViewModel>();
            var sessions = System.Web.HttpContext.Current.Session;

            if (sessions["ShopCart"] != null)
            {
                list = sessions["ShopCart"] as List<ViewModels.ShopCartViewModel>;
            }

            if (list.Any(current => current.ProductId == id))
            {
                int index = list.FindIndex(current => current.ProductId == id);
                list[index].Count += 1;
            }
            else
            {
                list.Add(new ViewModels.ShopCartViewModel()
                {
                    ProductId = id,
                    Count = 1,
                });
            }

            sessions["ShopCart"] = list;

            return Get();
        }

        // POST: api/ShopCart
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShopCart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShopCart/5
        public void Delete(int id)
        {
        }
    }
}
