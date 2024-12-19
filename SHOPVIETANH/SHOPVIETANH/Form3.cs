using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SHOPVIETANH
{
    public partial class Form3 : Form
    {
        private DataTable employeeTable;

        // Chuỗi kết nối tới SQL Server
        private string connectionString = "Server=TUNGHOI;Database=SHOPVIETANH;Integrated Security=True;";

        public Form3()
        {
            InitializeComponent();
            InitializeEmployeeTable();
            LoadEmployeeDataFromDatabase();
        }

        private void InitializeEmployeeTable()
        {
            employeeTable = new DataTable();
            employeeTable.Columns.Add("employee_code", typeof(string));
            employeeTable.Columns.Add("employee_name", typeof(string));
            employeeTable.Columns.Add("position", typeof(string));
            employeeTable.Columns.Add("authority", typeof(string));
            employeeTable.Columns.Add("username", typeof(string));
            employeeTable.Columns.Add("created_at", typeof(DateTime));

            dataGridView1.DataSource = employeeTable;
        }

        private void LoadEmployeeDataFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT employee_code, employee_name, position, authority, username, created_at FROM employee";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(employeeTable);
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
                string employeeName = textBox1.Text.Trim();
                string position = textBox4.Text.Trim();
                string authority = textBox2.Text.Trim();
                string username = textBox5.Text.Trim();
                string password = textBox6.Text.Trim();
                DateTime date = DateTime.Now;

                string employeeCode = $"E{employeeTable.Rows.Count + 1:D3}";

                employeeTable.Rows.Add(employeeCode, employeeName, position, authority, username, date);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO employee (employee_code, employee_name, position, authority, username, password, created_at) VALUES (@employee_code, @employee_name, @position, @authority, @username, @password, @created_at)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@employee_code", employeeCode);
                    cmd.Parameters.AddWithValue("@employee_name", employeeName);
                    cmd.Parameters.AddWithValue("@position", position);
                    cmd.Parameters.AddWithValue("@authority", authority);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@created_at", date);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Nhân viên '{employeeName}' đã được thêm với mã '{employeeCode}'.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void customerToolStripMenuItem_Click(object sender, EventArgs e) {
            Form4 form4 = new Form4(); form4.Show(); 
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBox5.Text.Length < 5)
            {
                MessageBox.Show("Tên người dùng phải có ít nhất 5 ký tự.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
                return false;
            }

            if (textBox6.Text.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox4.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Focus();
        }

        // Các sự kiện không thay đổi
        private void employeeToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void productToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void productToolStripMenuItem1_Click(object sender, EventArgs e) {
            Form4 form4 = new Form4(); form4.Show();
            this.Hide();
        }
        private void oderToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void Form3_Load(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
    }
}
