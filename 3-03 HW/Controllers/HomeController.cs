using _3_03_HW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _3_03_HW.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Lenders;Integrated Security=true;";

            public IActionResult Index()
        {

            var db = new PersonDb(_connectionString);
            var vm = new PersonViewModel();
            vm.People = db.GetPeople();
            return View(vm);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(List<Person>people)
        {
            var db = new PersonDb(_connectionString);
            db.AddPeople(people);
            return Redirect("/");
        }


    }
}
