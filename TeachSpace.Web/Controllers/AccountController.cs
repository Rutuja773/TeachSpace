using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using TeachSpace.Data;
using TeachSpace.Web.Models;

namespace TeachSpace.Web.Controllers
{
    public class AccountController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        //private User _currentUser;
        private TeachSpaceDBEntities entities = new TeachSpaceDBEntities();
        private object varhashedBytes;
        public static int UserId;
        public AccountController()
        {
            this.entities = new TeachSpaceDBEntities();
        }

        [Route("api/Account/Register")]
        [HttpPost]
        public void Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                using (entities)
                {
                    model.IsAdmin = false;
                    ObjectParameter errorMessage = new ObjectParameter("errorMessage", typeof(string));
                    entities.sp_Registeration(model.FirstName, model.LastName, model.Address, model.Email, model.Password, model.DOB,model.IsAdmin, errorMessage);
                    entities.SaveChanges();
                    logger.Info("Registration Successful");
                }
            }
        }

        [Route("api/Account/Login")]
        [HttpPost]
        public HttpResponseMessage Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                using (entities)
                {
                    using (var sha512 = SHA512.Create())
                    {
                        varhashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
                        var _currentUser = entities.Users.FirstOrDefault(m => m.Email == model.Email && m.Password == varhashedBytes);
                        if (_currentUser != null)
                        {
                            UserId = _currentUser.ID;
                            if (_currentUser.IsAdmin)
                            {
                                var adminUrl = this.Url.Content("https://localhost:44305/Home/Schedule");
                                logger.Info("Admin Login Successful");
                                return Request.CreateResponse(HttpStatusCode.Created,
                                                         new { Success = true, RedirectUrl = adminUrl });

                            }

                            //TODO: Redirect To Single app Page with this UserId
                            Debug.WriteLine("Success");
                            //Redirect("https://localhost:44320/Account/Login");

                            
                            var newUrl = this.Url.Content("https://localhost:44305/Home/Event");
                            logger.Info("User Login Successful");
                            return Request.CreateResponse(HttpStatusCode.OK,
                                                     new { Success = true, RedirectUrl = newUrl });
                           

                        }

                    }

                }
            }
            var new_Url = this.Url.Content("https://localhost:44305/Home/Login");
            return Request.CreateResponse(HttpStatusCode.Unauthorized,
                                                     new { Success = true, RedirectUrl = new_Url });
        }
    }

}
