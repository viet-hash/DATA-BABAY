using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SHOPVIETANH
{
    public partial class Form5 : Form
    {
        private DataTable orderTable;
        private string connectionString = "Server=TUNGHOI;Database=SHOPVIETANH;Integrated Security=True;";

        public Form5()
        {
            InitializeComponent();
            InitializeOrderTable();
            LoadOrderDataFromDatabase();
        }

        private void InitializeOrderTable()
        {
            orderTable = new DataTable();
            orderTable.Columns.Add("order_code", typeof(string));
            orderTable.Columns.Add("customer_code", typeof(string));
            orderTable.Columns.Add("employee_code", typeof(string));
            orderTable.Columns.Add("order_date", typeof(DateTime));
            orderTable.Columns.Add("total_amount", typeof(decimal));
            orderTable.Columns.Add("created_at", typeof(DateTime));

            dataGridView1.DataSource = orderTable;
        }

        private void LoadOrderDataFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM orders";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(orderTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            try
            {
                string orderCode = textBox1.Text.Trim();
                string customerCode = textBox2.Text.Trim();
                string employeeCode = textBox3.Text.Trim();
                DateTime orderDate = DateTime.Now;
                decimal totalAmount = decimal.Parse(textBox5.Text.Trim());

                orderTable.Rows.Add(orderCode, customerCode, employeeCode, orderDate, totalAmount, orderDate);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO orders (order_code, customer_code, employee_code, order_date, total_amount, created_at) VALUES (@order_code, @customer_code, @employee_code, @order_date, @total_amount, @created_at)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@order_code", orderCode);
                    cmd.Parameters.AddWithValue("@customer_code", customerCode);
                    cmd.Parameters.AddWithValue("@employee_code", employeeCode);
                    cmd.Parameters.AddWithValue("@order_date", orderDate);
                    cmd.Parameters.AddWithValue("@total_amount", totalAmount);
                    cmd.Parameters.AddWithValue("@created_at", orderDate);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Đơn hàng '{orderCode}' đã được thêm thành công.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                LoadOrderDataFromDatabase(); // Làm mới dữ liệu sau khi thêm đơn hàng
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            decimal totalAmount;
            if (!decimal.TryParse(textBox5.Text.Trim(), out totalAmount))
            {
                MessageBox.Show("Tổng số tiền không hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox1.Focus(); // Đưa con trỏ về ô nhập mã đơn hàng
        }

        // Các sự kiện không thay đổi
        private void label5_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void employeeToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void productToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
