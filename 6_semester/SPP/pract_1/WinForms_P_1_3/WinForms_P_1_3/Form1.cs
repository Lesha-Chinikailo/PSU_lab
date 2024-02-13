using System.Net;
using System.Net.WebSockets;
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
            //WebClient client = new WebClient();
            //Stream stream = client.OpenRead("https://localhost:7103/image");
            //StreamReader sr = new StreamReader(stream);
            //var s = sr.ReadToEnd();

            WebRequest request =
            WebRequest.Create("https://localhost:7103/image");
            WebResponse response;
            try
            {
                response = request.GetResponse();
            }
            catch (Exception)
            {
                MessageBox.Show("the server is not running");
                return;
                throw;
            }


            Stream responseStream = response.GetResponseStream();

            Bitmap bitmapImg = new Bitmap(responseStream);

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = bitmapImg;
            //stream.Close();
        }
    }
}
