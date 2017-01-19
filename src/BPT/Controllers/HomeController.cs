using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using BPT.ViewModels.Home;
using Microsoft.CodeAnalysis;

namespace BPT.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            //read starters.
 
            string[] starters = System.IO.File.ReadLines("Starters/starters.txt").ToArray();

            Random rnd = new Random();
            string[] startersRnd = starters.OrderBy(x => rnd.Next()).ToArray();


            ViewBag.starter = startersRnd[0].Substring(0, startersRnd[0].IndexOf('*'));
            string id = startersRnd[0].Substring(startersRnd[0].IndexOf('*'));
            ViewBag.id = id; 
            return View();
        }

        public IActionResult Start(string id)
        {
            // build model of what
            string[] starters = System.IO.File.ReadLines("Starters/starters.txt").ToArray();

            foreach (string starter in starters)
            {
                if (starter.Contains(id))
                {
                    ViewBag.starter = starter.Substring(0, starter.IndexOf('*'));
                    ViewBag.id = id;
                }
            }
           
            return View();
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel viewModel)
        {
            string path = "Starters/starters.txt";

            using (StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine(viewModel.StarterText + "*" + viewModel.Id + "*");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Start(PlayersViewModel viewModel)
        {
            
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            //create new file using the id as the name of the file.
            string path = "games/" + viewModel.StarterId.Replace("*", "") + DateTime.Now.Millisecond + ".txt";
            if (!System.IO.File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    sw.WriteLine(viewModel.StarterId);
                    sw.WriteLine(viewModel.YourEmail);
                    sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}",viewModel.Player2, viewModel.Player3, viewModel.Player4, viewModel.Player5, viewModel.Player6, viewModel.Player7));
                }
            }


            return RedirectToAction("Draw", new {Id = viewModel.StarterId});
        }


        public IActionResult Draw(string Id)
        {
            string[] starters = System.IO.File.ReadLines("Starters/starters.txt").ToArray();

            foreach (string starter in starters)
            {
                if (starter.Contains(Id))
                {
                    ViewBag.starter = starter.Substring(0, starter.IndexOf('*'));
                    ViewBag.id = Id;
                }
            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
