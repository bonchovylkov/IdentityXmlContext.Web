using IdentityXmlContext.Model;
using IdentityXmlContext.Utils;
using IdentityXmlContext.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace IdentityXmlContext.Web.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Index()
        {
           //might be put logic for Session here and log directrly..
            return View("Register");
        }

        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //check if there is user with this username in the db
                var userInDb = userRepository.GetAll().FirstOrDefault(s=>s.Username==model.UserName);
                if (userInDb != null)
                {
                    ModelState.AddModelError(Constants.MODEL_ERROR, Constants.MODEL_ERROR_USER_NAME_EXIST_VALUE);
                    return View(model);
                }

                //crypting password
                string hashedPass = BaseHelper.ComputeHash(model.Password, "SHA512", null);


                //might be done more easly with mapping
                ApplicationUser user = new ApplicationUser();
                user.Username = model.UserName;
                user.Password = hashedPass;

                //makes automatic save by default and creates GUID for id
                userRepository.Insert(user);

              
                
                bool flag = BaseHelper.VerifyHash("", "SHA512", "");


                //might be done more easly with mapping
                LoginViewModel loginModel = new LoginViewModel();
                loginModel.UserName = model.UserName;
                loginModel.Password = model.Password;

                return View("Login",model);
            }

            return View(model);
        }


        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                //get the user from db
                var userInDb = userRepository.GetAll().FirstOrDefault(s => s.Username == model.UserName);
                if (userInDb != null)
                {
                    bool rightPassword = BaseHelper.VerifyHash(model.Password, "SHA512", userInDb.Password);

                    if (!rightPassword)
                    {
                        ModelState.AddModelError(Constants.MODEL_ERROR
                        , Constants.MODEL_ERROR_USER_WRONG_PASS_VALUE);
                        return View(model);
                    }


                    return View("ShowUserDetails", model);
                }
                else
                {
                    ModelState.AddModelError(Constants.MODEL_ERROR, Constants.MODEL_ERROR_USER_NAME_DO_NOT_EXIST_VALUE);
                    return View(model);
                }


            }

            return View(model);
        }
      
    }
}