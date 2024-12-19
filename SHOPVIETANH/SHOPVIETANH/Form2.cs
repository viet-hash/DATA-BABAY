using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SHOPVIETANH
{
    public partial class Form2 : Form
    {
        // Tạo DataTable để chứa thông tin sản phẩm
        private DataTable productTable;

        // Chuỗi kết nối tới SQL Server
        private string connectionString = "Server=TUNGHOI;Database=SHOPVIETANH;Integrated Security=True;";

        public Form2()
        {
            InitializeComponent();
            InitializeProductTable();
            LoadDataFromDatabase();
        }

        // Khởi tạo DataTable và liên kết với DataGridView
        private void InitializeProductTable()
        {
            productTable = new DataTable();
            productTable.Columns.Add("product_code", typeof(string));
            productTable.Columns.Add("product_name", typeof(string));
            productTable.Columns.Add("selling_price", typeof(decimal));
            productTable.Columns.Add("inventory_quantity", typeof(int));
            productTable.Columns.Add("created_at", typeof(DateTime));

            dataGridView1.DataSource = productTable;
        }

        // Tải dữ liệu từ cơ sở dữ liệu và hiển thị lên DataGridView
        private void LoadDataFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM product";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(productTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện khi nhấn nút "Add new"
        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra các ô nhập liệu
            if (!ValidateFields())
                return;

            try
            {
                // Lấy dữ liệu từ các ô nhập
                string productName = textBox1.Text.Trim();
                decimal price = Convert.ToDecimal(textBox2.Text.Trim());
                int quantity = Convert.ToInt32(textBox5.Text.Trim());
                DateTime date = dateTimePicker1.Value;

                // Tạo mã sản phẩm tự động
                string productCode = $"P{productTable.Rows.Count + 1:D3}";

                // Thêm dữ liệu vào DataTable
                productTable.Rows.Add(productCode, productName, price, quantity, date);

                // Cập nhật vào cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO product (product_code, product_name, selling_price, inventory_quantity, created_at) VALUES (@product_code, @product_name, @selling_price, @inventory_quantity, @created_at)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@product_code", productCode);
                    cmd.Parameters.AddWithValue("@product_name", productName);
                    cmd.Parameters.AddWithValue("@selling_price", price);
                    cmd.Parameters.AddWithValue("@inventory_quantity", quantity);
                    cmd.Parameters.AddWithValue("@created_at", date);
                    cmd.ExecuteNonQuery();
                }

                // Thông báo thành công và mã sản phẩm mới
                MessageBox.Show($"Sản phẩm '{productName}' đã được thêm với mã '{productCode}'.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa dữ liệu trong các ô nhập
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm xác thực dữ liệu đầu vào
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(textBox2.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Giá bán phải là số hợp lệ và lớn hơn 0.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return false;
            }

            if (!int.TryParse(textBox5.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên hợp lệ và không âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
                return false;
            }

            return true;
        }

        // Hàm xóa nội dung các ô nhập
        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Focus(); // Đưa con trỏ về ô nhập tên sản phẩm
        }

        // Sự kiện xóa sản phẩm
        private void button2_Click(object sender, EventArgs e)
        {
            string productCode = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(productCode))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm để xóa.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM product WHERE product_code = @product_code";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@product_code", productCode);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataFromDatabase(); // Làm mới dữ liệu sau khi xóa sản phẩm
                    }
                    else
                    {
                        MessageBox.Show("Không có sản phẩm để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện mở Form3 khi chọn menu "Employee"
        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        // Các sự kiện không thay đổi (để giữ form không bị mất)
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void productToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void productToolStripMenuItem1_Click(object sender, EventArgs e) { }
        private void oderToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }

        private void Form2_Load(object sender, EventArgs e) { }
    }
}
