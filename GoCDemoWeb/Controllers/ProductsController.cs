using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoCDemoLibrary.DataAccess;
using GoCDemoLibrary.Models;
using GoCDemoWeb.Models;

namespace GoCDemoWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDataContext _context;

        public ProductsController(ProductDataContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(string productType, string sortOrder)
        {
            //Filter by Category
            var ProductTypeList = new List<string>();

            //Get all available Product Types values ordered by Product Type Name
            var query = from d in _context.ProductTypes
                           orderby d.ProductTypeName
                           select d.ProductTypeName;

            //Populate the List with values and make it available for View
            ProductTypeList.AddRange(query);
            ViewBag.productType = new SelectList(ProductTypeList);

            //Taken from MS Docs
            //sortOrder string is coming from page query.
            //First page load sortOrder is null, so the products will be sorted by name in ascending order as
            //default in the switch statement.
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "ProductName_desc" : "";
            ViewData["PriceSortParam"] = sortOrder == "ProductPrice" ? "ProductPrice_desc" : "ProductPrice";


            var products = from p in _context.Products
                           select p;

            //Filter products by selected value from ProductTypeList
            if (!string.IsNullOrEmpty(productType))
            {
                products = products.Where(p => p.ProductTypeName == productType);
            }

            switch (sortOrder)
            {
                case "ProductName_desc":
                    products = products.OrderByDescending(p => p.ProductName);
                    break;
                case "ProductPrice_desc":
                    products = products.OrderByDescending(p => p.ProductPrice);
                    break;
                case "ProductPrice":
                    products = products.OrderBy(p => p.ProductPrice);
                    break;
                default:
                    products = products.OrderBy(p => p.ProductName);
                    break;
            }

            return View(await products.ToListAsync());
        }


        // GET: Products/Details/name
        public async Task<IActionResult> Details(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductNameSlug == name);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Products/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ProductName,ProductDescription,ProductImage,ProductPrice,ProductTypeName")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(product);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //// GET: Products/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);
        //}

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,ProductDescription,ProductImage,ProductPrice,ProductTypeID")] Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //// GET: Products/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.Id == id);
        //}
    }
}
