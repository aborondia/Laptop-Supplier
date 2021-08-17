using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopSupplier.Models;
using LaptopSupplier.Library;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;

namespace LaptopSupplier.Controllers
{
  public class LaptopController : Controller
  {
    public IActionResult Index()
    {
      if (DataBase.Laptops.Count <= 0)
      {
        ViewData["UserMessage"] = new HtmlString("<span class=text-danger>There are no products in the database.</span>");
        return View();
      }

      IEnumerable<Laptop> laptops = DataBase.Laptops.OrderBy(laptop => laptop.Brand.Name);
      ViewBag.SortCriteria = new SelectList(Enum.GetValues(typeof(SortCriteria)));
      ViewBag.StartYear = DataBase.YearSelectList;
      ViewBag.EndYear = DataBase.YearSelectList;
      ViewBag.FilterDisplay = new List<string> { "None" };

      return View(laptops);
    }

    [HttpPost]
    public IActionResult Index(int NumberToShow, double MinPrice, double MaxPrice, SortCriteria SortCriteria, int StartYear, int EndYear)
    {
      IEnumerable<Laptop> laptops = SortFilter.GetFilteredList(MinPrice, MaxPrice, StartYear, EndYear);
      laptops = SortFilter.GetSortedList(laptops, SortCriteria);
      ViewBag.SortCriteria = DataBase.SortSelectList;
      ViewBag.StartYear = DataBase.YearSelectList;
      ViewBag.EndYear = DataBase.YearSelectList;
      ViewBag.FilterDisplay = SortFilter.GetFilterDisplayList(NumberToShow, MinPrice, MaxPrice, SortCriteria, StartYear, EndYear);
      ViewData["UserMessage"] = laptops.Count() > 0 ? "" : "No Results Found Matching Criteria";

      if (NumberToShow > 0)
      {
        laptops = laptops.Take(NumberToShow);
      }

      return View(laptops);
    }

    public IActionResult Compare()
    {
      if (DataBase.Laptops.Count <= 0)
      {
        ViewData["UserMessage"] = new HtmlString("<span class=text-danger>There are no products in the database.");
        return View();
      }

      ViewBag.Laptop1 = DataBase.LaptopSelectList;
      ViewBag.Laptop2 = DataBase.LaptopSelectList;
      ViewData["HideBorder"] = true;

      return View();
    }

    [HttpPost]
    public IActionResult Compare(int Laptop1, int Laptop2)
    {
      IEnumerable<Laptop> laptopsInDataBase = DataBase.Laptops;
      Laptop laptop1 = DataBase.Laptops.FirstOrDefault(laptop => laptop.Id == Laptop1);
      Laptop laptop2 = DataBase.Laptops.FirstOrDefault(laptop => laptop.Id == Laptop2);
      ViewBag.Laptop1 = DataBase.LaptopSelectList;
      ViewBag.Laptop2 = DataBase.LaptopSelectList;
      ViewData["HideBorder"] = true;

      if (laptop1 is null || laptop2 is null)
      {
        ViewData["UserMessage"] = "You must select two laptop models to compare.";
        return View(null);
      }

      if (laptop1 == laptop2)
      {
        ViewData["UserMessage"] = "Please select two different laptops to compare.";
        return View(null);
      }

      return View(new List<Laptop> { laptop1, laptop2 });
    }

    public IActionResult Info(int Product)
    {
      Laptop productToShow = DataBase.Laptops.FirstOrDefault(laptop => laptop.Id == Product);

      if (productToShow == null)
      {
        ViewData["UserMessage"] = "There is no product that matches the id given. Please refresh the page and try again.";
      }

      return View(productToShow);
    }
  }
}
