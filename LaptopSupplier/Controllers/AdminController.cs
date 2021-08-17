using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopSupplier.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;

namespace LaptopSupplier.Controllers
{
  public class AdminController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult AddBrand()
    {
      ViewBag.Brands = DataBase.BrandSelectList;

      return View();
    }

    [HttpPost]
    public IActionResult AddBrand(string Brand)
    {
      ViewBag.Brands = DataBase.BrandSelectList;
      string brandName;

      if (string.IsNullOrEmpty(Brand))
      {
        ViewData["UserMessage"] = new HtmlString($"<span class=text-danger>The brand name cannot be empty.</span>");
        return View();
      }
      else
      {
        brandName = Brand.Trim();
      }

      if (DataBase.Brands.Any(brand => brand.Name.ToUpper() == brandName.ToUpper()))
      {
        ViewData["UserMessage"] = new HtmlString($"<span class=text-danger>There is already a brand with the name {brandName} in the database.</span>");
      }
      else
      {
        Admin.AddBrandToDatabase(brandName);
        ViewData["UserMessage"] = new HtmlString($"<span class=text-success>The brand {brandName} was successfully added to the database.</span");
      }


      return View();
    }

    public IActionResult AddLaptop()
    {
      ViewBag.Brand = DataBase.BrandSelectList;
      ViewBag.Year = DataBase.YearSelectList;

      if (DataBase.Brands.Count() <= 0)
      {
        ViewData["UserMessage"] = new HtmlString("<span class=text-danger>The brand list cannot be empty. Please add the product brand to the database and try again.</span>");
      }

      return View();
    }

    [HttpPost]
    public IActionResult AddLaptop(string Brand, string Laptop, double Price, int Year, string ManufacturerSiteURL = "")
    {
      ViewBag.Brand = DataBase.BrandSelectList;
      ViewBag.Year = DataBase.YearSelectList;
      string validationMessage = Admin.ValidateLaptopInformation(Brand, Laptop, Price, Year);
      string manufacturerSiteUrl = string.IsNullOrEmpty(ManufacturerSiteURL) ? "" : $"http://{ManufacturerSiteURL}";

      if (validationMessage == "valid")
      {
        Brand brand = DataBase.Brands.FirstOrDefault(brand => brand.Name == Brand);
        Laptop newLaptop = new Laptop(Laptop, brand, Price, Year, manufacturerSiteUrl);
        ViewData["UserMessage"] = new HtmlString($"<span class=text-success>{brand.Name} {newLaptop.Model} has been successfully added to the database.</span>");
      }
      else
      {
        ViewData["UserMessage"] = new HtmlString($"<span class=text-danger>{validationMessage}<span>");
      }

      return View();
    }

    public IActionResult RemoveBrand()
    {
      ViewBag.Brand = DataBase.BrandSelectList;

      if (DataBase.Brands.Count <= 0)
      {
        ViewData["UserMessage"] = new HtmlString("<span class=text-danger>There are no brands in the database.</span>");
      }

      return View();
    }

    [HttpPost]
    public IActionResult RemoveBrand(string Brand)
    {
      ViewBag.Brand = DataBase.BrandSelectList;

      if (DataBase.Brands.Count <= 0)
      {
        ViewData["UserMessage"] = new HtmlString("<span class=text-danger>There are no brands in the database.</span>");
      }

      if (DataBase.Brands.Any(brand => brand.Name == Brand))
      {
        DataBase.RemoveBrand(Brand);
        ViewData["UserMessage"] = new HtmlString($"<span class=text-success>{ Brand} was successfully removed from the database.</span>");
      }

      return View();
    }

    public IActionResult RemoveProduct()
    {
      ViewBag.Product = DataBase.LaptopSelectList;

      if (DataBase.Laptops.Count <= 0)
      {
        ViewData["UserMessage"] = new HtmlString("<span class=text-danger>There are no brands in the database.</span>");
      }

      return View();
    }

    [HttpPost]
    public IActionResult RemoveProduct(int Product)
    {

      ViewBag.Product = DataBase.LaptopSelectList;
      ViewData["UserMessage"] = "";

      if (DataBase.ProductIdValid(Product))
      {
        DataBase.RemoveProduct(Product);
        ViewData["UserMessage"] = new HtmlString("<span class=text-success>The product was successfully removed from the database.</span");
      }
      else
      {
        ViewData["UserMessage"] = new HtmlString("<span class=text-danger>There are no laptops in the database that match that model id. Please refresh the page and try again.</span>");
      }

      return View();
    }

  }
}
