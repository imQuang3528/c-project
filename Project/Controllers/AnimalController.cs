using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult GetAnimal()
        {
            List<Animals> lstAl = new List<Animals>()
            {
                new Animals() { AnimalName="Dog",Color="yellow"},
                new Animals() { AnimalName="Cow",Color="black"},
                new Animals() { AnimalName="Dove",Color="Navy"},
                new Animals(){AnimalName="Goat",Color="white"}
            };
            
            return View(lstAl);
        }
    }
}