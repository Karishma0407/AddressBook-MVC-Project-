using AddressBook.Models;
using AddressBookDB;
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

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            SelectLists ddlFilter = new SelectLists();
            ddlFilter.UserList = new SelectList((from a in _Repo.GetUserType()
                                                  select new
                                                  {
                                                      Value = a.typeId,
                                                      Text = a.type.Trim()
                                                  }).Distinct(), "Value", "Text");
            return View(ddlFilter);
        }

        [HttpGet]
        public ActionResult GetUser(int pageIndex, int pageSize, string sortField = "Id", string sortOrder = "desc", int userType = 0)
        {
            IEnumerable<AddressBookDB.user> UserList = null;
            IQueryable<AddressBookDB.user> Query = null;
            IEnumerable<AddressBookDB.Model.User> ResultList = null;

            int itemsCount = 0;
            var param = sortField;
            var propertyInfo = typeof(AddressBookDB.user).GetProperty(param);
            int skip = (pageIndex - 1) * pageSize;

            try
            {
                using (_Repo)
                {
                    //To get all the data
                    Query = _Repo.GetUsers();

                    // Filter the data based on the selected user type (userType)
                    //Query = _Repo.GetUsers().Where(u => u.userType.typeId == userType);
                    
                    itemsCount = Query.Count();

                    switch (sortField)
                    {
                        case "firstName":
                            if(sortOrder == "asc")
                            {
                                UserList = Query.OrderBy(S => S.firstName);
                            }
                            else if(sortOrder == "desc")
                            {
                                UserList = Query.OrderByDescending(S => S.firstName);
                            }
                            break;
                        case "lastName":
                            if (sortOrder == "asc")
                            {
                                UserList = Query.OrderBy(S => S.lastName);
                            }
                            else if (sortOrder == "desc")
                            {
                                UserList = Query.OrderByDescending(S => S.lastName);
                            }
                            break;

                        default:
                            UserList = Query.OrderBy(S => S.userId);
                            break;
                    }

                    ResultList = UserList.Skip(skip)
                        .Take(pageSize).ToList().ToList()
                        .Select(T => _ModelMapping.LoadUser(T));

                    var res = UserList.GroupBy(x => x.userId).Select(y => y.First());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var Result = new { data = ResultList, itemsCount = itemsCount };
            if(Result == null)
            {
                //
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public class ResultNames
        {
            public int Id { get; set; }
            public string Value { get; set; }
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