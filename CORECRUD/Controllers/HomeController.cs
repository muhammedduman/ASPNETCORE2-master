using CORECRUD.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CORECRUD.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class HomeController : Controller
	{
		Context c = new Context();
		public IActionResult Index()
		{
			var DepList = c.Department_.ToList();
			return View(DepList);
		}

		[HttpGet]
		public IActionResult New(int ID)
		{
			if (ID == 0) //YENİ DEPARTMAN KAYDI
			{
				return View();
			}
			else
			{
				var depart = c.Department_.Find(ID);
				return View(depart);
			}

			
		}
		       
        [HttpPost]
		public IActionResult New(Department d)
		{
			if (d.DepartmentID == 0)
			{
				c.Department_.Add(d);
				c.SaveChanges();
			}
			else
			{
				var dep = c.Department_.Find(d.DepartmentID);
				dep.DepartmentName= d.DepartmentName;
				dep.Description1= d.Description1;
				dep.Description2 = "Düzenlenmiştir." + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

				c.SaveChanges();
			}

			 
			return RedirectToAction("Index");
		}
		         
        [HttpGet]
        public string Postman(string Name,string Surname)
        {
            return Name + Surname;
        }
        [HttpGet]
        public int Toplama(int Num1, int Num2)
        {
            return Num1 + Num2;
        }


       

		public IActionResult Delete(int ID)
		{

			var d = c.Department_.Find(ID);
			if (d != null)
			{
				c.Department_.Remove(d);
				c.SaveChanges();
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme );
			return RedirectToAction("Index","Login");
		}


		}
}
