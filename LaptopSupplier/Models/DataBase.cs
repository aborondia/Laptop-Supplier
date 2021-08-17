using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopSupplier.Models
{
  public enum SortCriteria
  {
    None,
    HighToLow,
    LowToHigh,
    NewToOld,
    OldToNew,
  }

  public class DataBase
  {
    private static List<Laptop> _laptops;
    private static List<Brand> _brands;

    public static List<Brand> Brands { get => _brands; }
    public static List<Laptop> Laptops { get => _laptops; }
    public static SelectList BrandSelectList { get => new SelectList(_brands.OrderBy(brand => brand.Name), "Name", "Name"); }
    public static SelectList LaptopSelectList { get => new SelectList(_laptops.OrderBy(laptop => laptop.Model), "Id", "Model"); }
    public static SelectList YearSelectList
    {
      get
      {
        List<int> years = new List<int>();

        for (int i = 1981; i <= DateTime.Now.Year; i++)
        {
          years.Add(i);
        }

        return new SelectList(years);
      }
    }
    public static SelectList SortSelectList { get => new SelectList(Enum.GetValues(typeof(SortCriteria))); }

    public static void InitializeData()
    {
      _laptops = new List<Laptop>();
      _brands = new List<Brand>();

      Brand dell = new Brand("Dell");
      Brand mac = new Brand("Mac");
      Brand google = new Brand("Google");
      Brand acer = new Brand("Acer");
      Brand asus = new Brand("Asus");
      Brand lenovo = new Brand("Lenovo");
      Brand philips = new Brand("Philips");

      Laptop dell1 = new Laptop("New Inspiron 15 3000", dell, 448.99, 2018, "https://www.dell.com/en-ca/shop/dell-laptops/new-inspiron-15-3000-laptop/spd/inspiron-15-3510-laptop/ni153510_sb_s4103e");
      Laptop dell2 = new Laptop("New Inspiron 14", dell, 779.99, 2019, "https://www.dell.com/en-ca/shop/dell-laptops/new-inspiron-14/spd/inspiron-14-5410-laptop/ni145410_s103e");
      Laptop dell3 = new Laptop("XPS 13", dell, 1149.99, 2019, "https://www.dell.com/en-ca/shop/dell-laptops/xps-13-laptop/spd/xps-13-9305-laptop/nxps139305_h10e");
      Laptop dell4 = new Laptop("XPS 15", dell, 1549.99, 2021, "https://www.dell.com/en-ca/shop/dell-laptops/xps-15-laptop/spd/xps-15-9500-laptop/nxps159500_s01e");
      Laptop dell5 = new Laptop("New Dell G15 Gaming Laptop", dell, 1048.99, 2020, "https://www.dell.com/en-ca/shop/gaming-laptops/new-dell-g15-gaming-laptop/spd/g-series-15-5510-laptop/ng155510_sb_ls60e");
      Laptop mac1 = new Laptop("Apple M1 Chip with 8-Core CPU and 7-Core GPU 256 GB Storage", mac, 1299, 2020, "https://www.apple.com/ca/shop/buy-mac/macbook-air");
      Laptop mac2 = new Laptop("Apple M1 Chip with 8-Core CPU and 8-Core GPU 512 GB Storage", mac, 1649, 2020, "https://www.apple.com/ca/shop/buy-mac/macbook-air");
      Laptop mac3 = new Laptop("Apple M1 Chip with 8-Core CPU and 8-Core GPU 256 GB Storage", mac, 1699, 2020, "https://www.apple.com/ca/shop/buy-mac/macbook-pro/13-inch");
      Laptop mac4 = new Laptop("2.6GHz 6-Core Processor 512 GB Storage AMD Radeon Pro 5300M", mac, 2999, 2020, "https://www.apple.com/ca/shop/buy-mac/macbook-pro/16-inch");
      Laptop google1 = new Laptop("Google Pixelbook Go", google, 1349.99, 2019, "https://www.google.com/intl/en_ca/chromebook/device/google-pixelbook-go-8gb-128gb/");
      Laptop acer1 = new Laptop("Acer Chromebook 314", acer, 349.99, 2021, "https://www.google.com/intl/en_ca/chromebook/device/acer-chromebook-314/");
      Laptop acer2 = new Laptop("Acer Chromebook Spin 311", acer, 399.99, 2020, "https://www.google.com/intl/en_ca/chromebook/device/acer-chromebook-spin-311-2019/");
      Laptop asus1 = new Laptop("ASUS Chromebook Flip C436", asus, 1299.99, 2020, "https://www.google.com/intl/en_ca/chromebook/device/asus-chromebook-flip-c436-512gb/");
      Laptop lenovo1 = new Laptop("IdeaPad Gaming 3i (15” Intel) Laptop", lenovo, 959.99, 2020, "https://www.lenovo.com/ca/en/laptops/ideapad/ideapad-gaming-laptops/IdeaPad-Gaming-3i-Gen-6-15-Intel/p/WMD00000451");
      Laptop lenovo2 = new Laptop("Yoga C940 14” 2 in 1", lenovo, 1520.99, 2019, "https://www.lenovo.com/ca/en/laptops/yoga/yoga-2-in-1-series/Lenovo-Yoga-C940-14IIL/p/88YGC901221");
      Laptop lenovo3 = new Laptop("ThinkPad X13 Gen 2 (13” AMD) Laptop", lenovo, 2749, 2021, "https://www.lenovo.com/ca/en/laptops/thinkpad/thinkpad-x/X13-AMD-G2/p/22TPX13X3A1");
      Laptop philips1 = new Laptop("Philips 15NB5800", philips, 120, 2008, "");
      Laptop philips2 = new Laptop("Philips X200 laptop", philips, 100, 2007, "");
    }

    public static void RemoveBrand(string brandName)
    {
      Brand brandToRemove = _brands.FirstOrDefault(brand => brand.Name == brandName);

      if (brandToRemove != null)
      {
        foreach (Laptop laptop in brandToRemove.Laptops)
        {
          _laptops.Remove(laptop);
        }

        _brands.Remove(brandToRemove);
      }
    }

    public static bool ProductIdValid(int productId)
    {
      if (_laptops.Any(laptop => laptop.Id == productId))
      {
        return true;
      }

      return false;
    }

    public static void RemoveProduct(int productId)
    {
      Laptop laptopToRemove = _laptops.FirstOrDefault(laptop => laptop.Id == productId);

      laptopToRemove.Brand.Laptops.Remove(laptopToRemove);
      _laptops.Remove(laptopToRemove);
    }
  }
}
