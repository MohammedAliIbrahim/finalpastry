using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SweetsShop.Models;

namespace SweetsShop.Controllers
{
    public class ShoppingCartItemsController : Controller
    {


        private Database1Entities de = new Database1Entities();

        // private dbe de = new DemoDBEntities(); // Accessing relative path from connection string.

        #region Is product in the cart Method
        private int isExisting(int id)
        {
            List<item> cart = (List<item>)Session["cart"]; // Put all the items from the "Session["cart"] into the list cart

            for (int i = 0; i < cart.Count; i++)

                if (cart[i].Product.Id == id) // If the cart contains the product those ID is provided 

                    return i; // Then return the number of Products in the cart

            return -1; // Else return -1
        }
        #endregion

        #region Delete Action
        public ActionResult Delete(int id)
        {
            int index = isExisting(id); // index = Product ID from in the Cart only

            List<item> cart = (List<item>)Session["cart"];

            cart.RemoveAt(index); // Remove product based on the Product ID provided.


            Session["cart"] = cart; // Update Session["cart"]

            return View("Cart");
        }
        #endregion

        #region Order Now Action
        public ActionResult OrderNow(int id)
        {

            if (Session["cart"] == null)
            {
                List<item> cart = new List<item>();

                cart.Add(new item(de.pie.Find(id), 1)); // Add 1 Product based on id provided

                Session["cart"] = cart; // Update Session["cart"]
            }
            else
            {
                List<item> cart = (List<item>)Session["cart"];

                int index = isExisting(id); // index = Product ID from in the Cart only

                if (index == -1) // If the product to be order is not already in the cart

                    cart.Add(new item(de.pie.Find(id), 1)); // Add 1 Product based on id provided

                else // if product already exists in the cart

                    cart[index].Quantity++; // increase the quantity of the product based on the ID provided

                Session["cart"] = cart; // Update Session["cart"]
            }

            return View("Cart");
        }

        //private Database1Entities repository = new Database1Entities();

        //  shoppingcart shoppingCart = new shoppingcart();

        ////public ShoppingCartItemsController(Database1Entities repo)
        ////{
        ////    repository = repo;
        ////    //orderProcessor = proc;
        ////}

        //public ShoppingCartItemsController()
        //{

        //}
        //public ViewResult Index()
        //{
        //    shoppingCart = GetShoppingCartItems();


        //    var shoppingCartViewModel = new ShoppingCartViewModel
        //    {
        //        ShoppingCart = shoppingCart,
        //        ShoppingCartTotal = shoppingCart.ComputeTotalValue()
        //    };

        //    return View(shoppingCartViewModel);
        //}


        //public shoppingcart GetShoppingCartItems()
        //{
        //    shoppingcart shoppingcart = (shoppingcart)Session["cart"];
        //    if (shoppingcart == null)
        //    {
        //        shoppingcart = new shoppingcart();
        //        Session["cart"] = shoppingcart;

        //    }
        //    return shoppingcart;
        //}

        //public RedirectToRouteResult AddToCart( int? Id 
        //        )
        //{

        //    //________________________________________________________________________________
        //    //pie product = repository.pie
        //    //    .FirstOrDefault(p => p.Id == productId);

        //    pie selectedPie = repository.pie.Find(Id);
        //    //if (selectedPie == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    ////return View(pie)
        //    //pie selectedPie = new pie();
        //    //var selectedPie = repository.pie.Where(p => p.Id == Id);

        //    if (selectedPie != null)
        //    {
        //        shoppingCart.Add(selectedPie, 1);
        //    }
        //    return RedirectToAction("Index");
        //}

        //public RedirectToRouteResult RemoveFromCart( int pieId
        //        )
        //{
        //    var selectedPie = repository.pie.FirstOrDefault(p => p.Id == pieId);

        //    if (selectedPie != null)
        //    {
        //        shoppingCart.RemoveLine(selectedPie);
        //    }
        //    return RedirectToAction("Index");
        //}

        //public PartialViewResult Summary(Cart cart)
        //{
        //    return PartialView(cart);
        //}

        //public ViewResult Checkout()
        //{
        //    return View(new ShippingDetails());

        //}







        //[HttpPost]
        //public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        //{
        //    if (cart.Lines.Count() == 0)
        //    {
        //        ModelState.AddModelError("", "Sorry, your cart is empty!");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        orderProcessor.ProcessOrder(cart, shippingDetails);
        //        cart.Clear();
        //        return View("Completed");
        //    }
        //    else
        //    {
        //        return View(shippingDetails);
        //    }
        //}


        //_--------------------------------------------------------------------------------------------------------------
        //// GET: ShoppingCartItems
        //public ActionResult Index()
        //{
        //    var shoppingCartItem = db.ShoppingCartItem.Include(s => s.pie);
        //    return View(shoppingCartItem.ToList());
        //}

        //// GET: ShoppingCartItems/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ShoppingCartItem shoppingCartItem = db.ShoppingCartItem.Find(id);
        //    if (shoppingCartItem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(shoppingCartItem);
        //}

        //// GET: ShoppingCartItems/Create
        //public ActionResult Create()
        //{
        //    ViewBag.pieid = new SelectList(db.pie, "Id", "name");
        //    return View();
        //}

        //// POST: ShoppingCartItems/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ShoppingCartItemId,Amount,ShoppingCartId,pieid")] ShoppingCartItem shoppingCartItem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ShoppingCartItem.Add(shoppingCartItem);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.pieid = new SelectList(db.pie, "Id", "name", shoppingCartItem.pieid);
        //    return View(shoppingCartItem);
        //}

        //// GET: ShoppingCartItems/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ShoppingCartItem shoppingCartItem = db.ShoppingCartItem.Find(id);
        //    if (shoppingCartItem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.pieid = new SelectList(db.pie, "Id", "name", shoppingCartItem.pieid);
        //    return View(shoppingCartItem);
        //}

        //// POST: ShoppingCartItems/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ShoppingCartItemId,Amount,ShoppingCartId,pieid")] ShoppingCartItem shoppingCartItem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(shoppingCartItem).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.pieid = new SelectList(db.pie, "Id", "name", shoppingCartItem.pieid);
        //    return View(shoppingCartItem);
        //}

        //// GET: ShoppingCartItems/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ShoppingCartItem shoppingCartItem = db.ShoppingCartItem.Find(id);
        //    if (shoppingCartItem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(shoppingCartItem);
        //}

        //// POST: ShoppingCartItems/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ShoppingCartItem shoppingCartItem = db.ShoppingCartItem.Find(id);
        //    db.ShoppingCartItem.Remove(shoppingCartItem);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }


    #endregion
}