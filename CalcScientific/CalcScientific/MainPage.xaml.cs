using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Data;
using System.Threading.Tasks;


namespace CalcScientific
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
     //   public event PropertyChangedEventHandler PropertyChanged;


        public MainPage()
        {
            InitializeComponent();

     //       BindingContext = this; Using entryAnswer.text = "" is easier for this project than data binding Input so I went this route instead
        }

        //     private static String _input = string.Empty;
        //    public string Input
        //      {
        //          get { return _input; }
        //
        //         set { _input = value;
        //             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Input"));
        //        }
        //     }


        string operation;
        double operand1, operand2, result, memoryRecall;

        private void BtnNine_Clicked(object sender, EventArgs e)
        {
             entryAnswer.Text += "9";
        }

        private void BtnEight_Clicked(object sender, EventArgs e)
        {
            entryAnswer.Text += "8";
        }

        private void BtnSeven_Clicked(object sender, EventArgs e)
        {
            entryAnswer.Text += "7";
        }

        private void BtnSix_Clicked(object sender, EventArgs e)
        {
            entryAnswer.Text += "6";
        }

        private void BtnFive_Clicked(object sender, EventArgs e)
        {
            entryAnswer.Text += "5";
        }

        private void BtnFour_Clicked(object sender, EventArgs e)
        {
            entryAnswer.Text += "4";
        }

        private void BtnThree_Clicked(object sender, EventArgs e)
        {
            entryAnswer.Text += "3";
        }

        private void BtnTwo_Clicked(object sender, EventArgs e)
        {
            entryAnswer.Text += "2";
        }

        private void BtnOne_Clicked(object sender, EventArgs e)
        {
            entryAnswer.Text += "1";
        }

        private void BtnZero_Clicked(object sender, EventArgs e)
        {
            entryAnswer.Text += "0";
        }

        private void BtnAC_Clicked(object sender, EventArgs e)
        {
            entryAnswer.Text = "0";
        }

        private void BtnBackspace_Clicked(object sender, EventArgs e)
        {
            entryAnswer.Text = entryAnswer.Text.Substring(0, entryAnswer.Text.Length - 1);
        }

        private void BtnPlus_Clicked(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(entryAnswer.Text);
            operation = "+";
            entryAnswer.Text = "0";
        }

        private void BtnMinus_Clicked(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(entryAnswer.Text);
            operation = "-";
            entryAnswer.Text = "0";
        }

        private void BtnInverse_Clicked(object sender, EventArgs e)
        {
            if (entryAnswer.Text.Contains("-"))
            {
                entryAnswer.Text = entryAnswer.Text.Remove(0, 1);
            }
            else
            {
                entryAnswer.Text = "-" + entryAnswer.Text;
            }
        }

        private void BtnDivide_Clicked(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(entryAnswer.Text);
            operation = "/";
            entryAnswer.Text = "0";
        }

        private void BtnRemainder_Clicked(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(entryAnswer.Text);
            operation = "%";
            entryAnswer.Text = "0";
        }

        private void BtnMultiply_Clicked(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(entryAnswer.Text);
            operation = "*";
            entryAnswer.Text = "0";
        }

        private void BtnEquals_Clicked(object sender, EventArgs e)
        {

            operand2 = Convert.ToDouble(entryAnswer.Text);
            switch (operation)
            {
                case "+":
                    result = operand1 + operand2;
                    entryAnswer.Text = Convert.ToString(result);
                    break;

                case "-":
                    result = operand1 - operand2;
                    entryAnswer.Text = Convert.ToString(result);
                    break;

                case "/":
                    if (operand2 == 0)
                    {
                        entryAnswer.Text = "0";
                        break;
                    }
                    else
                    {
                        result = operand1 / operand2;
                        entryAnswer.Text = Convert.ToString(result);
                        break;
                    }

                case "*":
                    result = operand1 * operand2;
                    entryAnswer.Text = Convert.ToString(result);
                    break;

                case "%":
                    result = operand1 % operand2;
                    entryAnswer.Text = Convert.ToString(result);
                    break;

                case "x^y":
                    result = System.Math.Pow(Convert.ToDouble(operand1), Convert.ToDouble(operand2));
                    entryAnswer.Text = Convert.ToString(result);
                    break;

                case "nPr":

                    int varN, var2;

                    varN = Factorial(Convert.ToInt32(operand1));
                    var2 = Factorial(Convert.ToInt32(operand1) - Convert.ToInt32(entryAnswer.Text));
                    entryAnswer.Text = Convert.ToString(varN / var2);
                    break;

                case "nCr":
                    int var3;

                    varN = Factorial(Convert.ToInt32(operand1));
                    var2 = Factorial(Convert.ToInt32(operand1) - Convert.ToInt32(entryAnswer.Text));
                    var3 = Factorial(Convert.ToInt32(entryAnswer.Text));
                    entryAnswer.Text = Convert.ToString(varN / (var2 * var3));
                    break;

                case "y//x":
                    result = (System.Math.Pow(operand1, (1.0 / operand2)));
                    entryAnswer.Text = Convert.ToString(result);

                    break;

                case "logx":
                    result = System.Math.Log10(operand1 / System.Math.Log10(operand2));
                    // logy(x) = log10(x) / log10(y)
                    entryAnswer.Text = Convert.ToString(result);

                    break;


            }




        }

        private void BtnDecimalPoint_Clicked(object sender, EventArgs e)
        {
            if (entryAnswer.Text.Contains("."))
            {
                entryAnswer.Text = entryAnswer.Text;
            }
            else if(entryAnswer.Text.Length > 0)
            {
                entryAnswer.Text += ".";
            }
            else
            {
                entryAnswer.Text += "0.";
            }
        }

        private void BtnSquared_Clicked(object sender, EventArgs e)
        {
            result = Convert.ToDouble(entryAnswer.Text) * Convert.ToDouble(entryAnswer.Text);
            entryAnswer.Text = Convert.ToString(result);
        }

        private void BtnCubed_Clicked(object sender, EventArgs e)
        {
            result = Convert.ToDouble(entryAnswer.Text) * Convert.ToDouble(entryAnswer.Text) * Convert.ToDouble(entryAnswer.Text);
            entryAnswer.Text = Convert.ToString(result);
        }

        private void BtnAnyPower_Clicked(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(entryAnswer.Text);
            operation = "x^y";
            entryAnswer.Text = "0";
        }

        private void BtnPi_Clicked(object sender, EventArgs e)
        {
            result = Convert.ToDouble(entryAnswer.Text) + 3.14;
            entryAnswer.Text = Convert.ToString(result);
        }

        private void BtnNaturalLog_Clicked(object sender, EventArgs e)
        {
            if (BtnNaturalLog.Text == "ln")
            {
                result = System.Math.Log(Convert.ToDouble(entryAnswer.Text));
                entryAnswer.Text = Convert.ToString(result);
            }
            else
            {
                operand1 = Convert.ToDouble(entryAnswer.Text);
                operation = "logx";
                entryAnswer.Text = "0";
            }

        }

        private void BtnRad_Clicked(object sender, EventArgs e)
        {
            if (BtnRad.BackgroundColor == Color.Default)
            {
                BtnRad.BackgroundColor = Color.Red;
            }
            else if (BtnRad.BackgroundColor == Color.Red)
            {
                BtnRad.BackgroundColor = Color.Default;
            }

        }

        private void BtnSin_Clicked(object sender, EventArgs e)
        {
            if (BtnSin.Text == "sin") {
                if (BtnRad.BackgroundColor == Color.Red)
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Sin(Convert.ToDouble(entryAnswer.Text)));
                }
                else
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Sin(Convert.ToDouble
                        (System.Math.PI / 180) * (Convert.ToDouble(entryAnswer.Text))));
                }
            }
            else
            {
                if (BtnRad.BackgroundColor == Color.Red)
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Asin(Convert.ToDouble(entryAnswer.Text)));
                }
                else
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Asin(Convert.ToDouble
                        (System.Math.PI / 180) * (Convert.ToDouble(entryAnswer.Text))));
                }
            }


        }

        private void BtnCos_Clicked(object sender, EventArgs e)
        {
            if (BtnCos.Text == "cos")
            {
                if (BtnRad.BackgroundColor == Color.Red)
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Cos(Convert.ToDouble(entryAnswer.Text)));
                }
                else
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Cos(Convert.ToDouble
                        (System.Math.PI / 180) * (Convert.ToDouble(entryAnswer.Text))));
                }
            }else
            {
                if (BtnRad.BackgroundColor == Color.Red)
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Acos(Convert.ToDouble(entryAnswer.Text)));
                }
                else
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Acos(Convert.ToDouble
                        (System.Math.PI / 180) * (Convert.ToDouble(entryAnswer.Text))));
                }
            }



        }

        private void BtnTan_Clicked(object sender, EventArgs e)
        {
            if (BtnTan.Text == "tan")
            {
                if (BtnRad.BackgroundColor == Color.Red)
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Tan(Convert.ToDouble(entryAnswer.Text)));
                }
                else
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Tan(Convert.ToDouble
                        (System.Math.PI / 180) * (Convert.ToDouble(entryAnswer.Text))));
                }
            }
            else
            {
                if (BtnRad.BackgroundColor == Color.Red)
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Atan(Convert.ToDouble(entryAnswer.Text)));
                }
                else
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Atan(Convert.ToDouble
                        (System.Math.PI / 180) * (Convert.ToDouble(entryAnswer.Text))));
                }
            }
        }

        private void BtnFactorial_Clicked(object sender, EventArgs e)
        {
            int i = 1;
            for (int j = 1; j <= Convert.ToInt16(entryAnswer.Text); j++)
            {
                i = i * j;
            }
            entryAnswer.Text = Convert.ToString(i);
        }

        private void BtnSquareRoot_Clicked(object sender, EventArgs e)
        {
            result = (System.Math.Sqrt(Convert.ToDouble(entryAnswer.Text)));
            entryAnswer.Text = Convert.ToString(result);
        }

        private void BtnCubeRoot_Clicked(object sender, EventArgs e)
        {
            result = (System.Math.Pow(Convert.ToDouble(entryAnswer.Text), (1.0 / 3.0)));
            entryAnswer.Text = Convert.ToString(result);
        }

        private void BtnCustomRoot_Clicked(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(entryAnswer.Text);
            operation = "y//x";
            entryAnswer.Text = "0";
        }

        private void BtnDivideOverOne_Clicked(object sender, EventArgs e)
        {
            result = Convert.ToDouble(1.0 / Convert.ToDouble(entryAnswer.Text));
            entryAnswer.Text = Convert.ToString(result);
        }

        private void BtnLogToTen_Clicked(object sender, EventArgs e)
        {
            if (BtnLogToTen.Text == "Log10") { 
            result = System.Math.Log10(Convert.ToDouble(entryAnswer.Text));
            entryAnswer.Text = Convert.ToString(result);
            }
            else
            {
                result = System.Math.Log10(Convert.ToDouble(entryAnswer.Text) / System.Math.Log10(2));
                // log2(x) = log10(x) / log10(2)
                entryAnswer.Text = Convert.ToString(result);
            }

        }

        private void BtnNPR_Clicked(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(entryAnswer.Text);
            operation = "nPr";
            entryAnswer.Text = "0";
        }

        private void BtnNCR_Clicked(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(entryAnswer.Text);
            operation = "nCr";
            entryAnswer.Text = "0";
        }

        private void BtnPowerToE_Clicked(object sender, EventArgs e)
        {
            result = (System.Math.Exp(Convert.ToDouble(entryAnswer.Text)));
            entryAnswer.Text = Convert.ToString(result);
        }

        private void BtnPowerToTen_Clicked(object sender, EventArgs e)
        {
            result = (System.Math.Pow(10, Convert.ToDouble(entryAnswer.Text)));
            entryAnswer.Text = Convert.ToString(result);
        }

        private void BtnE_Clicked(object sender, EventArgs e)
        {
            result = Convert.ToDouble(entryAnswer.Text) + 2.71;
            entryAnswer.Text = Convert.ToString(result);
        }

        private void BtnEE_Clicked(object sender, EventArgs e)
        {
            result = Convert.ToDouble(entryAnswer.Text) * (System.Math.Pow(10, Convert.ToDouble(entryAnswer.Text)));
            entryAnswer.Text = Convert.ToString(result);
        }

        private void BtnSinh_Clicked(object sender, EventArgs e)
        {
            if (BtnSinh.Text == "sinh")
            {
                if (BtnRad.BackgroundColor == Color.Red)
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Sinh(Convert.ToDouble(entryAnswer.Text)));
                }
                else
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Sinh(Convert.ToDouble
                        (System.Math.PI / 180) * (Convert.ToDouble(entryAnswer.Text))));
                }
            }
            else
            {
                    entryAnswer.Text = Convert.ToString(System.Math.Log(Convert.ToDouble(entryAnswer.Text) + System.Math.Sqrt(Convert.ToDouble(entryAnswer.Text) * Convert.ToDouble(entryAnswer.Text) + 1)));
                    // sinh^-1 X = ln(x + /x^2 + 1)

            }
        }

        private void BtnCosh_Clicked(object sender, EventArgs e)
        {
            
                if (BtnCosh.Text == "cosh")
                {
                    if (BtnRad.BackgroundColor == Color.Red)
                    {
                        entryAnswer.Text = Convert.ToString(System.Math.Cosh(Convert.ToDouble(entryAnswer.Text)));
                    }
                    else
                    {
                        entryAnswer.Text = Convert.ToString(System.Math.Cosh(Convert.ToDouble
                            (System.Math.PI / 180) * (Convert.ToDouble(entryAnswer.Text))));
                    }
                }
                else
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Log(Convert.ToDouble(entryAnswer.Text) + System.Math.Sqrt(Convert.ToDouble(entryAnswer.Text) * Convert.ToDouble(entryAnswer.Text) - 1)));
                    // cosh^-1 X = ln(x + /x^2 - 1)

                }
          }

        private void BtnTanh_Clicked(object sender, EventArgs e)
        {

            if (BtnTanh.Text == "tanh")
            {
                if (BtnRad.BackgroundColor == Color.Red)
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Tanh(Convert.ToDouble(entryAnswer.Text)));
                }
                else
                {
                    entryAnswer.Text = Convert.ToString(System.Math.Tanh(Convert.ToDouble
                        (System.Math.PI / 180) * (Convert.ToDouble(entryAnswer.Text))));
                }
            }
            else
            {
                entryAnswer.Text = Convert.ToString(1/2 * (System.Math.Log(1 + Convert.ToDouble(entryAnswer.Text) / 1 - Convert.ToDouble(entryAnswer.Text))));
                // tanh^-1 X = 1/2 * ln(1 + x / 1 - x)

            }
        }

        private void BtnRand_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            result = rnd.Next(Convert.ToInt32(entryAnswer.Text));
            entryAnswer.Text = Convert.ToString(result);
        }

        private void BtnMC_Clicked(object sender, EventArgs e)
        {
            operation = "";
            entryAnswer.Text = "0";
            operand1 = 0;
            operand2 = 0;
            result = 0;
            memoryRecall = 0;
        }

        private void BtnMPlus_Clicked(object sender, EventArgs e)
        {
            memoryRecall = Convert.ToDouble(entryAnswer.Text);
        }

        private void BtnMMinus_Clicked(object sender, EventArgs e)
        {
            memoryRecall = 0;
        }

        private void BtnMR_Clicked(object sender, EventArgs e)
        {
            entryAnswer.Text = Convert.ToString(memoryRecall);
        }

        private void BtnSecondFunction_Clicked(object sender, EventArgs e)
        {
            /* Functions which need to be changed with the activation of Second Function
                * LN = Log-y // log10 = log2 // sin = sin^-1
                * cos = cos^-1 // tan = tan^-1 // sinh = sinh^-1
                * cosh = cosh^-1 // tanh = tanh^-1 */
                
            if (BtnSecondFunction.BackgroundColor == Color.Default)
            {
                BtnSecondFunction.BackgroundColor = Color.Red;
                BtnNaturalLog.Text = "Logx";
                BtnLogToTen.Text = "Log2";
                BtnSin.Text = "sin^-1";
                BtnCos.Text = "cos^-1";
                BtnTan.Text = "tan^-1";
                BtnSinh.Text = "sinh^-1";
                BtnCosh.Text = "cosh^-1";
                BtnTanh.Text = "tanh^-1";
            }
            else if (BtnSecondFunction.BackgroundColor == Color.Red)
            {
                BtnSecondFunction.BackgroundColor = Color.Default;
                BtnNaturalLog.Text = "ln";
                BtnLogToTen.Text = "Log10";
                BtnSin.Text = "sin";
                BtnCos.Text = "cos";
                BtnTan.Text = "tan";
                BtnSinh.Text = "sinh";
                BtnCosh.Text = "cosh";
                BtnTanh.Text = "tanh";
            }
        }

        private int Factorial(int x)
        {
            int i = 1;

            for (int j = 1; j <= x; j++)
            {
                i = i * j;
            }
            return i;
        }



    }
}
