namespace DaoHamTichPhanGioiHan
{
    partial class InformationForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformationForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(19, 76);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(534, 350);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Biểu thức";
            this.columnHeader1.Width = 146;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cú pháp";
            this.columnHeader2.Width = 350;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pi.png");
            this.imageList1.Images.SetKeyName(1, "infinity.png");
            this.imageList1.Images.SetKeyName(2, "e.png");
            this.imageList1.Images.SetKeyName(3, "a^b.png");
            this.imageList1.Images.SetKeyName(4, "sqrt.png");
            this.imageList1.Images.SetKeyName(5, "cbrt.png");
            this.imageList1.Images.SetKeyName(6, "nroot.png");
            this.imageList1.Images.SetKeyName(7, "abs.png");
            this.imageList1.Images.SetKeyName(8, "a!.png");
            this.imageList1.Images.SetKeyName(9, "sum.png");
            this.imageList1.Images.SetKeyName(10, "product.png");
            this.imageList1.Images.SetKeyName(11, "ln.png");
            this.imageList1.Images.SetKeyName(12, "log.png");
            this.imageList1.Images.SetKeyName(13, "sin.png");
            this.imageList1.Images.SetKeyName(14, "cos.png");
            this.imageList1.Images.SetKeyName(15, "tan.png");
            this.imageList1.Images.SetKeyName(16, "diff.png");
            this.imageList1.Images.SetKeyName(17, "int.png");
            this.imageList1.Images.SetKeyName(18, "int2.png");
            this.imageList1.Images.SetKeyName(19, "lim.png");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(542, 63);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cú pháp nhập bài toán của chương trình dựa trên ngôn ngữ Maple, dưới đây là một s" +
    "ố ký hiệu và cú pháp của các biểu thức phổ biến có thể nhập vào:";
            // 
            // InformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 440);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(585, 479);
            this.MinimumSize = new System.Drawing.Size(585, 479);
            this.Name = "InformationForm";
            this.Text = "Thông tin chương trình";
            this.Load += new System.EventHandler(this.InformationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
    }
}