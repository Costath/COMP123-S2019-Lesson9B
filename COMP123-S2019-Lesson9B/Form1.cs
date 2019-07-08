﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_Lesson9B
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Thisi is the shared Event Handler for all the calculator buttons - Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            var TheButton = sender as Button; //'as' keyword "shapes" the sender as a Button object

            int buttonValue;
            bool resultCondition = int.TryParse(TheButton.Text, out buttonValue);

            if (resultCondition)
            {
                ResultLabel.Text += TheButton.Text;
            }
            else
            {
                ResultLabel.Text = "Not a number";
            }
        }
    }
}
