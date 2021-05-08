namespace ItroublveTSC2
{
    public partial class frm2 : global::System.Windows.Forms.Form
    {
        protected override void Dispose(bool disposing)
        {
            bool flag = disposing && components != null;
            if (flag)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2));
            this.RainbowTimer = new System.Windows.Forms.Timer(this.components);
            this.HeadLinePnlInf = new System.Windows.Forms.Panel();
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
            this.panel37 = new System.Windows.Forms.Panel();
            this.WinInfo = new System.Windows.Forms.NotifyIcon(this.components);
            this.WebhookPnl = new System.Windows.Forms.Panel();
            this.MessageTitleTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MessageDescTxt = new System.Windows.Forms.TextBox();
            this.Dropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ErrorPicBox = new System.Windows.Forms.PictureBox();
            this.QuestionPicbox = new System.Windows.Forms.PictureBox();
            this.Infopicbox = new System.Windows.Forms.PictureBox();
            this.WarningPicBox = new System.Windows.Forms.PictureBox();
            this.None = new System.Windows.Forms.RadioButton();
            this.Error = new System.Windows.Forms.RadioButton();
            this.Warning = new System.Windows.Forms.RadioButton();
            this.question = new System.Windows.Forms.RadioButton();
            this.Info = new System.Windows.Forms.RadioButton();
            this.roundBtn2 = new RoundBtn();
            this.SaveMsgboxChng = new RoundBtn();
            this.HeadLinePnlInf.SuspendLayout();
            this.WebhookPnl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionPicbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Infopicbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarningPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // RainbowTimer
            // 
            this.RainbowTimer.Tick += new System.EventHandler(this.RainbowTimer_Tick);
            // 
            // HeadLinePnlInf
            // 
            this.HeadLinePnlInf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
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
            this.HeadLinePnlInf.Size = new System.Drawing.Size(571, 26);
            this.HeadLinePnlInf.TabIndex = 6306;
            // 
            // pnlRainbowTop
            // 
            this.pnlRainbowTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.pnlRainbowTop.Location = new System.Drawing.Point(-2, 24);
            this.pnlRainbowTop.Name = "pnlRainbowTop";
            this.pnlRainbowTop.Size = new System.Drawing.Size(3614, 2);
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
            this.CloseBtn.Location = new System.Drawing.Point(545, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(26, 24);
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
            this.HeadServerLbl.Location = new System.Drawing.Point(223, 5);
            this.HeadServerLbl.Name = "HeadServerLbl";
            this.HeadServerLbl.Size = new System.Drawing.Size(115, 21);
            this.HeadServerLbl.TabIndex = 6166;
            this.HeadServerLbl.Text = "MESSAGEBOX";
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
            this.comboBox3.Location = new System.Drawing.Point(364, -41);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(234, 25);
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
            // panel37
            // 
            this.panel37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel37.Location = new System.Drawing.Point(-1231, 300);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(3614, 2);
            this.panel37.TabIndex = 6307;
            // 
            // WebhookPnl
            // 
            this.WebhookPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.WebhookPnl.Controls.Add(this.MessageTitleTxt);
            this.WebhookPnl.Location = new System.Drawing.Point(19, 45);
            this.WebhookPnl.Name = "WebhookPnl";
            this.WebhookPnl.Size = new System.Drawing.Size(129, 33);
            this.WebhookPnl.TabIndex = 6341;
            // 
            // MessageTitleTxt
            // 
            this.MessageTitleTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.MessageTitleTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageTitleTxt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageTitleTxt.ForeColor = System.Drawing.Color.DarkGray;
            this.MessageTitleTxt.Location = new System.Drawing.Point(7, 7);
            this.MessageTitleTxt.Name = "MessageTitleTxt";
            this.MessageTitleTxt.Size = new System.Drawing.Size(379, 18);
            this.MessageTitleTxt.TabIndex = 6153;
            this.MessageTitleTxt.Text = "Title";
            this.MessageTitleTxt.Enter += new System.EventHandler(this.MessageTitleTxt_Enter);
            this.MessageTitleTxt.Leave += new System.EventHandler(this.MessageTitleTxt_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.MessageDescTxt);
            this.panel1.Location = new System.Drawing.Point(154, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 33);
            this.panel1.TabIndex = 6342;
            // 
            // MessageDescTxt
            // 
            this.MessageDescTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.MessageDescTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageDescTxt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageDescTxt.ForeColor = System.Drawing.Color.DarkGray;
            this.MessageDescTxt.Location = new System.Drawing.Point(7, 7);
            this.MessageDescTxt.Name = "MessageDescTxt";
            this.MessageDescTxt.Size = new System.Drawing.Size(379, 18);
            this.MessageDescTxt.TabIndex = 6153;
            this.MessageDescTxt.Text = "Message";
            this.MessageDescTxt.Enter += new System.EventHandler(this.MessageDescTxt_Enter);
            this.MessageDescTxt.Leave += new System.EventHandler(this.MessageDescTxt_Leave);
            // 
            // Dropdown
            // 
            this.Dropdown.BackColor = System.Drawing.Color.White;
            this.Dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Dropdown.FormattingEnabled = true;
            this.Dropdown.Items.AddRange(new object[] {
            "Yes/No",
            "OK",
            "Yes/No/Cancel",
            "OK/Cancel",
            "Abort/Retry/Ignore"});
            this.Dropdown.Location = new System.Drawing.Point(40, 132);
            this.Dropdown.Name = "Dropdown";
            this.Dropdown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dropdown.Size = new System.Drawing.Size(158, 21);
            this.Dropdown.TabIndex = 6343;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 6344;
            this.label1.Text = "Buttons";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Location = new System.Drawing.Point(19, 87);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(530, 133);
            this.panel2.TabIndex = 6347;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(258, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Icons";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.ErrorPicBox);
            this.panel3.Controls.Add(this.QuestionPicbox);
            this.panel3.Controls.Add(this.Infopicbox);
            this.panel3.Controls.Add(this.WarningPicBox);
            this.panel3.Controls.Add(this.None);
            this.panel3.Controls.Add(this.Error);
            this.panel3.Controls.Add(this.Warning);
            this.panel3.Controls.Add(this.question);
            this.panel3.Controls.Add(this.Info);
            this.panel3.Location = new System.Drawing.Point(262, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(224, 97);
            this.panel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "None";
            // 
            // ErrorPicBox
            // 
            this.ErrorPicBox.Image = ((System.Drawing.Image)(resources.GetObject("ErrorPicBox.Image")));
            this.ErrorPicBox.Location = new System.Drawing.Point(133, 26);
            this.ErrorPicBox.Name = "ErrorPicBox";
            this.ErrorPicBox.Size = new System.Drawing.Size(31, 29);
            this.ErrorPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ErrorPicBox.TabIndex = 8;
            this.ErrorPicBox.TabStop = false;
            // 
            // QuestionPicbox
            // 
            this.QuestionPicbox.Image = ((System.Drawing.Image)(resources.GetObject("QuestionPicbox.Image")));
            this.QuestionPicbox.Location = new System.Drawing.Point(56, 26);
            this.QuestionPicbox.Name = "QuestionPicbox";
            this.QuestionPicbox.Size = new System.Drawing.Size(31, 29);
            this.QuestionPicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QuestionPicbox.TabIndex = 7;
            this.QuestionPicbox.TabStop = false;
            // 
            // Infopicbox
            // 
            this.Infopicbox.Image = ((System.Drawing.Image)(resources.GetObject("Infopicbox.Image")));
            this.Infopicbox.Location = new System.Drawing.Point(18, 26);
            this.Infopicbox.Name = "Infopicbox";
            this.Infopicbox.Size = new System.Drawing.Size(31, 29);
            this.Infopicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Infopicbox.TabIndex = 6;
            this.Infopicbox.TabStop = false;
            // 
            // WarningPicBox
            // 
            this.WarningPicBox.Image = ((System.Drawing.Image)(resources.GetObject("WarningPicBox.Image")));
            this.WarningPicBox.Location = new System.Drawing.Point(94, 26);
            this.WarningPicBox.Name = "WarningPicBox";
            this.WarningPicBox.Size = new System.Drawing.Size(31, 29);
            this.WarningPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WarningPicBox.TabIndex = 5;
            this.WarningPicBox.TabStop = false;
            // 
            // None
            // 
            this.None.AutoSize = true;
            this.None.Checked = true;
            this.None.Location = new System.Drawing.Point(183, 61);
            this.None.Name = "None";
            this.None.Size = new System.Drawing.Size(14, 13);
            this.None.TabIndex = 4;
            this.None.TabStop = true;
            this.None.UseVisualStyleBackColor = true;
            // 
            // Error
            // 
            this.Error.AutoSize = true;
            this.Error.Location = new System.Drawing.Point(142, 61);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(14, 13);
            this.Error.TabIndex = 3;
            this.Error.UseVisualStyleBackColor = true;
            // 
            // Warning
            // 
            this.Warning.AutoSize = true;
            this.Warning.Location = new System.Drawing.Point(103, 61);
            this.Warning.Name = "Warning";
            this.Warning.Size = new System.Drawing.Size(14, 13);
            this.Warning.TabIndex = 2;
            this.Warning.UseVisualStyleBackColor = true;
            // 
            // question
            // 
            this.question.AutoSize = true;
            this.question.Location = new System.Drawing.Point(65, 61);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(14, 13);
            this.question.TabIndex = 1;
            this.question.UseVisualStyleBackColor = true;
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Location = new System.Drawing.Point(27, 61);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(14, 13);
            this.Info.TabIndex = 0;
            this.Info.UseVisualStyleBackColor = true;
            // 
            // roundBtn2
            // 
            this.roundBtn2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.roundBtn2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.roundBtn2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.roundBtn2.FlatAppearance.BorderSize = 0;
            this.roundBtn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.roundBtn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.roundBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundBtn2.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold);
            this.roundBtn2.Location = new System.Drawing.Point(439, 226);
            this.roundBtn2.Name = "roundBtn2";
            this.roundBtn2.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(99)))), ((int)(((byte)(180)))));
            this.roundBtn2.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(99)))), ((int)(((byte)(180)))));
            this.roundBtn2.OnHoverTextColor = System.Drawing.Color.White;
            this.roundBtn2.Size = new System.Drawing.Size(110, 26);
            this.roundBtn2.TabIndex = 6346;
            this.roundBtn2.Text = "Preview";
            this.roundBtn2.TextColor = System.Drawing.Color.White;
            this.roundBtn2.UseVisualStyleBackColor = true;
            this.roundBtn2.Click += new System.EventHandler(this.roundBtn2_Click);
            // 
            // SaveMsgboxChng
            // 
            this.SaveMsgboxChng.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.SaveMsgboxChng.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.SaveMsgboxChng.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.SaveMsgboxChng.FlatAppearance.BorderSize = 0;
            this.SaveMsgboxChng.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.SaveMsgboxChng.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.SaveMsgboxChng.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveMsgboxChng.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold);
            this.SaveMsgboxChng.Location = new System.Drawing.Point(48, 258);
            this.SaveMsgboxChng.Name = "SaveMsgboxChng";
            this.SaveMsgboxChng.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(99)))), ((int)(((byte)(180)))));
            this.SaveMsgboxChng.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(99)))), ((int)(((byte)(180)))));
            this.SaveMsgboxChng.OnHoverTextColor = System.Drawing.Color.White;
            this.SaveMsgboxChng.Size = new System.Drawing.Size(82, 27);
            this.SaveMsgboxChng.TabIndex = 6340;
            this.SaveMsgboxChng.Text = "OK";
            this.SaveMsgboxChng.TextColor = System.Drawing.Color.White;
            this.SaveMsgboxChng.UseVisualStyleBackColor = true;
            this.SaveMsgboxChng.Click += new System.EventHandler(this.roundBtn1_Click);
            // 
            // frm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(571, 318);
            this.Controls.Add(this.roundBtn2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dropdown);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.WebhookPnl);
            this.Controls.Add(this.SaveMsgboxChng);
            this.Controls.Add(this.panel37);
            this.Controls.Add(this.HeadLinePnlInf);
            this.Controls.Add(this.panel2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItroublveTSC";
            this.Load += new System.EventHandler(this.frm2_Load);
            this.HeadLinePnlInf.ResumeLayout(false);
            this.HeadLinePnlInf.PerformLayout();
            this.WebhookPnl.ResumeLayout(false);
            this.WebhookPnl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionPicbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Infopicbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarningPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private global::System.ComponentModel.IContainer components = null;

        private global::System.Windows.Forms.Timer RainbowTimer;

        private global::System.Windows.Forms.Panel HeadLinePnlInf;

        private global::System.Windows.Forms.Panel pnlRainbowTop;

        private global::System.Windows.Forms.Button CloseBtn;

        private global::System.Windows.Forms.Label HeadServerLbl;

        private global::System.Windows.Forms.Panel panel25;

        private global::System.Windows.Forms.ComboBox comboBox3;

        private global::System.Windows.Forms.TextBox textBox3;

        private global::System.Windows.Forms.Button button4;

        private global::System.Windows.Forms.Panel panel26;

        private global::System.Windows.Forms.Panel panel27;

        private global::System.Windows.Forms.Panel panel36;

        private global::System.Windows.Forms.Panel panel37;

        private global::System.Windows.Forms.NotifyIcon WinInfo;
        private RoundBtn SaveMsgboxChng;
        private System.Windows.Forms.Panel WebhookPnl;
        private System.Windows.Forms.TextBox MessageTitleTxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox MessageDescTxt;
        private System.Windows.Forms.ComboBox Dropdown;
        private System.Windows.Forms.Label label1;
        private RoundBtn roundBtn2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton Info;
        private System.Windows.Forms.RadioButton Error;
        private System.Windows.Forms.RadioButton Warning;
        private System.Windows.Forms.RadioButton question;
        private System.Windows.Forms.RadioButton None;
        private System.Windows.Forms.PictureBox WarningPicBox;
        private System.Windows.Forms.PictureBox ErrorPicBox;
        private System.Windows.Forms.PictureBox QuestionPicbox;
        private System.Windows.Forms.PictureBox Infopicbox;
        private System.Windows.Forms.Label label3;
    }
}