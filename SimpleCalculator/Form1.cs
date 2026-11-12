namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal operand1 = Convert.ToDecimal(txtOperand1.Text);
                string operator1 = txtOperator.Text;
                decimal operand2 = Convert.ToDecimal(txtOperand2.Text);
                decimal result = Calculate(operand1, operator1, operand2);

                result = Math.Round(result, 4);
                txtResult.Text = result.ToString();
                txtOperand1.Focus();

                if (operand1 >= 10000)
                {
                    throw new OverflowException();
                }

            } catch (FormatException)
                {
                    MessageBox.Show("Please enter valid numbers for operands.", "Format Error");
            } catch (OverflowException)
            {
                MessageBox.Show("Enter a value <10,000", "Overflow Error");
            } catch (DivideByZeroException)
            {
                 MessageBox.Show("Cannot divide by zero.", "Divide by Zero Error");
            } catch (Exception)
            {
                MessageBox.Show("Check that values are correct", "Entry Error");
            }
        }

        private decimal Calculate(decimal operand1, string operator1, decimal operand2)
        {
            decimal result = 0;
            if (operator1 == "+")
                result = operand1 + operand2;
            else if (operator1 == "-")
                result = operand1 - operand2;
            else if (operator1 == "*")
                result = operand1 * operand2;
            else if (operator1 == "/")
                result = operand1 / operand2;
            return result;
        }

        private void ClearResult(object sender, EventArgs e)
        {
            txtResult.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}