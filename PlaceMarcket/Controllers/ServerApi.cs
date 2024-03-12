using be;
using BLL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

//using BitPayDll;
using System.Linq;
using System.Threading.Tasks;

namespace store.core.Controllers
{
    [EnableCors("MyPolicy")]
    public class ServerApi : Controller
    {
        private UserManager<user> usermanager;
        private SignInManager<user> SignInManager;
        private IWebHostEnvironment iwe;

        public ServerApi(SignInManager<user> signInmanager, UserManager<user> usermanager, IWebHostEnvironment _iwe)
        {
            this.SignInManager = signInmanager;
            this.usermanager = usermanager;
            iwe = _iwe;
        }

        private bladmin bla = new bladmin();

        public IActionResult add(string data)
        {
            Models.Items item = new Models.Items();
            foreach (var j in data.Split(','))
            {
                List<byte> list = new List<byte>();
                list.Add(Convert.ToByte(j));
                byte[] data0 = list.ToArray();
                this.testupload(data0);
            }
            var q = JsonConvert.DeserializeObject<Models.Items>(data);
            item.img_src = q.img_src;
            this.upload(item.img_src);
            Items i = new Items();
            var r = bla.AddItems(i);
            return Json(r);
        }

        public string addtocart(string Id, string hId, string color, string size)
        {
            //bugs here
            var resault = bla.addToCart(Id, 0);
            string json;
            if (resault)
                json = JsonConvert.SerializeObject(new { id = Id, data = "با موفقیت به سبد خرید اضافه شد" });
            else
                json = JsonConvert.SerializeObject(new { id = Id, data = "مشکلی رخ داده است" });
            return json;
        }

        public int getall()
        {
            return bla.GetAllItems();
        }

        public int getalls()
        {
            return bla.GetAllSolds();
        }

        public int getallv()
        {
            return bla.GetAllVotes();
        }

        public List<Votes> getvotes()
        {
            return bla.GetVotes();
        }

        [HttpPost]
        public async Task<string> login(string username, string PasswordHash)
        {
            if (username != null)
            {
                //if (ModelState.IsValid)
                //{
                var u = await usermanager.FindByNameAsync(username);
                user h = null;
                if (u == null)
                {
                    return JsonConvert.SerializeObject("یافت نشد");
                }
                h = u;
                var rr = await SignInManager.UserManager.FindByNameAsync(h.UserName);
                var rrr = await SignInManager.UserManager.CheckPasswordAsync(h, h.pass);
                var rrrr = await SignInManager.UserManager.CheckPasswordAsync(h, h.PasswordHash);
                var rrrrr = await SignInManager.UserManager.CheckPasswordAsync(h, PasswordHash);
                if (PasswordHash != null)
                {
                    var r = await SignInManager.PasswordSignInAsync(user: h, password: PasswordHash, true, false);
                    if (!r.Succeeded)
                        return JsonConvert.SerializeObject("login_singin");
                    else
                        await SignInManager.SignInAsync(h, true);
                    return JsonConvert.SerializeObject("profile/" + h.PasswordHash + "/" + h.address + "/" + h.Email + "/" + h.mobile + "/" + h.name + h.family);
                }
                else
                {
                    ModelState.AddModelError("", "پسورد را وارد کنید");
                    return JsonConvert.SerializeObject("login_singin");
                }
            }
            return JsonConvert.SerializeObject("login_singin");
        }

        public IActionResult pay(int[] tedad, int[] id, string[] color, string[] size, int[] price, string name, string address, string detail, string phone)
        {
            List<be.Sold> solds = new List<Sold>();
            for (int i = 0; i < id.Length; i++)
            {
                var s = bla.Pay(id[i]);
                s.tedad = tedad[i];
                s.size = size[i];
                s.color = color[i];
                s.price = price[i];

                s.detail = detail;
                solds.Add(s);
            }
            return RedirectToAction("pay", "customer", new { id, tedad, color, size, price, name, address, detail, phone });
        }

        public IActionResult Pay_Fail(string f)
        {
            var r = bla.Success_Profile(f);
            return RedirectToAction("Pay_Fail", "customer", r.ToList());
        }

        public IActionResult Pay_Success(string f)
        {
            var r = bla.Success_Profile(f);
            return RedirectToAction("Pay_Success", "customer", r.ToList());
        }

        public string ReadAll()
        {
            var q = bla.ReadAllItems();
            string json = JsonConvert.SerializeObject(q);
            return json;
        }

        public string ReadById(int id)
        {
            var q = bla.Read_By_id(id);
            string json = JsonConvert.SerializeObject(q);
            return json;
        }

        public string ReadCart(string Id)
        {
            var q = bla.ReadCart(null, Id);
            string json = JsonConvert.SerializeObject(q, Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return json;
        }

        public string ReadItems()
        {
            var q = bla.ReadAllItems();
            q[0].Id = 1;
            string json = JsonConvert.SerializeObject(q);
            return json;
        }

        public string ReadSolds()
        {
            var q = bla.ReadAllSolds();
            string json = JsonConvert.SerializeObject(q);
            return json;
        }

        public string search(string item)
        {
            var q = bla.search(item);
            string json = JsonConvert.SerializeObject(q);
            return json;
        }

        public string skip(int s)
        {
            var q = bla.SkipItems(s, usermanager, null);
            string json = JsonConvert.SerializeObject(q);
            return json;
        }

        public List<be.Sold> skips(int s)
        {
            return bla.SkipSolds(s);
        }

        public List<be.Votes> skipv(int s)
        {
            return bla.SkipVotes(s);
        }

        public void solds(string[] user_name, string[] code_mahsoul, string[] name,
           string[] detail, string[] size, string[] family,
           string[] user, string[] pass, string[] email,
           string[] mobile, string[] adress, string[] code_posti,
           string[] color, int[] price, bool[] pay, string[] trans_id,
           string[] id_get, string[] FactorId, int[] tedad, int Amount)
        {
            List<Sold> s = new List<Sold>();
            for (int i = 0; i < tedad.Length; i++)
            {
                Sold ss = new Sold();
                ss.tedad = tedad[i];
                ss.detail = detail[i];
                ss.size = size[i];
                ss.code_posti = code_posti[i];
                ss.color = color[i];
                ss.price = price[i];
                s.Add(ss);
            }
            var factor_id = bla.GenrateFactorID();
            var r = bla.Save_Solds(s, factor_id);
            if (factor_id != null)
            {
                if (r == true)
                {
                    //Send(Amount, factor_id, s.Last().customer.UserName, s.Last().customer.Email);
                }
            }
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
        //[HttpGet]
        //public IActionResult Get(string trans_id, string id_get, string factorId)
        //{
        //    BitPay bitpay = new BitPay();

        //    string url = "https://bitpay.ir/payment/gateway-result-second";

        //    //string trans_id = Request.Form["trans_id"];

        //    //string id_get = Request.Form["id_get"];

        //    //string factorId = Request.Form["factorId"];

        //    int result = bitpay.Get(url, api, trans_id, id_get);

        //    if (result == 1)
        //    {
        //        //وضعیت پرداخت رو یادت نره درست کنی
        //        //true
        //        //TempData["msg"] = string.Format($"پرداخت شما با شماره فاکتور {factorId} موفقیت انجام شد", factorId);
        //        var r = bla.Success_Profile(factorId);
        //        foreach (var i in r)
        //        {
        //            i.pay = true;
        //        }
        //        return RedirectToAction("Pay_Success", new { f = factorId });
        //    }
        //    else
        //    {
        //        //false
        //        //TempData["msg"] = "خطا در پرداخت";
        //        var r = bla.Success_Profile(factorId);
        //        return RedirectToAction("Pay_Fail", new { f = factorId });
        //    }
        //    //return View();

        //}

        public void testupload(byte[] file)
        {
            string filePath = Path.Combine(iwe.WebRootPath, "images", "items", "filename");
            using var stream = System.IO.File.Create(filePath);
            stream.Write(file, 0, file.Length);
        }

        public bool upload(IFormFile file)
        {
            if (file == null)
                return false;
            //var path = iwe.WebRootPath + "//images//items//" + file.FileName;
            //var f = System.IO.File.Create(path);
            //file.CopyTo(f);
            var path = Path.Combine(iwe.WebRootPath, "images", "items", file.FileName);
            file.CopyToAsync(new FileStream(path, FileMode.CreateNew, FileAccess.ReadWrite));
            //new FileStream(path,FileMode.CreateNew);
            return true;
        }
    }
}