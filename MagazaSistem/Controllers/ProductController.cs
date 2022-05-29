using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaSistem.Controllers
{
    public class ProductController : Controller
    {
        MagazaSistemContext db = new MagazaSistemContext();
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = db.Product.Where(x => x.ProductStatus == true).ToList();
            

            
            
            return View(products);
        }

        public ActionResult Delete(int id) {

            Product products = db.Product.Find(id);
            products.ProductStatus = false;
            db.SaveChanges();
            return RedirectToAction("index");
        }



        [HttpGet]
        public ActionResult Add() {
            /*Kategori*/
            List<SelectListItem> category = db.Category.AsNoTracking().Where(x => x.CategoryStatus == true)
                .Select(s => new SelectListItem
                {
                    Value = s.CategoryId.ToString(),
                    Text = s.CategoryName

                }).ToList();

            /*Alt Kategori*/
            List<SelectListItem> subcategory = db.Subcategory.AsNoTracking().Where(x => x.SubcategoryStatus == true)
                     .Select(s => new SelectListItem
                     {
                         Value = s.SubcategoryId.ToString(),
                         Text = s.SubcategoryName

                     }).ToList();

            /*Marka*/
            List<SelectListItem> brands = db.Brand.AsNoTracking().Where(x => x.BrandStatus == true)
                .Select(s => new SelectListItem
                {
                    Value = s.BrandId.ToString(),
                    Text = s.BrandName

                }).ToList();

            /*Renk*/
            List<SelectListItem> colors = db.Color.AsNoTracking().Where(x => x.ColorStatus == true)
                .Select(s => new SelectListItem
                {
                    Value = s.ColorId.ToString(),
                    Text = s.ColorName

                }).ToList();

            ViewBag.Categories = category;
            ViewBag.Subcategories = subcategory;
            ViewBag.Brands = brands;
            ViewBag.Colors = colors;
            return View();

        }

        [HttpPost]
        public ActionResult Add(Product product){
            product.ProductStatus = true;
            Product products = new Product();
            products.ProductStatus = product.ProductStatus;
            products.ProductName = product.ProductName;
            products.ProductStockCode = product.ProductStockCode;
            products.ProductStockAmount = product.ProductStockAmount;
            products.ProductPrice = product.ProductPrice;
            products.ProductBarcode = product.ProductBarcode;
            products.ProductDiscountedPrice = product.ProductDiscountedPrice;
            products.ProductStatus = product.ProductStatus;
            products.ProductPurchasePrice = product.ProductPurchasePrice;

            products.Brand = db.Brand.Find(product.BrandId);
            products.Category = db.Category.Find(product.CategoryId);
            products.Subcategory = db.Subcategory.Find(product.SubcategoryId);
            products.Color = db.Color.Find(product.ColorId);

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                
                string yol = "~/Image/" + dosyaadi ;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                product.ProductImage = "/Image/" + dosyaadi;

            }
          
            db.Product.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }





        [HttpGet]
        public ActionResult Update(int id)
        {
            Product products = db.Product.Find(id);
            /*Kategori*/
            List<SelectListItem> category = db.Category.AsNoTracking().Where(x => x.CategoryStatus == true)
                .Select(s => new SelectListItem
                {
                    Value = s.CategoryId.ToString(),
                    Text = s.CategoryName

                }).ToList();

            /*Alt Kategori*/
            List<SelectListItem> subCategory = db.Subcategory.AsNoTracking().Where(x => x.SubcategoryStatus == true)
                .Select(s => new SelectListItem
                {
                    Value = s.SubcategoryId.ToString(),
                    Text = s.SubcategoryName

                }).ToList();

            /*Marka*/
            List<SelectListItem> brands = db.Brand.AsNoTracking().Where(x => x.BrandStatus == true)
                .Select(s => new SelectListItem
                {
                    Value = s.BrandId.ToString(),
                    Text = s.BrandName

                }).ToList();

            /*Renk*/
            List<SelectListItem> colors = db.Color.AsNoTracking().Where(x => x.ColorStatus == true)
                .Select(s => new SelectListItem
                {
                    Value = s.ColorId.ToString(),
                    Text = s.ColorName

                }).ToList();

            ViewBag.Categories = category;
            ViewBag.SubCateries = subCategory;
            ViewBag.Brands = brands;
            ViewBag.Colors = colors;
            return View(products);

        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            Product products = db.Product.Find(product.ProductId);
            product.ProductStatus = true;
            
            products.ProductStatus = product.ProductStatus;
            products.ProductName = product.ProductName;
            products.ProductStockCode = product.ProductStockCode;
            products.ProductStockAmount = product.ProductStockAmount;
            products.ProductPrice = product.ProductPrice;
            products.ProductBarcode = product.ProductBarcode;
            products.ProductDiscountedPrice = product.ProductDiscountedPrice;
            products.ProductStatus = product.ProductStatus;
            products.ProductPurchasePrice = product.ProductPurchasePrice;

            products.Brand = db.Brand.Find(product.BrandId);
            products.Category = db.Category.Find(product.CategoryId);
            products.Subcategory = db.Subcategory.Find(product.SubcategoryId);
            products.Color = db.Color.Find(product.ColorId);

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                product.ProductImage = "/Image/" + dosyaadi + uzanti;

            }

            
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}