using System;
using System.Linq;
using System.Web.Mvc;
using lab2.BusinessLogic;
using lab2.Web.Extension;
using lab2.Domain.Entities;
using lab2.Domain.Entities.User;
using lab2.BusinessLogic.Interfaces;



namespace lab2Controllers
{
     public class BaseController : Controller
     {
          private readonly ISession _session;



          public BaseController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
          }



          public void SessionStatus()
          {
               var apiCookie = Request.Cookies["X-KEY"];
               if (apiCookie != null)
               {
                    var profile = _session.GetUserByCookie(apiCookie.Value);
                    if (profile != null)
                    { 
                         System.Web.HttpContext.Current.SetMySessionObject(profile);
                         System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
                    }
                    else
                    {
                         System.Web.HttpContext.Current.Session.Clear();
                         if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
                         {
                              var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                              if (cookie != null)
                              {
                                   cookie.Expires = DateTime.Now.AddDays(-1);
                                   ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                              }
                         }



                         System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
                    }
               }
               else
               {
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
               }
          }
     }
}