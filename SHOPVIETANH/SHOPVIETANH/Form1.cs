using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SHOPVIETANH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Sự kiện khi form load
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        // Sự kiện khi người dùng nhấn nút Đăng nhập
        [Obsolete]
        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin người dùng nhập vào
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Chuỗi kết nối đến SQL Server
            string connectionString = @"Server=TUNGHOI;Database=SHOPVIETANH;Integrated Security=True";

            // Câu lệnh SQL kiểm tra đăng nhập
            string query = "SELECT COUNT(1) FROM employee WHERE username = @username AND password = @password";

            try
            {
                // Tạo kết nối đến cơ sở dữ liệu và thực hiện truy vấn
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();
                    int result = (int)command.ExecuteScalar();

                    if (result == 1)
                    {
                        // Nếu đăng nhập thành công, chuyển sang Form2
                        MessageBox.Show("Đăng nhập thành công!");
                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide(); // Ẩn Form1
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
            }
        }

        // Sự kiện click cho label1 (Có thể dùng cho các mục khác nếu cần)
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Sự kiện click cho label2 (Có thể dùng cho các mục khác nếu cần)
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Xử lý sự kiện cho pictureBox1 nếu cần
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Xử lý sự kiện cho pictureBox2 nếu cần
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        // Xử lý sự kiện cho pictureBox3 nếu cần
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        // Sự kiện khi TextBox1 thay đổi (Không bắt buộc, nếu cần xử lý)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Sự kiện khi TextBox2 thay đổi (Không bắt buộc, nếu cần xử lý)
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
