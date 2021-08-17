using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSupplier.Models
{
  public class Laptop
  {
    private static int _laptopIdAssigner = 1;
    private int _id;
    private string _model;
    private Brand _brand;
    private double _price;
    private int _year;
    private string _manufacturerDetails;

    public int Id { get => this._id; }
    public string Model { get => this._model; }
    public Brand Brand { get => this._brand; }
    public double Price { get => this._price; }
    public string FormattedPrice
    {
      get
      {
        StringBuilder formattedPrice = new StringBuilder(Math.Round(this._price, 2).ToString());
        int charCounter = 0;

        for (int i = formattedPrice.Length - 1; i > 0; i--)
        {
          if (formattedPrice[i] == '.')
          {
            charCounter = 0;
            continue;
          }

          charCounter++;

          if (charCounter == 3 && i != 0)
          {
            formattedPrice.Insert(i, ',');
            charCounter = 0;
          }
        }

        return formattedPrice.ToString();
      }
    }
    public int Year { get => this._year; }
    public string ManufacturerDetails { get => this._manufacturerDetails; }

    public Laptop(string model, Brand brand, double price, int year, string manufacturerDetails)
    {
      this._id = _laptopIdAssigner++;
      this._model = model;
      this._brand = brand;
      this._price = price;
      this._year = year;
      this._manufacturerDetails = manufacturerDetails;

      brand.Laptops.Add(this);
      DataBase.Laptops.Add(this);
    }
  }
}
