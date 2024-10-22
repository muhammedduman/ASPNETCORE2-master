
using CORECRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CORECRUD.Controllers
{
    public class PeopleController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var PeopleList = c.People_.Include(x=> x._Depart).ToList();
            return View(PeopleList);
        }

        [HttpGet]
        public IActionResult New()
        {
            LoadDepartment();

			return View();
        }
		[HttpPost]
		public IActionResult New(People people)
		{
            //var dep = c.Department_.Find(people.DepartmentID);
            //people._Depart = dep;


			c.People_.Add(people);
            c.SaveChanges();

			return RedirectToAction("Index","People");
		}

        [NonAction]
        public void LoadDepartment()
        {
            var departmanList = new List<SelectListItem>();
            //Departman Listesini doldur
            foreach (var department in c.Department_.ToList())
            {
                departmanList.Add(new SelectListItem
                {
                    Value = department.DepartmentID.ToString(),
                    Text = department.DepartmentName.ToString()
                });
			}

            ViewBag.Department = departmanList;
        }



	}
}
