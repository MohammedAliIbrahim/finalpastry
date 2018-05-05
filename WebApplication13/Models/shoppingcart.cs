////this class is unused now . it was part of the previous attempts 
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace WebApplication13.Models
//{
//    public class shoppingcart
//    {

//        public string ShoppingCartId { get; set; }
//        private List<ShoppingCartItem> lineCollection = new List<ShoppingCartItem>();
//        Database1Entities db = new Database1Entities();
//        //public void AddItem(pie product, int Amount)
//        //{
//        //    ShoppingCartItem line = lineCollection
//        //        .Where(p => p.pie.Id == product.Id)
//        //        .FirstOrDefault();

//        //    if (line == null)
//        //    {
//        //        lineCollection.Add(new ShoppingCartItem
//        //        {
//        //            pie = product,
//        //           Amount = Amount
//        //        });
//        //    }
//        //    else
//        //    {
//        //        line.Amount += Amount;
//        //    }
//        //}



//        public void RemoveLine(pie product)
//        {
//            lineCollection.RemoveAll(l => l.pie.Id == product.Id);
//        }

//        public int? ComputeTotalValue()
//        {
//            return lineCollection.Sum(e => e.pie.prce * e.Amount);

//        }
//        public void Clear()
//        {
//            lineCollection.Clear();
//        }

//        public IEnumerable<ShoppingCartItem> Lines
//        {
//            get { return lineCollection; }
//        }






//        //private Database1Entities db = new Database1Entities();
//        //private readonly Database1Entities _appDbContext;
//        //private shoppingcart(Database1Entities appDbContext)
//        //{
//        //    _appDbContext = appDbContext;
//        //}

//        //public string ShoppingCartId { get; set; }

//        //public List<ShoppingCartItem> ShoppingCartItems { get; set; }

//        //public static shoppingcart GetCart(IServiceProvider services)
//        //{
//        //    ISession session = services.GetRequiredService<IHttpContextAccessor>()?
//        //        .HttpContext.Session;

//        //    var context = services.GetService<AppDbContext>();
//        //    string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

//        //    session.SetString("CartId", cartId);

//        //    return new ShoppingCartItem(context) { ShoppingCartId = cartId };
//        //}


      

//        public void Add(pie pie, int amount)
//        {
//            var shoppingCartItem =
//                    db.ShoppingCartItem.SingleOrDefault(
//                        s => s.pie.Id == pie.Id && s.ShoppingCartId == ShoppingCartId);

//            if (shoppingCartItem == null)
//            {
//                shoppingCartItem = new ShoppingCartItem
//                {
//                    ShoppingCartId = ShoppingCartId,
//                    pieid = pie.Id,
//                    Amount = 1
//                };

//                db.ShoppingCartItem.Add(shoppingCartItem);
//            }
//            else
//            {
//                shoppingCartItem.Amount++;
//            }
//            db.SaveChanges();
//        }
//    }
//    //public int RemoveFromCart(pie pie)
//    //{
//    //    var shoppingCartItem =
//    //            _appDbContext.ShoppingCartItem.SingleOrDefault(
//    //                s => s.Pie.PieId == pie.Id && s.ShoppingCartId == ShoppingCartId);

//    //    var localAmount = 0;

//    //    if (shoppingCartItem != null)
//    //    {
//    //        if (shoppingCartItem.Amount > 1)
//    //        {
//    //            shoppingCartItem.Amount--;
//    //            localAmount = shoppingCartItem.Amount;
//    //        }
//    //        else
//    //        {
//    //            _appDbContext.ShoppingCartItem.Remove(shoppingCartItem);
//    //        }
//    //    }

//    //    _appDbContext.SaveChanges();

//    //    return localAmount;
//    //}

//    //public List<ShoppingCartItem> GetShoppingCartItems()
//    //{
//    //    return ShoppingCartItems ??
//    //           (ShoppingCartItems =
//    //               _appDbContext.ShoppingCartItem.Where(c => c.ShoppingCartId == ShoppingCartId)
//    //                   .Include(s => s.Pie)
//    //                   .ToList());
//    //}

//    //public void ClearCart()
//    //{
//    //    var cartItems = _appDbContext
//    //        .ShoppingCartItem
//    //        .Where(cart => cart.ShoppingCartId == ShoppingCartId);

//    //    _appDbContext.ShoppingCartItem.RemoveRange(cartItems);

//    //    _appDbContext.SaveChanges();
//    //}



//    //public decimal GetShoppingCartTotal()
//    //{
//    //    var total = _appDbContext.ShoppingCartItem.Where(c => c.ShoppingCartId == ShoppingCartId)
//    //        .Select(c => c.pie.prce * c.Amount).Sum();
//    //    return total;
//    //}
//}



    
