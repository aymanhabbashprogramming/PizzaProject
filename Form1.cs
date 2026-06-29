using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();    
        }



        int CalculateSizePrice()
        {
            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return Convert.ToInt32(rbSmall.Tag);
            }

            if (rbMedium.Checked)
            {
                lblSize.Text = "Medium";
                return Convert.ToInt32(rbMedium.Tag);
            }

            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return Convert.ToInt32(rbLarge.Tag);
            }

            lblSize.Text = "";
            return 0;
        }

        int CalculateToppingsPrice()
        {
            int price = 0;
            string Toppings = "";

            if (chkExtraCheese.Checked)
            {
               Toppings += "Extra Cheese";
               price += Convert.ToInt32(chkExtraCheese.Tag);
            }

            if(chkMushrooms.Checked)
            {
                Toppings += ", Mushrooms";
                price += Convert.ToInt32(chkMushrooms.Tag);
            }

            if(chkTomatoes.Checked)
            {
                Toppings += ", Tomatoes";
                price += Convert.ToInt32(chkTomatoes.Tag);
            }

            if(chkOnion.Checked)
            {
                Toppings += ", Onion";
                price += Convert.ToInt32(chkOnion.Tag);
            }

            if(chkOlives.Checked)
            {
                Toppings += ", Olives";
                price += Convert.ToInt32(chkOlives.Tag);
            }

            if(chkGreenPeppers.Checked)
            {
                Toppings += ", Green Peppers";
                price += Convert.ToInt32(chkGreenPeppers.Tag);
            }

            Toppings = Toppings.TrimStart(',', ' ');

            if (Toppings== "")
            {
                Toppings = "No Toppings";
            }

            lblToppings.Text= Toppings;
            return price;
        }

        int CalculateCrustPrice()
        {
            if (rbThinCrust.Checked)
            {
                lblCrustType.Text = "Thin Crust";
                return Convert.ToInt32(rbThinCrust.Tag);
            }

            if (rbThickCrust.Checked)
            {
                lblCrustType.Text = "Thick Crust";
                return Convert.ToInt32(rbThickCrust.Tag);
            }
            lblCrustType.Text = "";
            return 0;
        }

        int CalculateEatPlacePrice()
        {
            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In";
                return Convert.ToInt32(rbEatIn.Tag);
            }

            if (rbTakeOut.Checked)
            {
                lblWhereToEat.Text = "Take Out";
                return Convert.ToInt32(rbTakeOut.Tag);
            }
            lblWhereToEat.Text = "";
            return 0;
        }

        void UpdatePriceLabel() { 
        
            int SizePrice= CalculateSizePrice();
            int ToppingPrice= CalculateToppingsPrice();
            int CrustPrice= CalculateCrustPrice();
            int EatPlacePrice= CalculateEatPlacePrice();

            double TotalPrice = SizePrice + ToppingPrice + CrustPrice + EatPlacePrice;

            lblTotalPrice.Text = TotalPrice.ToString() + " $";
        
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();

        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();

        }

        private void chkExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();

        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            rbThinCrust.Checked = false;
            UpdatePriceLabel();
        }

        void DisableFields()
        {
            grpSize.Enabled = false;
            grpToppings.Enabled = false;
            grpCrustType.Enabled = false;
            grpOrderSummary.Enabled = false;
            grpWhereToEat.Enabled = false;
        }
        void EnableFields()
        {
            grpSize.Enabled = true;
            grpToppings.Enabled = true;
            grpCrustType.Enabled = true;
            grpOrderSummary.Enabled = true;
            grpWhereToEat.Enabled = true;
        }

        void ClearLabels()
        {
            rbSmall.Checked = false;
            rbMedium.Checked = false;
            rbLarge.Checked = false;

            chkExtraCheese.Checked = false;
            chkMushrooms.Checked = false;
            chkTomatoes.Checked = false;
            chkOnion.Checked = false;
            chkOlives.Checked = false;
            chkGreenPeppers.Checked = false;

            rbThinCrust.Checked = false;
            rbThickCrust.Checked = false;
            rbEatIn.Checked = false;
            rbTakeOut.Checked = false;

            lblSize.Text = "";
            lblToppings.Text = "";
            lblCrustType.Text = "";
            lblWhereToEat.Text = "";
            lblTotalPrice.Text = "0";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to confirm this order ? ", 
                "Confirm Order",MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes) 
            {
                MessageBox.Show("Order placed successfully :-)");
                DisableFields();
            }

            else
            {
                MessageBox.Show("Order has been canceled  :-(");
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel this order? ",
               "Cancel Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Order canceled successfully.");
                ClearLabels();
                EnableFields();
            }

          
        }
    }
}
