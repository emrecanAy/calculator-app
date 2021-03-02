using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int mov;
        int movX;
        int movY;

        bool optStatus = false;
        double total = 0;
        string opt = "";

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NumberEvent(object sender, EventArgs e)
        {

            if (optStatus)
            {
                txtTotal.Clear();
            }
            optStatus = false;

            Button button = (Button)sender;
            txtTotal.Text += button.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void OptCalculate(object sender, EventArgs e)
        {
            optStatus = true;
            Button button = (Button)sender;
            string newOpt = button.Text;

            lblOperation.Text = lblOperation.Text + " " + txtTotal.Text + " " + newOpt;
            switch (opt)
            {
                case "+":
                    txtTotal.Text = (total + Double.Parse(txtTotal.Text)).ToString();
                    break;
                
                case "-":
                    txtTotal.Text = (total - Double.Parse(txtTotal.Text)).ToString();
                    break;

                case "*":
                    txtTotal.Text = (total * Double.Parse(txtTotal.Text)).ToString();
                    break;

                case "/":
                    txtTotal.Text = (total / Double.Parse(txtTotal.Text)).ToString();
                    break;

            }

            total = double.Parse(txtTotal.Text);
            txtTotal.Text = total.ToString();
            opt = newOpt;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtTotal.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtTotal.Text = "0";
            lblOperation.Text = "";
            opt = "";
            total = 0;
            optStatus = false;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            lblOperation.Text = "";
            optStatus = true;

            switch (opt)
            {
                case "+":
                    txtTotal.Text = (total + Double.Parse(txtTotal.Text)).ToString();
                    break;

                case "-":
                    txtTotal.Text = (total - Double.Parse(txtTotal.Text)).ToString();
                    break;

                case "*":
                    txtTotal.Text = (total * Double.Parse(txtTotal.Text)).ToString();
                    break;

                case "/":
                    txtTotal.Text = (total / Double.Parse(txtTotal.Text)).ToString();
                    break;

            }

            total = double.Parse(txtTotal.Text);
            txtTotal.Text = total.ToString();
            opt = "";

        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            
            if (txtTotal.Text == "0")
            {
                txtTotal.Text = "0";
            }
            else if (optStatus)
            {
                txtTotal.Text = "0";
            }

            if (!txtTotal.Text.Contains(","))
            {
                txtTotal.Text += ".";
            }

            optStatus = false;
        }
    }
}
