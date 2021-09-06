using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SweetsShop.Models
{
    public class item
    {



        private pie product = new pie(); // Instantiate tblProduct class object 

        #region Properties
        public pie Product
        {
            get { return product; }
            set { product = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        #endregion

        #region Constructors
        // Default constructor
        public item()
        {

        }

        // Parameterised constructor
        public item(pie product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }
        #endregion


    }
}