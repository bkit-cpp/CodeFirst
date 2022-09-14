using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace CodeFirst.Controllers
{
    public class ProductsController : Controller
    {
        private EFCodeFirstEntities cfef=new EFCodeFirstEntities();
        // GET: Products
        public ActionResult Index()
        {
            return View(cfef.myproducts.ToList());
        }
        public ActionResult Details(int ?id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products pd = cfef.myproducts.Find(id);
            if(pd==null)
            {
                return HttpNotFound();
            }
            return View(pd);
        }
        //GET:Products/Create
      
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include ="ID,ProductName,price,Qty,Remarks")] Products pd)
        {
            if(ModelState.IsValid)
            {
                cfef.myproducts.Add(pd);
                cfef.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pd);

        }
       
        public ActionResult Edit(int ?id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products pd = cfef.myproducts.Find(id);
            if(pd==null)
            {
                return HttpNotFound();
            }
            return View(pd);

        }
        [HttpPost]
        public ActionResult Edit([Bind(Include ="ID,ProductName,price,Qty,Remarks")] Products pd)
        {
            if(ModelState.IsValid)
            {
                cfef.Entry(pd).State = EntityState.Modified;
                cfef.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pd);
        }
        public ActionResult Delete(int ?id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products pd = cfef.myproducts.Find(id);
            if (pd == null)
            {
                return HttpNotFound();
            }
            return View(pd);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Products pd = cfef.myproducts.Find(id);
            cfef.myproducts.Remove(pd);
            cfef.SaveChanges();
            return RedirectToAction("Index");

        }
        
    }
}