using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SHOPVIETANH
{
    public partial class Form4 : Form
    {
        private DataTable purchaseHistoryTable;
        private string connectionString = "Server=TUNGHOI;Database=SHOPVIETANH;Integrated Security=True;";

        public Form4()
        {
            InitializeComponent();
            InitializePurchaseHistoryTable();
            LoadPurchaseHistoryDataFromDatabase();
        }

        // Khởi tạo DataTable và liên kết với DataGridView
        private void InitializePurchaseHistoryTable()
        {
            purchaseHistoryTable = new DataTable();
            purchaseHistoryTable.Columns.Add("order_code", typeof(string));
            purchaseHistoryTable.Columns.Add("customer_code", typeof(string));
            purchaseHistoryTable.Columns.Add("employee_code", typeof(string));
            purchaseHistoryTable.Columns.Add("order_date", typeof(DateTime));
            purchaseHistoryTable.Columns.Add("total_amount", typeof(decimal));
            purchaseHistoryTable.Columns.Add("created_at", typeof(DateTime));

            dataGridView1.DataSource = purchaseHistoryTable;
        }

        // Tải dữ liệu từ cơ sở dữ liệu và hiển thị lên DataGridView
        private void LoadPurchaseHistoryDataFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            o.order_code, 
                            o.customer_code, 
                            o.employee_code, 
                            o.order_date, 
                            o.total_amount, 
                            o.created_at 
                        FROM 
                            orders o 
                        JOIN 
                            order_detail od ON o.order_code = od.order_code 
                        JOIN 
                            sales s ON od.product_code = s.product_code";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(purchaseHistoryTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện khi nhấn nút "Add Customer" (giữ nguyên nếu cần)
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            try
            {
                string customerCode = textBox1.Text.Trim();
                string customerName = textBox5.Text.Trim();
                string phoneNumber = textBox2.Text.Trim();
                string address = textBox3.Text.Trim();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO customer (customer_code, customer_name, phone_number, address) VALUES (@customer_code, @customer_name, @phone_number, @address)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customer_code", customerCode);
                    cmd.Parameters.AddWithValue("@customer_name", customerName);
                    cmd.Parameters.AddWithValue("@phone_number", phoneNumber);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Khách hàng '{customerName}' đã được thêm với mã '{customerCode}'.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                LoadCustomerDataFromDatabase(); // Làm mới dữ liệu sau khi thêm khách hàng
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomerDataFromDatabase()
        {
            throw new NotImplementedException();
        }

        // Hàm xác thực dữ liệu đầu vào (giữ nguyên nếu cần)
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBox2.Text.Length > 15)
            {
                MessageBox.Show("Số điện thoại phải có độ dài không quá 15 ký tự.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return false;
            }

            return true;
        }

        // Hàm xóa nội dung các ô nhập (giữ nguyên nếu cần)
        private void ClearFields()
        {
            textBox1.Clear();
            textBox5.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus(); // Đưa con trỏ về ô nhập mã khách hàng
        }

        // Các sự kiện không thay đổi
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void oderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(); form5.Show();
            this.Hide();
        }
        private void productToolStripMenuItem1_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
