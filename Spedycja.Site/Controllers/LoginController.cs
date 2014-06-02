using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using Spedycja.Model.EntityModels;
using Spedycja.Model.Repositories;
using Spedycja.Model.Repositories.Interfaces;
using Spedycja.Site.Models;
using System.Xml.Linq;

namespace Spedycja.Site.Controllers
{
    public class LoginController : Controller
    {/*
        private SelectList GetSelectList()
        {

            IUserRepository userRepo = new UserRepository();
            IEnumerable<Role> allRoles = userRepo.getAllRole();
            List<RoleList> list = new List<RoleList>();
            foreach (var singleRole in allRoles)
            {
                list.Add(new RoleList(singleRole.id, singleRole.Name));
            }

            return new SelectList(list, "RoleId", "RoleName");
        }*/

        public ActionResult Login()
        {


            var cookie = Request.Cookies["LogOn"];
            if (cookie != null)
            {

                return RedirectToAction("Index", "Spedycja");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModel data)
        {

            IWorkerRepository workerRepository = new WorkerRepository();
            bool workerExist = workerRepository.LogIn(data.Login, data.Password);


            if (ModelState.IsValid && workerExist != false)
            {
                string cookieValue = data.Login.ToString();
                var cookie = new HttpCookie("LogOn", cookieValue);
                Response.AppendCookie(cookie);
                return RedirectToAction("Index", "Spedycja");
            }
            else 
                return View();
        }

       /* public ActionResult Register()
        {

            RegisterModel viewModel = new RegisterModel
            {
                RoleSelect = GetSelectList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register(RegisterModel data)
        {
            #region rejestracja

            #endregion


            IUserRepository userRepo = new UserRepository();


            Role role = userRepo.getRoleById(data.RoleId);
            bool succes = userRepo.addNewUser(data.Name, data.Surname, data.Login, data.Password, role.Name);
            if (succes == true)
            {
                string cookieValue = data.Login.ToString();
                var cookie = new HttpCookie("LogOn", cookieValue);
                Response.AppendCookie(cookie);
                return RedirectToAction("HomePage", "Page");
            }
            else
            {
                return View("Exist");
            }


        }

        */
        public ActionResult LogOut()
        {

            if (Request.Cookies["LogOn"] != null)
            {
                HttpCookie myCookie = new HttpCookie("LogOn");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }

            return RedirectToAction("Login");
        }


    }
}
