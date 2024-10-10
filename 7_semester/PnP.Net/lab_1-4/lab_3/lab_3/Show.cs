using lab_3.Info;
using lab_3.Type;

namespace lab_3
{
    public partial class Show : Form
    {
        private const string EMPTY = "Empty"; 
        public Show()
        {
            InitializeComponent();
            List<Ship> shipList = Data.GetShips();
            if(shipList.Count == 0)
            {
                ShowEmpty();
            }
            else
            {
                CBShipNames.DataSource = shipList.ConvertAll(s => s.Name);
                CBShipNames.SelectedIndex = 0;
            }
        }

        public Show(int shipIndex) : this()
        {
            //InitializeComponent();
            ShowInfoShip(shipIndex);
            CBShipNames.SelectedIndex = shipIndex;
        }

        private void ShowInfoShip(int shipIndex)
        {
            labCabinCategories.Text = string.Empty;
            Ship ship = Data.GetShips()[shipIndex];
            labName.Text = ship.Name;
            labDisplacement.Text = ship.Displacement.ToString();
            labShipType.Text = ship.getShipType().ToString();

            List<CabinCategory> cabinCategories = ship.getCabinCategories();
            for (int i = 0; i < cabinCategories.Count; i++)
            {
                labCabinCategories.Text += cabinCategories[i].ToString() + Environment.NewLine;
            }
        }

        public void ShowEmpty()
        {
            labName.Text = EMPTY;
            labDisplacement.Text = EMPTY;
            labShipType.Text = EMPTY;
            labCabinCategories.Text = EMPTY;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CBShipNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowInfoShip(CBShipNames.SelectedIndex);
        }
    }
}
