using AddressBook.Models;
using AddressBookDB.Interface;
using AddressBookDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository _Repo;
        ModelMapping _ModelMapping;

        public HomeController(IUserRepository Repo, ModelMapping ModelMapping)
        {
            _Repo = Repo;
            _ModelMapping = ModelMapping;
        }
        public ActionResult Index()
        {
            SelectLists ddlFilter = new SelectLists();
            ddlFilter.UserList = new SelectList((from a in _Repo.GetUsers()
                                                  select new
                                                  {
                                                      Value = a.userId,
                                                      Text = a.firstName.Trim() + "" + a.lastName.Trim()
                                                  }).Distinct(), "Value", "Text");
            return View(ddlFilter);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}