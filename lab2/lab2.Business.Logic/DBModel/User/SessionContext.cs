using lab2.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace lab2.BusinessLogic.DBModel.User
{
     public class SessionContext : DbContext
     {
          public SessionContext() : base("lab2")
          {

          }
          public virtual DbSet<Session> Sessions { get; set; }
     }



}