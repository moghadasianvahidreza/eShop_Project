using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
    public class UserCartController : Infrastructure.BaseController
    {
        // GET: UserCart
        public ActionResult _ShowCart()
        {
            List<ViewModels.ShopCartItemViewModel> list = new List<ViewModels.ShopCartItemViewModel>();

            if (Session["ShopCart"] != null)
            {
                List<ViewModels.ShopCartViewModel> listShop = (List<ViewModels.ShopCartViewModel>)Session["ShopCart"];

                foreach (var item in listShop)
                {
                    var product = DatabaseContext.Products.Where(current => current.ProductId == item.ProductId).Select(p => new
                    {
                        p.ImageName,
                        p.ProductTitle,
                    }).FirstOrDefault();

                    list.Add(new ViewModels.ShopCartItemViewModel()
                    {
                        ProductId = item.ProductId,
                        ImageName = product.ImageName,
                        ProductTitle = product.ProductTitle,
                        Count = item.Count,
                    });
                }
            }

            return PartialView(list);
        }
    }
}