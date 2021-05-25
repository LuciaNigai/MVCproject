using System.Web;
using lab2.Domain.Entities.User;
using lab2.BusinessLogic.Interfaces;
using lab2.Business.Logic.Core;
using lab2.BusinessLogic.Core;

namespace lab2.BusinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          public ULoginResp UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }


          public HttpCookie GenCookie(string loginCredential)
          {
               return Cookie(loginCredential);
          }


          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }
     }
}





