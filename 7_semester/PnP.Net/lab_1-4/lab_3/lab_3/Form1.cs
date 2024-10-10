using lab_3;
using lab_3.Type;
using lab_3.Info;


namespace lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addToolStripMenuAdd_Click(object sender, EventArgs e)
        {

            Add add = new Add();
            add.ShowDialog();
            listShips.DataSource = Data.GetShips().ConvertAll(s => s.Name);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listShips.SelectedIndex == -1)
                return;
            Add add = new Add(listShips.SelectedIndex);
            add.ShowDialog();
            listShips.DataSource = Data.GetShips().ConvertAll(s => s.Name);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listShips.SelectedIndex == -1)
                return;
            Data.GetShips().RemoveAt(listShips.SelectedIndex);
            listShips.DataSource = Data.GetShips().ConvertAll(s => s.Name);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listShips.SelectedIndex == -1)
            {
                Show show = new Show();
                show.ShowDialog();
            }
            else
            {
                Show show = new Show(listShips.SelectedIndex);
                show.ShowDialog();
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            addToolStripMenuAdd_Click(sender, e);
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            editToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            deleteToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonShow_Click(object sender, EventArgs e)
        {
            showToolStripMenuItem_Click(sender, e);
        }
    }
}
