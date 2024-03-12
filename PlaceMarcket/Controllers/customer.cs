using be;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

//using BitPayDll;

namespace ShopMarsho.Controllers
{
    public class customer : Controller
    {
        private UserManager<user> usermanager;
        private SignInManager<user> SignInManager;
        private RoleManager<IdentityRole> roleManager;
        private BLL.bladmin bla = new bladmin();
        private BLL.blhuman blh = new blhuman();
        private string factor_id;

        public customer(SignInManager<user> signInmanager, UserManager<user> usermanager, RoleManager<IdentityRole> roleManager)
        {
            this.SignInManager = signInmanager;
            this.usermanager = usermanager;
            this.roleManager = roleManager;
        }

        //ABCDEFGHIJKLMNOPQRSTUVWXYZ

        public async Task<IActionResult> AddToCart(int Id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var h = await usermanager.FindByNameAsync(User.Identity.Name);
                if (h != null)
                {
                    //bugs here
                    var resault = bla.addToCart(h.Id, Id);
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Append(h.Id, Id.ToString(), option);
                    //Response.Cookies.Append(h.Id, Id + "/" + color + "/" + size, option);
                    if (resault)
                        return RedirectToAction("SingleProduct", new { id = Id, data = "با موفقیت به سبد خرید اضافه شد" });
                    else
                        return RedirectToAction("SingleProduct", new { id = Id, data = "مشکلی رخ داده است" });
                }
                else
                {
                    await SignInManager.SignOutAsync();
                    return RedirectToAction("login_singin");
                }
            }
            else
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append(Id.ToString(), Id.ToString(), option);
                //Response.Cookies.Append(Id.ToString(), Id + "/" + color + "/" + size, option);
                return RedirectToAction("SingleProduct", new { id = Id, data = "با موفقیت به سبد خرید اضافه شد" });
            }
        }

        //add to likes
        public async Task<IActionResult> AddToLikes(int id)
        {
            string Id = usermanager.FindByNameAsync(User.Identity.Name).Result.Id;
            if (Id != null)
            {
                bla.addToLikes(Id, id);
                return RedirectToAction("Product_detail", new { id = id });
            }
            return RedirectToAction("Login");
        }

        //add comments
        public async Task<IActionResult> AddComments(int id, string text)
        {
            if (User.Identity.IsAuthenticated)
            {
                string Id = usermanager.FindByNameAsync(User.Identity.Name).Result.Id;
                if (Id != null && text != null)
                {
                    bla.Sabt(Id, id, text);
                    return RedirectToAction("Product_detail", new { id = id });
                }
                return RedirectToAction("Login");
            }
            else
                return RedirectToAction("Login");
        }

        public async Task<IActionResult> Cart()
        {
            if (User.Identity.IsAuthenticated)
            {
                var h = await usermanager.FindByNameAsync(User.Identity.Name);
                if (h != null)
                {
                    //List<string> cart = new List<string>();
                    //foreach (var i in Request.Cookies.Keys)
                    //{
                    //    var cc = Request.Cookies[i];
                    //    if (!cart.Contains(cc))
                    //        cart.Add(cc);
                    //}
                    var c = bla.ReadCart(null, h.Id);
                    return View(c);
                }
                else
                {
                    await SignInManager.SignOutAsync();
                    return RedirectToAction("login_singin");
                }
            }
            else
            {
                List<string> cart = new List<string>();
                foreach (var i in Request.Cookies.Keys)
                {
                    var cc = Request.Cookies[i];
                    if (!cart.Contains(cc))
                        cart.Add(cc);
                }
                var c = bla.ReadCart(cart, null);
                return View(c);
            }

            //return View();
        }

        public IActionResult ChangeHuman(string id)
        {
            user h = blh.find_by_id(id);
            return View(h);
            //return View();
        }

        public IActionResult Check_Single(int id)
        {
            var r = bla.success_Public(id);
            return View(r);
            //return View();
        }

        public IActionResult CheckOrders(string f)
        {
            var r = bla.Success_Profile(f);
            return View(r);
            //return View();
        }

        public async Task<IActionResult> CreateUser(user h, string roleName)
        {
            var resault_user = await usermanager.CreateAsync(h, h.pass);
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            var resault_role = await usermanager.AddToRoleAsync(h, roleName);
            if (resault_user.Succeeded && resault_role.Succeeded)
            {
                await SignInManager.SignInAsync(h, true);
                return RedirectToAction("welcom");
            }
            else
            {
                return RedirectToAction("login_signin", "مشکلی رخ داده است");
            }
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var h = await usermanager.FindByNameAsync(User.Identity.Name);
                if (h != null)
                {
                    //List<string> cart = new List<string>();
                    //foreach (var i in Request.Cookies.Keys)
                    //{
                    //    var cc = Request.Cookies[i];
                    //    if (!cart.Contains(cc))
                    //        cart.Add(cc);
                    //}
                    var c = bla.ReadCart(null, h.Id);
                    return View(c);
                }
                else
                {
                    await SignInManager.SignOutAsync();
                    return RedirectToAction("login_singin");
                }
            }
            else
            {
                List<string> cart = new List<string>();
                foreach (var i in Request.Cookies.Keys)
                {
                    var cc = Request.Cookies[i];
                    if (!cart.Contains(cc))
                        cart.Add(cc);
                }
                var c = bla.ReadCart(cart, null);
                return View(c);
            }
            //return View();
        }

        public IActionResult login_singin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string PasswordHash)
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
                    var r = await SignInManager.PasswordSignInAsync(user: h, password: PasswordHash, true, false);
                    if (!r.Succeeded)
                        return RedirectToAction("login_singin");
                    else
                        await SignInManager.SignInAsync(h, true);
                    return RedirectToAction("profile");
                }
                else
                {
                    ModelState.AddModelError("", "پسورد را وارد کنید");
                    return View("login_singin");
                }
            }
            return RedirectToAction("login_singin");
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Orders(string u, string p)
        {
            var r = bla.Solds(u, p);
            ViewBag.user = usermanager.FindByNameAsync(u).Result;
            return View(r);
            //return View();
        }

        public IActionResult Pay(int[] tedad, int[] id, string[] color, string[] size, int[] price, string[] seller_id)
        {
            List<Sold> solds = new List<Sold>();
            for (int i = 0; i < id.Length; i++)
            {
                var s = bla.Pay(id[i]);
                s.tedad = tedad[i];
                s.size = size[i];
                s.color = color[i];
                s.price = price[i];
                s.seller_idId = seller_id[i];
                solds.Add(s);
            }
            return View(solds);
            //return View();
        }

        public IActionResult Pay_Fail(string f)
        {
            var r = bla.Success_Profile(f);
            return View(r.ToList());
            //return View();
        }

        public IActionResult Pay_Success(string f)
        {
            var r = bla.Success_Profile(f);
            return View(r.ToList());
            //return View();
        }

        public async Task<IActionResult> Product_Category(int s = 1)
        {
            int a = (s - 1) * 20 < 0 ? a = 0 : a = (s - 1) * 20;
            List<be.Items> all = await bla.SkipItems(a, usermanager, null);
            return View(all);
            //return View();
        }

        public IActionResult Profile()
        {
            ViewBag.h = null;
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.h = usermanager.FindByNameAsync(User.Identity.Name).Result;
            }
            else
            {
                return RedirectToAction("login_singin");
            }

            return View();
        }

        //آدرس ها
        public IActionResult Profile_address()
        {
            user user = usermanager.FindByNameAsync(User.Identity.Name).Result;
            return View(user);
        }

        //ایتم های موردعلاقه
        public IActionResult Profile_favorite()
        {
            var q = bla.Readlikes(usermanager.FindByNameAsync(User.Identity.Name).Result.Id);
            return View(q);
        }

        //سفارشات فعلی
        public IActionResult Profile_orders_detail()
        {
            user user = usermanager.FindByNameAsync(User.Identity.Name).Result;
            return View(user);
        }

        ////سفارشات
        //public async Task<IActionResult> Profile_orders()
        //{
        //    var user = await usermanager.FindByNameAsync(User.Identity.Name);
        //    var q = bla.Solds(user.UserName, user.pass);
        //    return View(q.ToList());
        //}

        //remove from cart
        public async Task<IActionResult> removeCart(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var h = await usermanager.FindByNameAsync(User.Identity.Name);
                if (h != null)
                {
                    var resault = bla.DeleteCart(h.Id, id);
                    Response.Cookies.Delete(h.Id);
                    if (resault)
                        return RedirectToAction("Cart", new { id = id, data = "با موفقیت از سبد خرید خذف شد" });
                    else
                        return RedirectToAction("Cart", new { id = id, data = "مشکلی رخ داده است" });
                }
                else
                {
                    await SignInManager.SignOutAsync();
                    return RedirectToAction("login_singin");
                }
            }
            else
            {
                CookieOptions option = new CookieOptions();
                Response.Cookies.Delete(id.ToString());
                return RedirectToAction("Cart", new { id = id, data = "با موفقیت از سبد خرید خذف شد" });
            }
        }

        //خواندن مورد علاقه ها
        public IActionResult ReadLikes(string Id)
        {
            bla.Readlikes(Id);
            return View();
        }

        public IActionResult Sabt(int id, string text)
        {
            if (User.Identity.IsAuthenticated)
            {
                string Id = usermanager.FindByNameAsync(User.Identity.Name).Result.Id;
                if (Id != null && text != null)
                {
                    bla.Sabt(Id, id, text);
                    return RedirectToAction("SingleProduct", new { id = id });
                }
                return RedirectToAction("login_singin");
            }
            else
                return RedirectToAction("login_singin");
        }

        public void solds(string user_name, string[] code_mahsoul, string[] name,
   string detail, string[] size, string family,
   string user, string pass, string email,
   string mobile, string adress, string code_posti,
   string[] color, int[] price, bool[] pay, string[] trans_id,
   string[] id_get, string[] FactorId, int[] tedad, int Amount, string[] seller_id)
        {
            List<Sold> s = new List<Sold>();
            for (int i = 0; i < tedad.Length; i++)
            {
                Sold ss = new Sold();
                ss.tedad = tedad[i];
                ss.detail = detail;
                ss.size = size[i];
                ss.customer.UserName = user_name;
                ss.customer.family = family;
                ss.customer.Email = email;
                ss.customer.mobile = mobile;
                ss.customer.address = adress;
                ss.code_posti = code_posti;
                ss.color = color[i];
                ss.price = price[i];
                ss.seller_id.Id = seller_id[i];
                s.Add(ss);
            }
            factor_id = bla.GenrateFactorID();
            var r = bla.Save_Solds(s, factor_id);
            if (factor_id != null)
            {
                if (r == true)
                {
                    //Send(Amount, factor_id, s.Last().customer.UserName, s.Last().customer.Email);
                }
            }
        }

        public IActionResult Search(string text)
        {
            if (text != null)
            {
                var q = bla.search(text);
                return View(q);
            }
            else
                return View("", "");
        }

        //public void Send(int Amount, string FactorId, string Name = "", string Email = "", string Description = "")
        //{
        //    BitPay bitpay = new BitPay();

        //    Amount = Amount * 10000;

        //    string Url = "https://bitpay.ir/payment/gateway-send";

        //    string Redirect = "https://blackland.shop/customer/Get";

        //    int result = bitpay.Send(Url, Api, Amount.ToString(), Redirect, FactorId, Name, Email, Description);

        //    if (result > 0)
        //    {
        //        string go = string.Format($"https://bitpay.ir/payment/gateway-{result}-get", result);
        //        Response.Redirect(go);
        //    }

        //}

        //public IActionResult Get(string trans_id, string id_get, string factorId)
        //{
        //    BitPay bitpay = new BitPay();

        //    string url = "https://bitpay.ir/payment/gateway-result-second";

        //    int result = bitpay.Get(url, api, trans_id, id_get);

        //    if (result == 1)
        //    {
        //        var r = bla.Success_Profile(factorId);
        //        foreach (var i in r)
        //        {
        //            i.pay = true;
        //            i.id_get = id_get;
        //            i.trans_id = trans_id;
        //        }
        //        var rr = bla.UpdateSolds(r);
        //        return RedirectToAction("Pay_Success", new { f = factorId });
        //    }
        //    else
        //    {
        //        var r = bla.Success_Profile(factorId);
        //        foreach (var i in r)
        //        {
        //            i.pay = false;
        //            i.id_get = id_get;
        //            i.trans_id = trans_id;
        //        }
        //        var rr = bla.UpdateSolds(r);
        //        return RedirectToAction("Pay_Fail", new { f = factorId });
        //    }
        //}

        public IActionResult SingleProduct(int id, string data)
        {
            var q = bla.Read_By_id(id);
            ViewBag.data = data;
            //q.usersId = usermanager.FindByIdAsync(q.usersId).Result.name;
            return View(q);
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(user h, string oldPass, string NewPass)
        {
            var user = await usermanager.FindByIdAsync(h.Id);
            user.name = h.name;
            user.family = h.family;
            user.pass = h.pass;
            user.Email = h.Email;
            user.address = h.address;
            user.post = h.post;
            user.UserName = h.UserName;
            user.mobile = h.mobile;
            var q = await usermanager.UpdateAsync(user);
            var qq = await usermanager.ChangePasswordAsync(user, oldPass, NewPass);
            if (q.Succeeded)
                return Json("ok");
            else
                return Json("nok");
        }

        public IActionResult welcom()
        {
            return View();
        }
    }
}