using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunchOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const decimal SalesTaxPct = 0.0775m;
        decimal priceForBurger = 6.95m;
        decimal priceForPizza = 5.95m;
        decimal priceForSalad = 4.95m;
        decimal AddOnForItems = .75m;



        ////private void MainCourse_CheckedChanged(object sender, EventArgs e)
        ////{
        ////...
        ////       }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (rdoHamburger.Checked == true)
            {
                GetBurgerPrice();
            }
            if (rdoPizza.Checked == true)
            {
                GetPizzaPrice();
            }
            if (rdoSalad.Checked == true)
            {
                GetSaladPrice();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            rdoHamburger.Checked = true;

        }

        private void ChangeAddOns(object sender, EventArgs e)
        {
            ClearAddOns();
            ClearTotals();
            if (rdoPizza.Checked == true)
            {
                chkVeggies.Text = "Pepperoni";
                chkSauces.Text = "Sausage";
                chkFrenchFries.Text = "Olives";

            }
            else if (rdoSalad.Checked == true)
            {
                chkVeggies.Text = "Croutons";
                chkSauces.Text = "Bacon bits";
                chkFrenchFries.Text = "Bread sticks";

            }
            else
            {
                chkVeggies.Text = "Lettuce, tomatoes, and onions";
                chkSauces.Text = "Ketchup, mustard, and mayo";
                chkFrenchFries.Text = "French fries";
            }
        }
        private void ClearTotals()
        {

            lblSubtotal.Text = "";
            lblSalesTax.Text = "";
            lblOrderTotal.Text = "";

        }
        private void ClearAddOns()
        {
            chkFrenchFries.Checked = false;
            chkSauces.Checked = false;
            chkVeggies.Checked = false;
        }

        private void GetBurgerPrice()
        {
            if (chkFrenchFries.Checked == true)
            {
                priceForBurger += AddOnForItems;
            }
            if (chkSauces.Checked == true)
            {
                priceForBurger += AddOnForItems;
            }
            if (chkVeggies.Checked == true)
            {
                priceForBurger += AddOnForItems;
                
            }
            decimal saleTax = Tax(priceForBurger);
            lblSalesTax.Text = saleTax.ToString("c2");
            lblSubtotal.Text = priceForBurger.ToString("c2");

            decimal orderTotal = saleTax + priceForBurger;
            lblOrderTotal.Text = orderTotal.ToString("c2");
        }
        private void GetPizzaPrice()
        {
            if (chkFrenchFries.Checked == true)
            {
                priceForPizza += AddOnForItems;
            }
            if (chkSauces.Checked == true)
            {
                priceForPizza += AddOnForItems;
            }
            if (chkVeggies.Checked == true)
            {
                priceForPizza += AddOnForItems;
                
            }
            decimal saleTax = Tax(priceForPizza);
            lblSalesTax.Text = saleTax.ToString("c2");
            lblSubtotal.Text = priceForPizza.ToString("c2");

            decimal orderTotal = saleTax + priceForPizza;
            lblOrderTotal.Text = orderTotal.ToString("c2");
        }
        private void GetSaladPrice()
        {
            if (chkFrenchFries.Checked == true)
            {
                priceForSalad += AddOnForItems;
            }
            if (chkSauces.Checked == true)
            {
                priceForSalad += AddOnForItems;
            }
            if (chkVeggies.Checked == true)
            {
                priceForSalad += AddOnForItems;
            }
            decimal saleTax = Tax(priceForSalad);
            lblSalesTax.Text = saleTax.ToString("c2");
            lblSubtotal.Text = priceForSalad.ToString("c2");

            decimal orderTotal = saleTax + priceForSalad;
            lblOrderTotal.Text = orderTotal.ToString("c2");
        }
        private decimal Tax(decimal price)
        {
            decimal saleTaxAmount = price * SalesTaxPct;
            return saleTaxAmount;
        }
    }
}