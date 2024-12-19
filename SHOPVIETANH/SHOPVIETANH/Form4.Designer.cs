namespace SHOPVIETANH
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            textBox5 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            menuStrip2 = new MenuStrip();
            productToolStripMenuItem = new ToolStripMenuItem();
            employeeToolStripMenuItem = new ToolStripMenuItem();
            productToolStripMenuItem1 = new ToolStripMenuItem();
            oderToolStripMenuItem = new ToolStripMenuItem();
            textBox3 = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1264, 456);
            label7.Name = "label7";
            label7.Size = new Size(0, 32);
            label7.TabIndex = 40;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1264, 549);
            label6.Name = "label6";
            label6.Size = new Size(0, 32);
            label6.TabIndex = 39;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1027, 552);
            label4.Name = "label4";
            label4.Size = new Size(0, 32);
            label4.TabIndex = 38;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1023, 446);
            label3.Name = "label3";
            label3.Size = new Size(0, 32);
            label3.TabIndex = 37;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(1264, 491);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(200, 39);
            textBox5.TabIndex = 35;
            textBox5.Text = "customer_name";
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1027, 572);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 39);
            textBox2.TabIndex = 34;
            textBox2.Text = "phone_number";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(1069, 371);
            label2.Name = "label2";
            label2.Size = new Size(384, 49);
            label2.TabIndex = 33;
            label2.Text = "Add New Customer";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1023, 491);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 39);
            textBox1.TabIndex = 32;
            textBox1.Text = "Customer_Code";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(28, 435);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(779, 448);
            dataGridView1.TabIndex = 31;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Cursor = Cursors.UpArrow;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 122);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            pictureBox1.UseWaitCursor = true;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(556, 71);
            label1.Name = "label1";
            label1.Size = new Size(393, 66);
            label1.TabIndex = 28;
            label1.Text = "SHOPVIETANH";
            label1.UseWaitCursor = true;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(1264, 651);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 29;
            button1.Text = "Add new product";
            button1.UseVisualStyleBackColor = false;
            button1.UseWaitCursor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1183, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(410, 125);
            pictureBox2.TabIndex = 27;
            pictureBox2.TabStop = false;
            pictureBox2.UseWaitCursor = true;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // menuStrip2
            // 
            menuStrip2.Dock = DockStyle.None;
            menuStrip2.ImageScalingSize = new Size(32, 32);
            menuStrip2.Items.AddRange(new ToolStripItem[] { productToolStripMenuItem, employeeToolStripMenuItem, productToolStripMenuItem1, oderToolStripMenuItem });
            menuStrip2.Location = new Point(508, 163);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(487, 40);
            menuStrip2.TabIndex = 30;
            menuStrip2.Text = "menuStrip2";
            // 
            // productToolStripMenuItem
            // 
            productToolStripMenuItem.Name = "productToolStripMenuItem";
            productToolStripMenuItem.Size = new Size(116, 36);
            productToolStripMenuItem.Text = "Product";
            // 
            // employeeToolStripMenuItem
            // 
            employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            employeeToolStripMenuItem.Size = new Size(139, 36);
            employeeToolStripMenuItem.Text = "Employee";
            // 
            // productToolStripMenuItem1
            // 
            productToolStripMenuItem1.Name = "productToolStripMenuItem1";
            productToolStripMenuItem1.Size = new Size(137, 36);
            productToolStripMenuItem1.Text = "Customer";
            productToolStripMenuItem1.Click += productToolStripMenuItem1_Click;
            // 
            // oderToolStripMenuItem
            // 
            oderToolStripMenuItem.Name = "oderToolStripMenuItem";
            oderToolStripMenuItem.Size = new Size(87, 36);
            oderToolStripMenuItem.Text = "Oder";
            oderToolStripMenuItem.Click += oderToolStripMenuItem_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1264, 572);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(200, 39);
            textBox3.TabIndex = 41;
            textBox3.Text = "address";
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Cursor = Cursors.IBeam;
            label5.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(248, 371);
            label5.Name = "label5";
            label5.Size = new Size(340, 49);
            label5.TabIndex = 42;
            label5.Text = "Purchase History";
            label5.Click += label5_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1593, 915);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox5);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(menuStrip2);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private TextBox textBox5;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
        private Label label1;
        private Button button1;
        private PictureBox pictureBox2;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem productToolStripMenuItem;
        private ToolStripMenuItem employeeToolStripMenuItem;
        private ToolStripMenuItem productToolStripMenuItem1;
        private ToolStripMenuItem oderToolStripMenuItem;
        private TextBox textBox3;
        private Label label5;
    }
}