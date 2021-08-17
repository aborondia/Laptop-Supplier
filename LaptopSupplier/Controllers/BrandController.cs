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
  public class BrandController : Controller
  {
    public IActionResult Index()
    {
      if (DataBase.Brands.Count <= 0)
      {
        ViewData["UserMessage"] = new HtmlString("<span class=text-danger>There are no brands in the database.</span>");
        return View();
      }

      IEnumerable<Brand> brands = DataBase.Brands.OrderBy(brand => brand.Name);
      ViewBag.Brand = DataBase.BrandSelectList;

      return View(brands);
    }

    public IActionResult Specific(string Brand)
    {
      ViewBag.Brand = DataBase.BrandSelectList;
      ViewBag.StartYear = DataBase.YearSelectList;
      ViewBag.EndYear = DataBase.YearSelectList;
      ViewBag.SortCriteria = DataBase.SortSelectList;
      ViewBag.FilterDisplay = new List<string> { "None" };
      ViewData["BrandName"] = Brand;
      ViewData["ShowBrandFilter"] = true;

      return View(DataBase.Laptops.Where(laptop => laptop.Brand.Name == Brand));
    }

    [HttpPost]
    public IActionResult Specific(string Brand, int NumberToShow, double MinPrice, double MaxPrice, SortCriteria SortCriteria, int StartYear, int EndYear)
    {
      IEnumerable<Laptop> laptopsByBrand = SortFilter.GetFilteredList(Brand, MinPrice, MaxPrice, StartYear, EndYear);
      laptopsByBrand = SortFilter.GetSortedList(laptopsByBrand, SortCriteria);
      ViewBag.Brand = DataBase.BrandSelectList;
      ViewBag.EndYear = DataBase.YearSelectList;
      ViewBag.StartYear = DataBase.YearSelectList;
      ViewBag.SortCriteria = DataBase.SortSelectList;
      ViewBag.FilterDisplay = SortFilter.GetFilterDisplayList(NumberToShow, MinPrice, MaxPrice, SortCriteria, StartYear, EndYear);
      ViewData["BrandName"] = Brand;
      ViewData["ShowBrandFilter"] = true;

      if (laptopsByBrand.Count() <= 0)
      {
        ViewData["UserMessage"] = "There are no products that match your criteria. Please try again.";
      }

      if (NumberToShow > 0)
      {
        laptopsByBrand = laptopsByBrand.Take(NumberToShow);
      }

      return View(laptopsByBrand);
    }
  }
}
