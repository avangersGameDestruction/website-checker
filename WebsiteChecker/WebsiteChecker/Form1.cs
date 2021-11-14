using System;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;

namespace WebsiteChecker
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string website = textBox1.Text + textBox2.Text + comboBox1.SelectedItem;

            richTextBox1.Text = IsUrlValid(website).ToString();

            /* richTextBox1.Text == "true" || richTextBox1.Text == "True" ? richTextBox1.Text = website.ToString() + " = " + IsUrlValid(website).ToString() + "( is already in use )" : richTextBox1.Text = website.ToString() + " = " + IsUrlValid(website).ToString() + "( is not in use )"; */

            if (richTextBox1.Text == "true" || richTextBox1.Text== "True")
            {
                richTextBox1.Text = website.ToString() + " = " + IsUrlValid(website).ToString() + "( is already in use )";
            }

            else
            {
                richTextBox1.Text = website.ToString() + " = " + IsUrlValid(website).ToString() + "( is not in use )";
            }
        }

		public static bool IsUrlValid(string url)
		{
			return UrlChecker1(url);
		}

		public static bool UrlChecker1(string url)
		{
            try
            {
                WebRequest myRequest = WebRequest.Create(url);
                myRequest.Timeout = 5000;
                WebResponse myResponse = myRequest.GetResponse();
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        private void movefrm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
