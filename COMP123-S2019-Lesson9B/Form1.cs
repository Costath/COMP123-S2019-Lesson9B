using System;
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
        public string outputString { get; set; }
        public bool decimalExists { get; set; }
        public float outputValue { get; set; }
        
        /// <summary>
        /// This is the Constructor for the Calculator Form
        /// </summary>
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
            var tag = TheButton.Tag.ToString();

            int buttonValue;
            bool resultCondition = int.TryParse(tag, out buttonValue);

            // if the user pressed a number button
            if (resultCondition)
            {
                int maxSize = 3;
                if (decimalExists)
                {
                    maxSize = 5;
                }
                if ((outputString != String.Empty) && (ResultLabel.Text.Count() < maxSize))
                {
                    outputString += tag;
                    ResultLabel.Text = outputString;
                }
            }

            // if the user pressed a button that is not a number
            if (!resultCondition)
            {
                switch (tag)
                {
                    case "clear":
                        ClearNumericKeyboard();
                        break;
                    case "back":
                        RemoveLastCharacterFromResultLabel();
                        break;
                    case "done":
                        FinalizeOutput();
                        break;
                    case "decimal":
                        AddDecimalToResultLabel();
                        break;
                }
            }
        }

        /// <summary>
        /// This method adds the decimal to the ResultLabel
        /// </summary>
        private void AddDecimalToResultLabel()
        {
            if (!decimalExists)
            {
                if (ResultLabel.Text == "0")
                {
                    outputString += "0";
                }
                outputString += ".";
                decimalExists = true;
            }
        }
        /// <summary>
        /// This method finalize the calculation for a label
        /// </summary>
        private void FinalizeOutput()
        {
            if (outputString == string.Empty)
            {
                outputString = "0";
            }
            outputValue = float.Parse(outputString);
            HeightLabel.Text = outputString.ToString();
            ClearNumericKeyboard();
            CalculatorButtonTableLayoutPanel.Visible = false;
        }
        /// <summary>
        /// This method removes the last character from the ResultLabel
        /// </summary>
        private void RemoveLastCharacterFromResultLabel()
        {
            if (outputString.Length > 0)
            {
                var lastChar = outputString.Substring(outputString.Length - 1);
                if (lastChar == ".")
                {
                    decimalExists = false;
                }
                outputString = outputString.Remove(outputString.Length - 1);

                if (outputString.Length == 0)
                {
                    outputString = "0";
                }
                ResultLabel.Text = outputString;
            }
        }
        /// <summary>
        /// This method clears the nimeric keyboard
        /// </summary>
        private void ClearNumericKeyboard()
        {
            ResultLabel.Text = "0";
            outputString = String.Empty;
            decimalExists = false;
            outputValue = 0.0f;
            CalculatorButtonTableLayoutPanel.Visible = false;
        }
        /// <summary>
        /// This method clears the numeric keyboard after the form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            ClearNumericKeyboard();
            CalculatorButtonTableLayoutPanel.Visible = false;
        }
        /// <summary>
        /// This is the event handler for the HeightLabel click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeightLabel_Click(object sender, EventArgs e)
        {
            CalculatorButtonTableLayoutPanel.Visible = true;
        }
    }
}
