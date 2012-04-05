using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcTmpHlprs.Models;    // AdventureWorksLT2008_DataEntities

namespace MvcTmpHlprs.Controllers {
    [HandleError]
    public class HomeController : Controller {
        AdventureWorksLT2008_DataEntities _db =
            new AdventureWorksLT2008_DataEntities();

        public Product GetProduct(int id) {
            return _db.Product.FirstOrDefault(
                d => d.ProductID == id);
        }

        // Allow Null ID
        public Product GetProductN(int? id) {

            if (id.HasValue)
                GetProduct((int)id);

            var dn = _db.Product
                .Where(c => c.ProductID > 0)
                .First();

            return dn;
        }

        public ActionResult Details(int id) {

            Product prd = GetProduct(id);

            if (prd == null) {
                ViewData["BogusID"] = id.ToString();
                return View("NotFound");
            }

            return View(prd);
        }

        public ActionResult Edit(int id) {

            Product prd = GetProduct(id);

            if (prd == null) {
                ViewData["BogusID"] = id.ToString();
                return View("NotFound");
            }

            return View(prd);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection) {

            Product prd = GetProduct(id);

            try {
                if (TryUpdateModel(prd)) {
                    _db.SaveChanges();

                    return RedirectToAction("Details", new { id = prd.ProductID });
                }
            } catch (Exception ex) {   // For Demo purpose only
                // Production apps should not display exception data.
                ViewData["EditError"] = ex.InnerException;
            }

            // For security reasons, only throw model errors in debug/development.
            // To test this, remove comments from <%= Html.Hidden("ProductID", Model.ProductID)%>
            // in ProdUsrCtl.ascx
#if DEBUG
            foreach (var modelState in ModelState.Values) {
                foreach (var error in modelState.Errors) {
                    if (error.Exception != null) {
                        throw modelState.Errors[0].Exception;
                    }
                }
            }
#endif

            return View(prd);
        }

        public ActionResult Create() {

            Product prd = new Product();
            prd.SellEndDate = DateTime.Now;
            prd.SellStartDate = DateTime.Now;
            prd.DiscontinuedDate = DateTime.Now;

            return View(prd);
        }
        // Notes Edit the .edmx file and add
        //  StoreGeneratedPattern="Computed" in the <!-- SSDL content -->
        // to rowguid and ModifiedDate

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Product prd) {

            try {
                if (TryUpdateModel(prd)) {
                    prd.ProductCategoryID = 6;   // hardcode required fields for demo only
                    prd.ProductModelID = 27;
                    prd.ProductNumber = "Test Prod #" + DateTime.Now.Second.ToString();

                    _db.AddToProduct(prd);
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
            } catch (Exception ex) {   // For Demo purpose only
                // Production apps should not display exception data.
                ViewData["EditError"] = ex.InnerException;
            }

            return View(prd);
        }

        public ActionResult Index() {
            var dn = _db.Product
                  .Where(c => c.ProductID < 715 || c.ProductID > 999);

            return View(dn);

        }

        public ActionResult About() {
            return View();
        }
    }
}
