using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurantDemoApp.Models;
using WebAppRestaurantDemoApp.Repositories;
using WebAppRestaurantDemoApp.ViewModels;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace WebAppRestaurantDemoApp.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RestaurantDBEntities restaurantDBEntities;
        public HomeController()
        {
            restaurantDBEntities = new RestaurantDBEntities();
        }
        // GET: Home
        public Microsoft.AspNetCore.Mvc.ActionResult Index()
        {
            var objCustomerRepository = new CustomerRepository();
            var objItemRepository = new ItemRepository();
            var objPaymentRepository = new PaymentTypeRepository();
            var objMultipleModels = new Tuple<IEnumerable<System.Web.Mvc.SelectListItem>, IEnumerable<System.Web.Mvc.SelectListItem>, IEnumerable<System.Web.Mvc.SelectListItem>>(
                    objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentRepository.GetAllPaymentType());

            return View(objMultipleModels);
        }

        [System.Web.Mvc.HttpGet]

        public System.Web.Mvc.JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = restaurantDBEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;
            JsonResult jsonResult = UnitPrice as JsonResult;
            return jsonResult;

            [System.Web.Mvc.HttpPost]

            public JsonResult Index(OrderViewModel objOrderViewModel)
            {
                OrderRepository objOrderRepository = new OrderRepository();
                bool isStatus = objOrderRepository.AddOrder(objOrderViewModel);
                string SuccessMessage = String.Empty;

                if (isStatus)
                {
                    SuccessMessage = "Your Order Has Been Successfully Placed.";
                }
                else
                {
                    SuccessMessage = "There Is Some Issue While Placing Order.";
                }
                return JsonResult(SuccessMessage, JsonRequestBehavior.AllowGet);
            }
        }
    }
}