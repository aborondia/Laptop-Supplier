using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopSupplier.Models;

namespace LaptopSupplier.Library
{
  public static class SortFilter
  {
    public static IEnumerable<Laptop> GetSortedList(IEnumerable<Laptop> list, SortCriteria sortCriteria)
    {
      switch (sortCriteria)
      {
        case SortCriteria.NewToOld:
          return list.OrderByDescending(laptop => laptop.Year);
        case SortCriteria.OldToNew:
          return list.OrderBy(laptop => laptop.Year);
        case SortCriteria.HighToLow:
          return list.OrderByDescending(laptop => laptop.Price);
        case SortCriteria.LowToHigh:
          return list.OrderBy(laptop => laptop.Price);
      }

      return list.OrderBy(laptop => laptop.Brand.Name);
    }

    public static IEnumerable<Laptop> GetFilteredList(string brand, double minPrice, double maxPrice, int startYear, int endYear)
    {
      IEnumerable<Laptop> laptops = DataBase.Laptops.Where(laptop => laptop.Brand.Name == brand);

      if (startYear > 0)
      {
        laptops = laptops.Where(laptop => laptop.Year >= startYear);
      }

      if (endYear > 0)
      {
        laptops = laptops.Where(laptop => laptop.Year <= endYear);
      }

      if (minPrice > 0)
      {
        laptops = laptops.Where(laptop => laptop.Price >= minPrice);
      }

      if (maxPrice > 0)
      {
        laptops = laptops.Where(laptop => laptop.Price <= maxPrice);
      }

      return laptops;
    }

    public static IEnumerable<Laptop> GetFilteredList(double minPrice, double maxPrice, int startYear, int endYear)
    {
      IEnumerable<Laptop> laptops = DataBase.Laptops;

      if (startYear > 0)
      {
        laptops = laptops.Where(laptop => laptop.Year >= startYear);
      }

      if (endYear > 0)
      {
        laptops = laptops.Where(laptop => laptop.Year <= endYear);
      }

      if (minPrice > 0)
      {
        laptops = laptops.Where(laptop => laptop.Price >= minPrice);
      }

      if (maxPrice > 0)
      {
        laptops = laptops.Where(laptop => laptop.Price <= maxPrice);
      }

      return laptops;
    }

    public static List<string> GetFilterDisplayList(int numberToShow, double minPrice, double maxPrice, SortCriteria sortCriteria, int startYear, int endYear)
    {
      List<string> filters = new List<string>();

      if (sortCriteria != SortCriteria.None)
      {
        filters.Add($"Sort: {sortCriteria}");
      }

      if (minPrice > 0)
      {
        filters.Add($"MinPrice: ${Math.Round(minPrice, 2)}");
      }

      if (maxPrice > 0)
      {
        filters.Add($"Max Price: ${Math.Round(maxPrice, 2)}");
      }

      if (startYear > 0)
      {
        filters.Add($"Min Year: {startYear}");
      }

      if (endYear > 0)
      {
        filters.Add($"Max Year: {endYear}");
      }

      if (numberToShow > 0)
      {
        filters.Add($"Number of Items to Display: {numberToShow}");
      }

      if (filters.Count <= 0)
      {
        filters.Add("None");
      }

      return filters;
    }
  }
}
