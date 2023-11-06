using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Deseni
{
    public class Program
    {
        static void Main(string[] args)
        {
            PoductDirector director = new PoductDirector();
            var Builder = new NewCustomerProductBuilder();
            director.GenerateProduct(Builder);

            var model = Builder.GetModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.DiscountPrice);
            Console.WriteLine(model.DiscountApplied);

            Console.ReadLine();
        }
    }
    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool DiscountApplied { get; set; }
        public decimal DiscountPrice { get; set; }
    }
      abstract class ProductBuildir
    {
        // BASE SINIF 
        public abstract void ProductData(); // Data Bilgisini Almak İçin 
        public abstract void ApplyDiscount();// İndirim Bilgilerini 
        public abstract ProductViewModel GetModel(); // Çalışılacak olan Müşteri Türünü Belirtmek İçin 
    }
    class NewCustomerProductBuilder : ProductBuildir // Yeni Müşteri için 
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {

            model.DiscountPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void ProductData()
        {
            model.Id = 1;
            model.CategoryName = "Elektironik";
            model.ProductName = "Laptop";
            model.UnitPrice = 2500;
            
        }
    }
    class OldCustomerProductBuilder : ProductBuildir // Eski Müşteri İçin 
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountPrice = model.UnitPrice;
            model.DiscountApplied = false;

        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void ProductData()
        {
            model.Id = 1;
            model.CategoryName = "Elektironik";
            model.ProductName = "Laptop";
            model.UnitPrice = 2500;
        }
    }
    class PoductDirector
    {
        public void GenerateProduct(ProductBuildir productBuildir)
        {
            productBuildir.ProductData();
            productBuildir.ApplyDiscount();
            
        }
    }
}
