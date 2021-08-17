using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopSupplier.Models
{
  public static class Admin
  {
    public static void AddBrandToDatabase(string brand)
    {
      new Brand(brand);
    }

    public static void AddLaptopToDatabase(string model, Brand brand, double price, int year)
    {
      new Laptop(model, brand, price, year, "");
    }

    public static string ValidateLaptopInformation(string brand, string model, double price, int year)
    {
      Laptop duplicate;

      if (string.IsNullOrEmpty(model))
      {
        return "The model name cannot be empty.";
      }

      if (price < 1)
      {
        return "The price must be a positive number.";
      }

      if (year < 1981)
      {
        return "Laptops did not exist in that year.";
      }

      if (year > DateTime.Now.Year)
      {
        return "You cannot add a laptop from the future.";
      }

      duplicate = DataBase.Laptops.Where(laptop => laptop.Model.ToUpper() == model.ToUpper())
  .Where(laptop => laptop.Brand.Name.ToUpper() == brand.ToUpper())
  .Where(laptop => laptop.Year == year)
  .FirstOrDefault();

      if (duplicate != null)
      {
        return "There is already a laptop in the database that matched that information. If you meant to change the price please use the proper interface.";
      }

      return "valid";
    }
  }
}
