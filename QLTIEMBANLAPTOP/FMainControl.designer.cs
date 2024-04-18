namespace DoAn_2
{
    partial class FMainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMainControl));
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.ButDT = new FontAwesome.Sharp.IconButton();
            this.btnHD = new FontAwesome.Sharp.IconButton();
            this.btnlogout = new FontAwesome.Sharp.IconButton();
            this.btnSP = new FontAwesome.Sharp.IconButton();
            this.btnNV = new FontAwesome.Sharp.IconButton();
            this.btnhome = new FontAwesome.Sharp.IconButton();
            this.btnKH = new FontAwesome.Sharp.IconButton();
            this.PanelLogo = new System.Windows.Forms.Panel();
            this.panelshadow = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelTitlebar = new System.Windows.Forms.Panel();
            this.lbDateTime = new System.Windows.Forms.Label();
            this.LabelUser = new System.Windows.Forms.Label();
            this.iconMinimize = new FontAwesome.Sharp.IconButton();
            this.iconExit = new FontAwesome.Sharp.IconButton();
            this.labelcon = new System.Windows.Forms.Label();
            this.iconmenusmall = new FontAwesome.Sharp.IconPictureBox();
            this.paneltrangcon = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ButKhuyenmai = new FontAwesome.Sharp.IconButton();
            this.PanelMenu.SuspendLayout();
            this.PanelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconmenusmall)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.PanelMenu.Controls.Add(this.ButKhuyenmai);
            this.PanelMenu.Controls.Add(this.ButDT);
            this.PanelMenu.Controls.Add(this.btnHD);
            this.PanelMenu.Controls.Add(this.btnlogout);
            this.PanelMenu.Controls.Add(this.btnSP);
            this.PanelMenu.Controls.Add(this.btnNV);
            this.PanelMenu.Controls.Add(this.btnhome);
            this.PanelMenu.Controls.Add(this.btnKH);
            this.PanelMenu.Controls.Add(this.PanelLogo);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(343, 900);
            this.PanelMenu.TabIndex = 0;
            // 
            // ButDT
            // 
            this.ButDT.FlatAppearance.BorderSize = 0;
            this.ButDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButDT.ForeColor = System.Drawing.Color.Gainsboro;
            this.ButDT.IconChar = FontAwesome.Sharp.IconChar.BoxesAlt;
            this.ButDT.IconColor = System.Drawing.Color.Gainsboro;
            this.ButDT.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ButDT.IconSize = 35;
            this.ButDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButDT.Location = new System.Drawing.Point(0, 430);
            this.ButDT.Margin = new System.Windows.Forms.Padding(4);
            this.ButDT.Name = "ButDT";
            this.ButDT.Padding = new System.Windows.Forms.Padding(13, 0, 27, 0);
            this.ButDT.Size = new System.Drawing.Size(343, 62);
            this.ButDT.TabIndex = 8;
            this.ButDT.Text = "Kho";
            this.ButDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButDT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButDT.UseVisualStyleBackColor = true;
            this.ButDT.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btnHD
            // 
            this.btnHD.FlatAppearance.BorderSize = 0;
            this.btnHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHD.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHD.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btnHD.IconColor = System.Drawing.Color.Gainsboro;
            this.btnHD.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHD.IconSize = 35;
            this.btnHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHD.Location = new System.Drawing.Point(0, 369);
            this.btnHD.Margin = new System.Windows.Forms.Padding(4);
            this.btnHD.Name = "btnHD";
            this.btnHD.Padding = new System.Windows.Forms.Padding(13, 0, 27, 0);
            this.btnHD.Size = new System.Drawing.Size(343, 62);
            this.btnHD.TabIndex = 4;
            this.btnHD.Text = "Hóa Đơn";
            this.btnHD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHD.UseVisualStyleBackColor = true;
            this.btnHD.Click += new System.EventHandler(this.btndashboard_Click);
            // 
            // btnlogout
            // 
            this.btnlogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnlogout.FlatAppearance.BorderSize = 0;
            this.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnlogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnlogout.IconColor = System.Drawing.Color.Gainsboro;
            this.btnlogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlogout.IconSize = 35;
            this.btnlogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogout.Location = new System.Drawing.Point(0, 838);
            this.btnlogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Padding = new System.Windows.Forms.Padding(13, 0, 27, 0);
            this.btnlogout.Size = new System.Drawing.Size(343, 62);
            this.btnlogout.TabIndex = 7;
            this.btnlogout.Text = "Đăng xuất";
            this.btnlogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // btnSP
            // 
            this.btnSP.FlatAppearance.BorderSize = 0;
            this.btnSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSP.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSP.IconChar = FontAwesome.Sharp.IconChar.LaptopCode;
            this.btnSP.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSP.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSP.IconSize = 35;
            this.btnSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSP.Location = new System.Drawing.Point(0, 308);
            this.btnSP.Margin = new System.Windows.Forms.Padding(4);
            this.btnSP.Name = "btnSP";
            this.btnSP.Padding = new System.Windows.Forms.Padding(13, 0, 27, 0);
            this.btnSP.Size = new System.Drawing.Size(343, 62);
            this.btnSP.TabIndex = 6;
            this.btnSP.Text = "Sản Phẩm";
            this.btnSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnluong_Click);
            // 
            // btnNV
            // 
            this.btnNV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNV.FlatAppearance.BorderSize = 0;
            this.btnNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNV.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnNV.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.btnNV.IconColor = System.Drawing.Color.Gainsboro;
            this.btnNV.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNV.IconSize = 35;
            this.btnNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNV.Location = new System.Drawing.Point(0, 185);
            this.btnNV.Margin = new System.Windows.Forms.Padding(4);
            this.btnNV.Name = "btnNV";
            this.btnNV.Padding = new System.Windows.Forms.Padding(13, 0, 27, 0);
            this.btnNV.Size = new System.Drawing.Size(343, 62);
            this.btnNV.TabIndex = 2;
            this.btnNV.Text = "Nhân viên";
            this.btnNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNV.UseVisualStyleBackColor = true;
            this.btnNV.Click += new System.EventHandler(this.btnorders_Click);
            // 
            // btnhome
            // 
            this.btnhome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnhome.FlatAppearance.BorderSize = 0;
            this.btnhome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhome.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnhome.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btnhome.IconColor = System.Drawing.Color.Gainsboro;
            this.btnhome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnhome.IconSize = 35;
            this.btnhome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhome.Location = new System.Drawing.Point(0, 123);
            this.btnhome.Margin = new System.Windows.Forms.Padding(4);
            this.btnhome.Name = "btnhome";
            this.btnhome.Padding = new System.Windows.Forms.Padding(13, 0, 27, 0);
            this.btnhome.Size = new System.Drawing.Size(343, 62);
            this.btnhome.TabIndex = 1;
            this.btnhome.Text = "Trang chủ";
            this.btnhome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnhome.UseVisualStyleBackColor = true;
            this.btnhome.Click += new System.EventHandler(this.btnhome_Click);
            // 
            // btnKH
            // 
            this.btnKH.FlatAppearance.BorderSize = 0;
            this.btnKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKH.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnKH.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.btnKH.IconColor = System.Drawing.Color.Gainsboro;
            this.btnKH.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKH.IconSize = 35;
            this.btnKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKH.Location = new System.Drawing.Point(0, 246);
            this.btnKH.Margin = new System.Windows.Forms.Padding(4);
            this.btnKH.Name = "btnKH";
            this.btnKH.Padding = new System.Windows.Forms.Padding(13, 0, 27, 0);
            this.btnKH.Size = new System.Drawing.Size(343, 62);
            this.btnKH.TabIndex = 5;
            this.btnKH.Text = "Khách Hàng";
            this.btnKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKH.UseVisualStyleBackColor = true;
            this.btnKH.Click += new System.EventHandler(this.btnnhanvien_Click);
            // 
            // PanelLogo
            // 
            this.PanelLogo.Controls.Add(this.panelshadow);
            this.PanelLogo.Controls.Add(this.picLogo);
            this.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLogo.Location = new System.Drawing.Point(0, 0);
            this.PanelLogo.Margin = new System.Windows.Forms.Padding(4);
            this.PanelLogo.Name = "PanelLogo";
            this.PanelLogo.Size = new System.Drawing.Size(343, 123);
            this.PanelLogo.TabIndex = 0;
            // 
            // panelshadow
            // 
            this.panelshadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelshadow.Location = new System.Drawing.Point(343, 83);
            this.panelshadow.Margin = new System.Windows.Forms.Padding(4);
            this.panelshadow.Name = "panelshadow";
            this.panelshadow.Size = new System.Drawing.Size(1353, 10);
            this.panelshadow.TabIndex = 2;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::QLTIEMBANLAPTOP.Properties.Resources.e3f7744697484505a7da4496f23c2a85;
            this.picLogo.Location = new System.Drawing.Point(83, 8);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(140, 119);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // panelTitlebar
            // 
            this.panelTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.panelTitlebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitlebar.Controls.Add(this.lbDateTime);
            this.panelTitlebar.Controls.Add(this.LabelUser);
            this.panelTitlebar.Controls.Add(this.iconMinimize);
            this.panelTitlebar.Controls.Add(this.iconExit);
            this.panelTitlebar.Controls.Add(this.labelcon);
            this.panelTitlebar.Controls.Add(this.iconmenusmall);
            this.panelTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitlebar.Location = new System.Drawing.Point(343, 0);
            this.panelTitlebar.Margin = new System.Windows.Forms.Padding(4);
            this.panelTitlebar.Name = "panelTitlebar";
            this.panelTitlebar.Size = new System.Drawing.Size(1407, 86);
            this.panelTitlebar.TabIndex = 1;
            this.panelTitlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitlebar_MouseDown);
            // 
            // lbDateTime
            // 
            this.lbDateTime.AutoSize = true;
            this.lbDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDateTime.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbDateTime.Location = new System.Drawing.Point(507, 28);
            this.lbDateTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(133, 36);
            this.lbDateTime.TabIndex = 6;
            this.lbDateTime.Text = "12:30:33";
            // 
            // LabelUser
            // 
            this.LabelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUser.ForeColor = System.Drawing.Color.Gainsboro;
            this.LabelUser.Location = new System.Drawing.Point(1265, 47);
            this.LabelUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelUser.Name = "LabelUser";
            this.LabelUser.Size = new System.Drawing.Size(108, 20);
            this.LabelUser.TabIndex = 5;
            this.LabelUser.Text = "aaaaaaaaaaa";
            // 
            // iconMinimize
            // 
            this.iconMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconMinimize.IconColor = System.Drawing.Color.Gainsboro;
            this.iconMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMinimize.IconSize = 25;
            this.iconMinimize.Location = new System.Drawing.Point(1319, -13);
            this.iconMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.iconMinimize.Name = "iconMinimize";
            this.iconMinimize.Size = new System.Drawing.Size(40, 49);
            this.iconMinimize.TabIndex = 4;
            this.iconMinimize.UseVisualStyleBackColor = true;
            this.iconMinimize.Click += new System.EventHandler(this.iconMinimize_Click);
            // 
            // iconExit
            // 
            this.iconExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconExit.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.iconExit.IconColor = System.Drawing.Color.Gainsboro;
            this.iconExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconExit.IconSize = 25;
            this.iconExit.Location = new System.Drawing.Point(1359, -1);
            this.iconExit.Margin = new System.Windows.Forms.Padding(4);
            this.iconExit.Name = "iconExit";
            this.iconExit.Size = new System.Drawing.Size(40, 37);
            this.iconExit.TabIndex = 2;
            this.iconExit.UseVisualStyleBackColor = true;
            this.iconExit.Click += new System.EventHandler(this.iconExit_Click);
            // 
            // labelcon
            // 
            this.labelcon.AutoSize = true;
            this.labelcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelcon.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelcon.Location = new System.Drawing.Point(76, 38);
            this.labelcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelcon.Name = "labelcon";
            this.labelcon.Size = new System.Drawing.Size(54, 20);
            this.labelcon.TabIndex = 1;
            this.labelcon.Text = "Home";
            // 
            // iconmenusmall
            // 
            this.iconmenusmall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.iconmenusmall.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconmenusmall.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconmenusmall.IconColor = System.Drawing.Color.Gainsboro;
            this.iconmenusmall.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconmenusmall.IconSize = 39;
            this.iconmenusmall.Location = new System.Drawing.Point(25, 28);
            this.iconmenusmall.Margin = new System.Windows.Forms.Padding(4);
            this.iconmenusmall.Name = "iconmenusmall";
            this.iconmenusmall.Size = new System.Drawing.Size(43, 39);
            this.iconmenusmall.TabIndex = 0;
            this.iconmenusmall.TabStop = false;
            // 
            // paneltrangcon
            // 
            this.paneltrangcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.paneltrangcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paneltrangcon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paneltrangcon.Location = new System.Drawing.Point(343, 83);
            this.paneltrangcon.Name = "paneltrangcon";
            this.paneltrangcon.Size = new System.Drawing.Size(1407, 817);
            this.paneltrangcon.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ButKhuyenmai
            // 
            this.ButKhuyenmai.FlatAppearance.BorderSize = 0;
            this.ButKhuyenmai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButKhuyenmai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButKhuyenmai.ForeColor = System.Drawing.Color.Gainsboro;
            this.ButKhuyenmai.IconChar = FontAwesome.Sharp.IconChar.SheetPlastic;
            this.ButKhuyenmai.IconColor = System.Drawing.Color.Gainsboro;
            this.ButKhuyenmai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ButKhuyenmai.IconSize = 35;
            this.ButKhuyenmai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButKhuyenmai.Location = new System.Drawing.Point(0, 499);
            this.ButKhuyenmai.Margin = new System.Windows.Forms.Padding(4);
            this.ButKhuyenmai.Name = "ButKhuyenmai";
            this.ButKhuyenmai.Padding = new System.Windows.Forms.Padding(13, 0, 27, 0);
            this.ButKhuyenmai.Size = new System.Drawing.Size(343, 62);
            this.ButKhuyenmai.TabIndex = 9;
            this.ButKhuyenmai.Text = "Khuyến mãi";
            this.ButKhuyenmai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButKhuyenmai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButKhuyenmai.UseVisualStyleBackColor = true;
            this.ButKhuyenmai.Click += new System.EventHandler(this.iconButton1_Click_1);
            // 
            // FMainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1750, 900);
            this.Controls.Add(this.panelTitlebar);
            this.Controls.Add(this.paneltrangcon);
            this.Controls.Add(this.PanelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FMainControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tiệm điện";
            this.Load += new System.EventHandler(this.MainControl_Load);
            this.PanelMenu.ResumeLayout(false);
            this.PanelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelTitlebar.ResumeLayout(false);
            this.panelTitlebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconmenusmall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Panel PanelLogo;
        private FontAwesome.Sharp.IconButton btnhome;
        private FontAwesome.Sharp.IconButton btnKH;
        private FontAwesome.Sharp.IconButton btnHD;
        private FontAwesome.Sharp.IconButton btnNV;
        private FontAwesome.Sharp.IconButton btnSP;
        private FontAwesome.Sharp.IconButton btnlogout;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panelTitlebar;
        private FontAwesome.Sharp.IconPictureBox iconmenusmall;
        private System.Windows.Forms.Label labelcon;
        private System.Windows.Forms.Panel panelshadow;
        private System.Windows.Forms.Panel paneltrangcon;
        private FontAwesome.Sharp.IconButton iconExit;
        private FontAwesome.Sharp.IconButton iconMinimize;
        private System.Windows.Forms.Label lbDateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LabelUser;
        private FontAwesome.Sharp.IconButton ButDT;
        private FontAwesome.Sharp.IconButton ButKhuyenmai;
    }
}