using System.Net;

namespace WinFormsGet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_downloadFile_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("https://localhost:7103/json", "fileWinForms.json");
            }
        }
    }
}
