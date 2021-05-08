using System.Windows.Forms;
namespace ItroublveTSC
{
    public partial class FileSize : global::System.Windows.Forms.Form
    {
        protected override void Dispose(bool disposing)
        {
            bool flag = disposing && components != null;
            bool flag2 = flag;
            if (flag2)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSize));
            this.HomeBtn = new System.Windows.Forms.Button();
            this.HeadLinePnlInf = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.pnlRainbowTop = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.HeadServerLbl = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.panel26 = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.panel36 = new System.Windows.Forms.Panel();
            this.PnlRainbowDown = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.FileSizeCount = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.mb_file = new System.Windows.Forms.RadioButton();
            this.gb_file = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.kb_file = new System.Windows.Forms.RadioButton();
            this.roundBtn1 = new RoundBtn();
            this.ApplyBtn = new RoundBtn();
            this.RainbowTimer = new System.Windows.Forms.Timer(this.components);
            this.WinInfo = new System.Windows.Forms.NotifyIcon(this.components);
            this.HeadLinePnlInf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // HomeBtn
            // 
            this.HomeBtn.FlatAppearance.BorderSize = 0;
            this.HomeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeBtn.ForeColor = System.Drawing.Color.White;
            this.HomeBtn.Location = new System.Drawing.Point(0, 28);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(96, 195);
            this.HomeBtn.TabIndex = 6342;
            this.HomeBtn.Text = "Back";
            this.HomeBtn.UseVisualStyleBackColor = true;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // HeadLinePnlInf
            // 
            this.HeadLinePnlInf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.HeadLinePnlInf.Controls.Add(this.button5);
            this.HeadLinePnlInf.Controls.Add(this.pnlRainbowTop);
            this.HeadLinePnlInf.Controls.Add(this.CloseBtn);
            this.HeadLinePnlInf.Controls.Add(this.HeadServerLbl);
            this.HeadLinePnlInf.Controls.Add(this.panel25);
            this.HeadLinePnlInf.Controls.Add(this.comboBox3);
            this.HeadLinePnlInf.Controls.Add(this.textBox3);
            this.HeadLinePnlInf.Controls.Add(this.button4);
            this.HeadLinePnlInf.Controls.Add(this.panel26);
            this.HeadLinePnlInf.Controls.Add(this.panel27);
            this.HeadLinePnlInf.Controls.Add(this.panel36);
            this.HeadLinePnlInf.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeadLinePnlInf.Location = new System.Drawing.Point(0, 0);
            this.HeadLinePnlInf.Name = "HeadLinePnlInf";
            this.HeadLinePnlInf.Size = new System.Drawing.Size(434, 27);
            this.HeadLinePnlInf.TabIndex = 6343;
            this.HeadLinePnlInf.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeadLinePnlInf_MouseDown);
            this.HeadLinePnlInf.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeadLinePnlInf_MouseMove);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(110)))), ((int)(((byte)(123)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Impact", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(373, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(29, 24);
            this.button5.TabIndex = 6224;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pnlRainbowTop
            // 
            this.pnlRainbowTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.pnlRainbowTop.Location = new System.Drawing.Point(0, 25);
            this.pnlRainbowTop.Name = "pnlRainbowTop";
            this.pnlRainbowTop.Size = new System.Drawing.Size(3814, 2);
            this.pnlRainbowTop.TabIndex = 6222;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(110)))), ((int)(((byte)(123)))));
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.CloseBtn.ForeColor = System.Drawing.Color.White;
            this.CloseBtn.Location = new System.Drawing.Point(408, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(26, 25);
            this.CloseBtn.TabIndex = 6167;
            this.CloseBtn.Text = "r";
            this.CloseBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // HeadServerLbl
            // 
            this.HeadServerLbl.AutoSize = true;
            this.HeadServerLbl.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadServerLbl.ForeColor = System.Drawing.Color.White;
            this.HeadServerLbl.Location = new System.Drawing.Point(117, 3);
            this.HeadServerLbl.Name = "HeadServerLbl";
            this.HeadServerLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HeadServerLbl.Size = new System.Drawing.Size(212, 21);
            this.HeadServerLbl.TabIndex = 6166;
            this.HeadServerLbl.Text = "ItroublveTSC | File Pumper";
            this.HeadServerLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeadServerLbl_MouseDown);
            this.HeadServerLbl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeadServerLbl_MouseMove);
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel25.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.panel25.Location = new System.Drawing.Point(362, -44);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(2, 25);
            this.panel25.TabIndex = 6160;
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.comboBox3.ForeColor = System.Drawing.Color.Silver;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(364, -44);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(254, 25);
            this.comboBox3.TabIndex = 6154;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(364, -42);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(231, 21);
            this.textBox3.TabIndex = 6156;
            this.textBox3.Text = " Voice Channel";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button4.ForeColor = System.Drawing.Color.Silver;
            this.button4.Location = new System.Drawing.Point(594, -43);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 22);
            this.button4.TabIndex = 6155;
            this.button4.Text = "6";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel26.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.panel26.Location = new System.Drawing.Point(364, -21);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(254, 2);
            this.panel26.TabIndex = 6157;
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel27.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.panel27.Location = new System.Drawing.Point(364, -44);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(254, 2);
            this.panel27.TabIndex = 6158;
            // 
            // panel36
            // 
            this.panel36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel36.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.panel36.Location = new System.Drawing.Point(617, -44);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(2, 25);
            this.panel36.TabIndex = 6159;
            // 
            // PnlRainbowDown
            // 
            this.PnlRainbowDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PnlRainbowDown.Location = new System.Drawing.Point(-1631, 223);
            this.PnlRainbowDown.Name = "PnlRainbowDown";
            this.PnlRainbowDown.Size = new System.Drawing.Size(3814, 2);
            this.PnlRainbowDown.TabIndex = 6344;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(0, 25);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(96, 197);
            this.panel7.TabIndex = 6347;
            // 
            // FileSizeCount
            // 
            this.FileSizeCount.AutoSize = true;
            this.FileSizeCount.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSizeCount.ForeColor = System.Drawing.Color.White;
            this.FileSizeCount.Location = new System.Drawing.Point(335, 68);
            this.FileSizeCount.Name = "FileSizeCount";
            this.FileSizeCount.Size = new System.Drawing.Size(19, 21);
            this.FileSizeCount.TabIndex = 6348;
            this.FileSizeCount.Text = "1";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(121, 44);
            this.trackBar1.Maximum = 999;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(239, 45);
            this.trackBar1.TabIndex = 6349;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // mb_file
            // 
            this.mb_file.AutoSize = true;
            this.mb_file.Checked = true;
            this.mb_file.ForeColor = System.Drawing.Color.White;
            this.mb_file.Location = new System.Drawing.Point(131, 109);
            this.mb_file.Name = "mb_file";
            this.mb_file.Size = new System.Drawing.Size(41, 17);
            this.mb_file.TabIndex = 6350;
            this.mb_file.TabStop = true;
            this.mb_file.Text = "MB";
            this.mb_file.UseVisualStyleBackColor = true;
            this.mb_file.CheckedChanged += new System.EventHandler(this.mb_file_CheckedChanged);
            // 
            // gb_file
            // 
            this.gb_file.AutoSize = true;
            this.gb_file.ForeColor = System.Drawing.Color.White;
            this.gb_file.Location = new System.Drawing.Point(131, 132);
            this.gb_file.Name = "gb_file";
            this.gb_file.Size = new System.Drawing.Size(40, 17);
            this.gb_file.TabIndex = 6351;
            this.gb_file.Text = "GB";
            this.gb_file.UseVisualStyleBackColor = true;
            this.gb_file.CheckedChanged += new System.EventHandler(this.gb_file_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox1.Enabled = false;
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(553, 218);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(20, 20);
            this.textBox1.TabIndex = 6354;
            this.textBox1.Visible = false;
            // 
            // kb_file
            // 
            this.kb_file.AutoSize = true;
            this.kb_file.ForeColor = System.Drawing.Color.White;
            this.kb_file.Location = new System.Drawing.Point(130, 86);
            this.kb_file.Name = "kb_file";
            this.kb_file.Size = new System.Drawing.Size(39, 17);
            this.kb_file.TabIndex = 6355;
            this.kb_file.Text = "KB";
            this.kb_file.UseVisualStyleBackColor = true;
            this.kb_file.CheckedChanged += new System.EventHandler(this.kb_file_CheckedChanged);
            // 
            // roundBtn1
            // 
            this.roundBtn1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.roundBtn1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.roundBtn1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.roundBtn1.FlatAppearance.BorderSize = 0;
            this.roundBtn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.roundBtn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.roundBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundBtn1.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold);
            this.roundBtn1.Location = new System.Drawing.Point(121, 174);
            this.roundBtn1.Name = "roundBtn1";
            this.roundBtn1.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(99)))), ((int)(((byte)(180)))));
            this.roundBtn1.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(99)))), ((int)(((byte)(180)))));
            this.roundBtn1.OnHoverTextColor = System.Drawing.Color.White;
            this.roundBtn1.Size = new System.Drawing.Size(179, 26);
            this.roundBtn1.TabIndex = 6353;
            this.roundBtn1.Text = "Upload File To Increase Size";
            this.roundBtn1.TextColor = System.Drawing.Color.White;
            this.roundBtn1.UseVisualStyleBackColor = true;
            this.roundBtn1.Click += new System.EventHandler(this.roundBtn1_Click);
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.ApplyBtn.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.ApplyBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.ApplyBtn.FlatAppearance.BorderSize = 0;
            this.ApplyBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.ApplyBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.ApplyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyBtn.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold);
            this.ApplyBtn.Location = new System.Drawing.Point(339, 174);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(99)))), ((int)(((byte)(180)))));
            this.ApplyBtn.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(99)))), ((int)(((byte)(180)))));
            this.ApplyBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.ApplyBtn.Size = new System.Drawing.Size(69, 27);
            this.ApplyBtn.TabIndex = 6352;
            this.ApplyBtn.Text = "Save";
            this.ApplyBtn.TextColor = System.Drawing.Color.White;
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // RainbowTimer
            // 
            this.RainbowTimer.Tick += new System.EventHandler(this.RainbowTimer_Tick);
            // 
            // WinInfo
            // 
            this.WinInfo.BalloonTipTitle = "ItroublveTSC";
            this.WinInfo.Icon = ((System.Drawing.Icon)(resources.GetObject("WinInfo.Icon")));
            this.WinInfo.Text = "ItroublveTSC";
            this.WinInfo.Visible = true;
            // 
            // MsgBox
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(434, 235);
            this.Controls.Add(this.kb_file);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.roundBtn1);
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.gb_file);
            this.Controls.Add(this.mb_file);
            this.Controls.Add(this.FileSizeCount);
            this.Controls.Add(this.PnlRainbowDown);
            this.Controls.Add(this.HeadLinePnlInf);
            this.Controls.Add(this.HomeBtn);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.trackBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItroublveTSC";
            this.HeadLinePnlInf.ResumeLayout(false);
            this.HeadLinePnlInf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private global::System.ComponentModel.IContainer components = null;
        //private global::System.Windows.Forms.Timer RainbowTimer;
        private global::System.Windows.Forms.Button HomeBtn;
        private global::System.Windows.Forms.Panel HeadLinePnlInf;
        private global::System.Windows.Forms.Panel pnlRainbowTop;
        private global::System.Windows.Forms.Button CloseBtn;
        private global:: System.Windows.Forms.Label HeadServerLbl;
        private global::System.Windows.Forms.Panel panel25;
        private global::System.Windows.Forms.ComboBox comboBox3;
        private global::System.Windows.Forms.TextBox textBox3;
        private global::System.Windows.Forms.Button button4;
        private global::System.Windows.Forms.Panel panel26;
        private global::System.Windows.Forms.Panel panel27;
        private global::System.Windows.Forms.Panel panel36;
        private Panel PnlRainbowDown;
        private Panel panel7;
        private Label FileSizeCount;
        private TrackBar trackBar1;
        private RadioButton mb_file;
        private RadioButton gb_file;
        private RoundBtn ApplyBtn;
        private RoundBtn roundBtn1;
        private TextBox textBox1;
        private RadioButton kb_file;
        private Timer RainbowTimer;
        private Button button5;
        private NotifyIcon WinInfo;
    }
}