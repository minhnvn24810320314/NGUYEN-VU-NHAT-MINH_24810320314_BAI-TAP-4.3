using System;
using System.Windows.Forms;

namespace BÀI_TẬP_4._3
{
    public partial class Form1 : Form
    {
        private double resultValue = 0;
        private string operationPerformed = "";
        private bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent(); // Khởi tạo giao diện trước
        }

        // Sự kiện Form Load: Tự động gán sự kiện khi Form đã load xong giao diện
        private void Form1_Load(object sender, EventArgs e)
        {
            AttachEventsAutomatically();
        }

        private void AttachEventsAutomatically()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    // Nếu là nút số (0-9)
                    if (int.TryParse(btn.Text.Trim(), out _))
                    {
                        btn.Click -= NumberButton_Click; // Hủy gán cũ (nếu có) để tránh trùng
                        btn.Click += NumberButton_Click;
                    }
                    // Nếu là nút phép toán (+, -, *, /)
                    else if (btn.Text.Trim() == "+" || btn.Text.Trim() == "-" || btn.Text.Trim() == "*" || btn.Text.Trim() == "/")
                    {
                        btn.Click -= OperationButton_Click;
                        btn.Click += OperationButton_Click;
                    }
                    // Nếu là nút C (Clear)
                    else if (btn.Text.Trim().ToUpper() == "C")
                    {
                        btn.Click -= btnClear_Click;
                        btn.Click += btnClear_Click;
                    }
                    // Nếu là nút = (Equal)
                    else if (btn.Text.Trim() == "=")
                    {
                        btn.Click -= btnEqual_Click;
                        btn.Click += btnEqual_Click;
                    }
                }
            }
        }

        // 🎯 YÊU CẦU ĐỀ BÀI: Sử dụng object sender cho các nút số
        private void NumberButton_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "0") || (isOperationPerformed))
                txtDisplay.Clear();

            isOperationPerformed = false;
            Button btn = (Button)sender;
            txtDisplay.Text += btn.Text.Trim();
        }

        // Xử lý khi bấm nút phép toán (+, -, *, /)
        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (resultValue != 0 && !isOperationPerformed)
            {
                CalculateResult();
                operationPerformed = btn.Text.Trim();
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = btn.Text.Trim();
                resultValue = double.Parse(txtDisplay.Text);
                isOperationPerformed = true;
            }
        }

        // Xử lý nút C (Clear)
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            resultValue = 0;
            operationPerformed = "";
            isOperationPerformed = false;
        }

        // Xử lý nút Bằng (=)
        private void btnEqual_Click(object sender, EventArgs e)
        {
            CalculateResult();
            operationPerformed = "";
            isOperationPerformed = true;
        }

        private void CalculateResult()
        {
            double currentDisplay = double.Parse(txtDisplay.Text);

            switch (operationPerformed)
            {
                case "+":
                    txtDisplay.Text = (resultValue + currentDisplay).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (resultValue - currentDisplay).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (resultValue * currentDisplay).ToString();
                    break;
                case "/":
                    if (currentDisplay != 0)
                        txtDisplay.Text = (resultValue / currentDisplay).ToString();
                    else
                        MessageBox.Show("Không thể chia cho 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            resultValue = double.Parse(txtDisplay.Text);
        }
    }
}