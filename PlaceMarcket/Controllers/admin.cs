using be;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace store.core.Controllers
{
    //[Authorize(Roles = "admin , seller")]
    public class admin : Controller
    {
        private IWebHostEnvironment iwe;
        private UserManager<user> usermanager;
        private SignInManager<user> SignInManager;

        public admin(IWebHostEnvironment _iwe, SignInManager<user> signInmanager, UserManager<user> usermanager)
        {
            iwe = _iwe;
            this.SignInManager = signInmanager;
            this.usermanager = usermanager;
        }

        private bladmin bla = new bladmin();

        public IActionResult add(Models.Items item)
        {
            string name = DateTime.Now.Ticks + "@" + item.img_src.FileName;
            this.upload(item.img_src, name);
            Items i = new Items();
            i.Id = item.id;
            i.userId = item.seller_ID;
            i.name = item.name;
            i.pris = item.pris;
            i.size = item.size;
            i.code_mahsoul = item.code_mahsoul;
            i.color = item.color;
            i.exist = item.exist;
            i.detail = item.detail;
            if (item.img_src != null)
                i.img_src = item.img_src == null ? i.img_src = null : i.img_src = name;
            else
                i.img_src = "عکسی موجود نیست!!!";
            var r = bla.AddItems(i);
            return RedirectToAction("Items_List", new { id = item.seller_ID });
        }

        public async Task<IActionResult> addingPage()
        {
            return View();
        }

        public IActionResult delete(int id)
        {
            bla.DeleteItems(id);
            return RedirectToAction("Items_List");
        }

        public IActionResult find(string code)
        {
            var r = bla.find(code);
            return View("update_delete", r);
        }

        public async Task<IActionResult> Items_List(string id, int s = 0)
        {
            List<be.Items> all = new List<Items>();
            int a = (s - 1) * 20 < 0 ? a = 0 : a = (s - 1) * 20;
            all = await bla.SkipItems(a, usermanager, id);
            return View(all);
        }

        public async Task<IActionResult> Index()
        {
            var h = await usermanager.FindByNameAsync(User.Identity.Name);
            var q = bla.ReadAllSolds();
            List<Sold> s = new List<Sold>();
            foreach (var i in q)
            {
                if (i.pay == true && i.seller_id.Id == h.Id)
                {
                    s.Add(i);
                }
            }
            return View(s);
        }

        [AllowAnonymous]
        public async Task<IActionResult> login_singin()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> login0(string username, string PasswordHash)
        {
            if (username != null)
            {
                var u = await usermanager.FindByNameAsync(username);
                user h = null;
                if (u == null)
                {
                    return Json("یافت نشد");
                }
                h = u;
                if (PasswordHash != null)
                {
                    var s = await SignInManager.PasswordSignInAsync(user: h, password: PasswordHash, true, false);
                    var r = await usermanager.IsInRoleAsync(h, "admin");
                    var rr = await usermanager.IsInRoleAsync(h, "seller");
                    if (s.Succeeded && (r || rr))
                    {
                        await SignInManager.SignInAsync(h, true);
                        return RedirectToAction("Index");
                    }
                    else
                        return RedirectToAction("login_singin");
                }
                else
                {
                    ModelState.AddModelError("", "پسورد را وارد کنید");
                    return View("login_singin");
                }
            }
            return RedirectToAction("login_singin");
        }

        public async Task<IActionResult> solds(int s = 0)
        {
            int a = (s - 1) * 10 < 0 ? a = 0 : a = (s - 1) * 10;
            List<be.Sold> all = bla.SkipSolds(a);
            return View(all);
        }

        public IActionResult update(Models.Items i)
        {
            Items item = new Items();
            item.Id = i.id;
            item.name = i.name;
            item.code_mahsoul = i.code_mahsoul;
            item.color = i.color;
            item.detail = i.detail;
            item.exist = i.exist;
            item.userId = i.seller_ID;
            item.img_src = i.img_src == null ? item.img_src = null : item.img_src = DateTime.Now.Ticks + "@" + i.img_src.FileName;
            item.pris = i.pris;
            item.size = i.size;
            upload(i.img_src, item.img_src);
            bool r = bla.UpdateItems(item);
            if (r == true)
                return RedirectToAction("Items_List", new { id = item.userId });
            else
                return Json("مشکلی به وجود امده");
        }

        public async Task<IActionResult> update_delete()
        {
            return View();
        }

        public bool upload(IFormFile file, string name)
        {
            if (file == null)
                return false;
            var path = Path.Combine(iwe.WebRootPath, "images", "items", name);
            file.CopyToAsync(new FileStream(path, FileMode.CreateNew, FileAccess.ReadWrite));
            return true;
        }

        public async Task<IActionResult> Votes(int s = 0)
        {
            int a = (s - 1) * 10 < 0 ? a = 0 : a = (s - 1) * 10;
            List<be.Votes> all = bla.SkipVotes(a);
            return View(all);
        }
    }
}