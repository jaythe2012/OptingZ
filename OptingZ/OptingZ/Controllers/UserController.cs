using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OptingZ.DAL;
using OptingZ.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

namespace OptingZ.Controllers
{
    public class UserController : Controller
    {
        //private OptingzDbContext db = new OptingzDbContext();

        private UnitOfWork uow = new UnitOfWork();

        private UserManager<ApplicationUser> UserManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.UserManager = userManager;
        }

        public UserController()
        {
           
        }

        // GET: User
        public ActionResult Index()
        {
            //var userMasters = db.UserMasters.Include(u => u.UserRoleMaster);
            var userMasters = uow.UserRepository.GetAll();
            return View(userMasters.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = uow.UserRepository.GetByID(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            return View(userMaster);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            //ViewBag.UserRoleMasterID = new SelectList(db.UserRoleMasters, "ID", "Name");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,LastName,FirstName,UserName,Email,Password,UserRoleMasterID")] UserMaster userMaster)
        {
            if (ModelState.IsValid)
            {
                #region ASP.Net Registration
                var user = new ApplicationUser() { UserName = userMaster.UserName };
                var result = await UserManager.CreateAsync(user, userMaster.Password);
                if (result.Succeeded)
                {
                    userMaster.UserID = user.Id;
                    userMaster.UserName = user.UserName;
                    userMaster.UserRoleMasterID = 1;
                    uow.UserRepository.Add(userMaster);
                    uow.Save();
                    await SignInAsync(user, isPersistent: false);
                }

                    #endregion


             }


            return RedirectToAction("Index", "Home");
        }
        private IAuthenticationManager _authnManager;

        // Modified this from private to public and add the setter
        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                if (_authnManager == null)
                    _authnManager = HttpContext.GetOwinContext().Authentication;
                return _authnManager;
            }
            set { _authnManager = value; }
        }
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //UserMaster userMaster = db.UserMasters.Include(u => u.UserFiles).SingleOrDefault(u => u.ID == id);
            UserMaster userMaster = uow.UserRepository.Get(filter: u =>u.ID == id,
                includeProperties: "UserFiles").SingleOrDefault();
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserRoleMasterID = new SelectList(db.UserRoleMasters, "ID", "Name", userMaster.UserRoleMasterID);
            return View(userMaster);
        }

        public ActionResult EditByName(string Name)
        {
            if (Name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //UserMaster userMaster = db.UserMasters.Include(u => u.UserFiles).SingleOrDefault(u => u.ID == id);
            UserMaster userMaster = uow.UserRepository.Get(filter: u => u.UserName == Name,
                includeProperties: "UserFiles").SingleOrDefault();
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserRoleMasterID = new SelectList(db.UserRoleMasters, "ID", "Name", userMaster.UserRoleMasterID);
            return RedirectToAction("Edit", "User", userMaster);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,Email,Password,UserRoleMasterID,UserDetailMaster")] UserMaster userMaster, HttpPostedFileBase upload)
        {
            ///Another way to perfrom multiple table update is using AutoMapper. Need to discuss pro and cons.
            ///http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record

            UserMaster original = uow.UserRepository.Get(
                   filter: u => u.ID == userMaster.ID,
                   includeProperties: "UserDetailMaster,UserFiles"
                   ).SingleOrDefault();

          
            if (ModelState.IsValid)
            {
                original.LastName = userMaster.LastName;
                original.FirstName = userMaster.FirstName;
                original.Password = userMaster.Password;
                original.Email = userMaster.Email;
                if (upload != null && upload.ContentLength > 0)
                {
                    if (original.UserFiles != null)
                    {
                        UserFileMaster ufm = uow.UserFileRepository.GetFileByUserID(original.ID);
                        uow.UserFileRepository.Delete(ufm);
                        uow.Save();
                    }
                    var image = new UserFileMaster
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.ProfilePic,
                        ContentType = upload.ContentType,
                        UserMasterID = userMaster.ID
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        image.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    original.UserFiles = image;
                }

                if (original.UserDetailMaster != null)
                {
                    UserDetailMaster udm = uow.UserDetailRepository.GetUserDetailByUserID(original.ID);
                    uow.UserDetailRepository.Delete(udm);
                    uow.Save();
                }
                original.UserDetailMaster = userMaster.UserDetailMaster;
                original.UserDetailMaster.UserMasterID = userMaster.ID;
                original.UserRoleMasterID = 1;
                uow.UserRepository.Update(original);
                uow.Save();
                
            }
            //ViewBag.UserRoleMasterID = new SelectList(db.UserRoleMasters, "ID", "Name", userMaster.UserRoleMasterID);
            return View(original);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = uow.UserRepository.GetByID(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            return View(userMaster);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMaster userMaster = uow.UserRepository.GetByID(id);
            uow.UserRepository.Delete(userMaster);
            uow.Save();
            //db.UserMasters.Remove(userMaster);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> LogIn([Bind(Include = "UserName,Password,RememberMe")] LogIn login)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(login.UserName, login.Password);
                if (user != null)
                {
                    await SignInAsync(user, login.RememberMe);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }

                //return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SignOut()
        {
            AuthenticationManager.SignOut();
            System.Web.HttpContext.Current.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
