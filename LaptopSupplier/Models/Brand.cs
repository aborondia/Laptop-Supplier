using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopSupplier.Models
{
  public class Brand
  {
    private string _name;
    private List<Laptop> _laptops;

    public string Name { get => this._name; }
    public List<Laptop> Laptops { get => this._laptops; }

    public Brand(string brand)
    {
      this._name = brand;
      this._laptops = new List<Laptop>();

      DataBase.Brands.Add(this);
    }
  }
}
