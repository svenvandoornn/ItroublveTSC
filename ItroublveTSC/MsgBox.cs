using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using DiscordFlooder.Class.Design.Rainbow;
using ItroublveTSC;

namespace ItroublveTSC2
{
	public partial class frm2 : Form
	{
        #region GUI
        public frm2()
		{
			InitializeComponent();
			RainbowTimer.Start();
		}

		private void RainbowTimer_Tick(object sender, EventArgs e)
		{
			Rainbow.RainbowEffect();
            pnlRainbowTop.BackColor = Color.FromArgb(Rainbow.A, Rainbow.R, Rainbow.G);
			panel37.BackColor = Color.FromArgb(Rainbow.A, Rainbow.R, Rainbow.G);
		}

		private void frm2_Load(object sender, EventArgs e)
		{
			Dropdown.Text = "OK";
		}
        #region ClsBtn
        private void CloseBtn_Click(object sender, EventArgs e)
		{
			Close();
		}
        #endregion
        private void HeadServerLbl_MouseDown(object sender, MouseEventArgs e)
		{
			Mouse.x = MousePosition.X - Location.X;
			Mouse.y = MousePosition.Y - Location.Y;
		}

		private void HeadServerLbl_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Mouse.newpoint = MousePosition;
				Mouse.newpoint.X = Mouse.newpoint.X - Mouse.x;
				Mouse.newpoint.Y = Mouse.newpoint.Y - Mouse.y;
				Location = Mouse.newpoint;
			}
		}
		private void roundBtn1_Click_1(object sender, EventArgs e)
		{
			Close();
		}
		#endregion
		#region Compile chng
		private void roundBtn1_Click(object sender, EventArgs e)
        {
			string Temp = Path.GetTempPath();
			if (!File.Exists(Temp + "bin_copy/Program.cs"))
            {
				try
                {
					string test = @"bin";
					string test2 = Temp + @"bin_copy";
					frmMain.Copy(test, test2);
				}
				catch (Exception ex)
                {
					MessageBox.Show(ex.Message, "ItroublveTSC");
				}
			}
            try
            {
				string drop = null;
				string text = File.ReadAllText(Temp + "bin_copy/Program.cs");
				if (MessageDescTxt.Text == "Message")
				{
					MessageBox.Show("Specify a message!", "ItroublveTSC");
					return;
				}
				else
				{
					text = text.Replace("Your Desc", MessageDescTxt.Text);
				}
				if (MessageTitleTxt.Text == "Title")
                {
					text = text.Replace("Your Title", "");
				}
                else
                {
					text = text.Replace("Your Title", MessageTitleTxt.Text);
				}
				text = text.Replace("//AMessageBox", "MessageBox");
				if (Dropdown.Text != null)
				{
					if (Dropdown.Text == "Yes/No")
					{
						drop = "YesNo";
					}
					else if (Dropdown.Text == "OK")
					{
						drop = "OK";
					}
					else if (Dropdown.Text == "Yes/No/Cancel")
					{
						drop = "YesNoCancel";
					}
					else if (Dropdown.Text == "OK/Cancel")
					{
						drop = "OKCancel";
					}
					else if (Dropdown.Text == "Abort/Retry/Ignore")
					{
						drop = "AbortRetryIgnore";
					}
					text = text.Replace("btn", drop);
				}
				else
				{
					text = text.Replace("btn", "OK");
				}
				if (None.Checked)
				{
					text = text.Replace("gaay", "None");
				}
				else if (Warning.Checked)
				{
					text = text.Replace("gaay", "Warning");
				}
				else if (Info.Checked)
				{
					text = text.Replace("gaay", "Information");
				}
				else if (Error.Checked)
				{
					text = text.Replace("gaay", "Error");
				}
				else if (question.Checked)
				{
					text = text.Replace("gaay", "Question");
				}
				File.WriteAllText(Temp + "bin_copy/Program.cs", text);
				Hide();
			}
			catch (Exception ex)
            {
				if (!Directory.Exists(Application.StartupPath + "\\bin"))
				{
					Directory.Delete(Path.GetTempPath() + "bin_copy", true);
					DialogResult dialogResult = MessageBox.Show("bin folder or files inside missing or modified!\r\n" + "Want to download bin files from Github?", "ItroublveTSC", MessageBoxButtons.YesNo);
					if (dialogResult == DialogResult.Yes)
					{
						string _cdDir = Path.GetDirectoryName(Application.ExecutablePath);
						DirectoryInfo di = Directory.CreateDirectory(_cdDir);
						using (WebClient webClient = new WebClient())
							webClient.DownloadFile("https://raw.githubusercontent.com/Itroublve/Token-Browser-Password-Stealer-Creator/6.0/AVOID%20ME/bin.zip", "Token Stealer Creator.zip");
						ZipFile.ExtractToDirectory(_cdDir + "\\Token Stealer Creator.zip", _cdDir);
						File.Delete(_cdDir + "\\Token Stealer Creator.zip");
						MessageBox.Show("Successfully downloaded and installed\nYou can continue now!", "ItroublveTSC");
						return;
					}
					else if (dialogResult == DialogResult.No)
					{
						MessageBox.Show("OK. FINE THEN. DO WHATEVER YOU WANT . -.", "ItroublveTSC");
						return;
					}
				}
				else
					MessageBox.Show(ex.Message, "ItroublveTSC");
			}
        }
        #endregion
        #region Placeholder
        private void MessageTitleTxt_Enter(object sender, EventArgs e)
        {
			if (MessageTitleTxt.Text == "Title")
			{
				MessageTitleTxt.Text = "";
			}
		}

        private void MessageTitleTxt_Leave(object sender, EventArgs e)
        {
			if (MessageTitleTxt.Text == "")
			{
				MessageTitleTxt.Text = "Title";
			}
		}
		private void MessageDescTxt_Enter(object sender, EventArgs e)
		{
			if (MessageDescTxt.Text == "Message")
			{
				MessageDescTxt.Text = "";
			}
		}
		private void MessageDescTxt_Leave(object sender, EventArgs e)
		{
			if (MessageDescTxt.Text == "")
			{
				MessageDescTxt.Text = "Message";
			}
		}
		#endregion
		#region Preview MessageBox
		private void roundBtn2_Click(object sender, EventArgs e)
        {
			bool flag = MessageTitleTxt.Text == "Title" || MessageTitleTxt.Text == "Title";
			bool flag1 = MessageDescTxt.Text == "" || MessageDescTxt.Text == "Message";
			if (!flag1)
            {
				if (None.Checked && Dropdown.Text == "OK")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.OK, MessageBoxIcon.None);
					}
					else
					{
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
					}
				}
				else if (None.Checked && Dropdown.Text == "Yes/No")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.None);
					}
					else
					{
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.YesNo, MessageBoxIcon.None);
					}
				}
				else if (None.Checked && Dropdown.Text == "Yes/No/Cancel")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
					}
				}
				else if (None.Checked && Dropdown.Text == "OK/Cancel")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.None);
					}
				}
				else if (None.Checked && Dropdown.Text == "Abort/Retry/Ignore")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.None);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.None);
					}
				}
				else if (Info.Checked && Dropdown.Text == "OK" || Info.Checked && Dropdown.Text == "")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else if (Info.Checked && Dropdown.Text == "Yes/No")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
					}
				}
				else if (Info.Checked && Dropdown.Text == "Yes/No/Cancel")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
					}
				}
				else if (Info.Checked && Dropdown.Text == "OK/Cancel")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
					}
				}
				else if (Info.Checked && Dropdown.Text == "Abort/Retry/Ignore")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
					}
				}
				else if (question.Checked && Dropdown.Text == "OK" || question.Checked && Dropdown.Text == "")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.OK, MessageBoxIcon.Question);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.OK, MessageBoxIcon.Question);
					}
				}
				else if (question.Checked && Dropdown.Text == "Yes/No")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					}
				}
				else if (question.Checked && Dropdown.Text == "Yes/No/Cancel")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					}
				}
				else if (question.Checked && Dropdown.Text == "OK/Cancel")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
					}
				}
				else if (question.Checked && Dropdown.Text == "Abort/Retry/Ignore")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
                    }
				}
				else if (Error.Checked && Dropdown.Text == "OK" || Error.Checked && Dropdown.Text == "")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else if (Error.Checked && Dropdown.Text == "Yes/No")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
					}
				}
				else if (Error.Checked && Dropdown.Text == "Yes/No/Cancel")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
					}
				}
				else if (Error.Checked && Dropdown.Text == "OK/Cancel")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
					}
				}
				else if (Error.Checked && Dropdown.Text == "Abort/Retry/Ignore")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
					}
                    else
					{
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
					}
				}
				else if (Warning.Checked && Dropdown.Text == "OK" || Warning.Checked && Dropdown.Text == "")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				else if (Warning.Checked && Dropdown.Text == "Yes/No")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					}
				}
				else if (Warning.Checked && Dropdown.Text == "Yes/No/Cancel")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
					}
                    else
                    {
						string[] split = MessageDescTxt.Text.Split('\\');
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
					}
				}
				else if (Warning.Checked && Dropdown.Text == "OK/Cancel")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
					}
				}
				else if (Warning.Checked && Dropdown.Text == "Abort/Retry/Ignore")
				{
					if (flag)
					{
						MessageBox.Show(MessageDescTxt.Text, "", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
					}
                    else
                    {
						MessageBox.Show(MessageDescTxt.Text, MessageTitleTxt.Text, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
					}
				}
				else
				{
					MessageBox.Show("Unable to display MessageBox!", "ItroublveTSC");
				}
			}
			else
            {
				MessageBox.Show("Specify a message!", "ItroublveTSC");
			}
        }
        #endregion
    }
}
