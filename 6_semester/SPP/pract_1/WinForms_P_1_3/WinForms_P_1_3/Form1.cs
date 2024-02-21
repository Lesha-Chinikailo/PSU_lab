using System.Net;
using System.Net.WebSockets;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WinForms_P_1_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetPhoto();
        }
        private async void GetPhoto()
        {
            WebRequest request =
            WebRequest.Create("https://localhost:7103/image");
            WebResponse response;
            try
            {
                response = await request.GetResponseAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
                throw;
            }


            Stream responseStream = response.GetResponseStream();

            Bitmap bitmapImg = new Bitmap(responseStream);

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = bitmapImg;
        }

        private async void GetText()
        {
            WebRequest request =
            WebRequest.Create("https://localhost:7103/text");
            WebResponse response;
            try
            {
                response = await request.GetResponseAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("the server is not running");
                return;
                throw;
            }


            Stream responseStream = response.GetResponseStream();
            string text = string.Empty;
            using (var reader = new StreamReader(responseStream, encoding: Encoding.UTF8))
            {
                text = reader.ReadToEnd();
            }
            label_text.Text = text;
        }
        private async void GetJson()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("https://localhost:7103/json", "C:\\Users\\Lesha\\Downloads\\FileJsonWinForms.json");
            }
            MessageBox.Show("file downloaded");
        }

        private void btn_getText_Click(object sender, EventArgs e)
        {
            GetText();

        }

        private void btn_loadFile_Click(object sender, EventArgs e)
        {
            GetJson();
        }
    }
}
