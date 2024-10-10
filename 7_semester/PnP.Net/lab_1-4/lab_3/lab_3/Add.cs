using lab_3.Type;
using lab_3.Info;

namespace lab_3
{
    public partial class Add : Form
    {
        private ShipType shipType;
        int? shipIndex;
        public Add()
        {
            InitializeComponent();
        }

        public Add(int shipIndex) : this()
        {
            Ship ship = Data.GetShips()[shipIndex];
            txbName.Text = ship.Name;
            txbDisplacement.Text = ship.Displacement.ToString();
            if (ship.getShipType() == ShipType.CargoShip)
            {
                RBCargoShip.Checked = true;
            }
            else if (ship.getShipType() == ShipType.PassengerShip)
            {
                RBPassengerShip.Checked = true;
            }
            else
            {
                RBIndustrialShip.Checked = true;
            }

            List<CabinCategory> cabinCategories = ship.getCabinCategories();
            List<string> str = cabinCategories.ConvertAll(c => c.ToString());
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (str.Contains(checkedListBox.Items[i].ToString()))
                {
                    checkedListBox.SetItemChecked(i, true);
                }
            }

            this.shipIndex = shipIndex;
        }

        public Add(int shipIndex, bool isShow) : this(shipIndex)
        {
            txbDisplacement.ReadOnly = isShow;
            txbName.ReadOnly = isShow;
            RBCargoShip.Enabled = isShow;
            RBPassengerShip.Enabled = isShow;
            RBIndustrialShip.Enabled = isShow;
            checkedListBox.Enabled = isShow;
            btnAccept.Enabled = isShow;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!CheckValues())
                return;
            var categories = Data.getCabinCategories();
            Ship ship = new PassengerShip();
            ship.Name = txbName.Text;
            ship.Displacement = float.Parse(txbDisplacement.Text);
            ship.setShipType(shipType);
            List<CabinCategory> cabinCategories = new List<CabinCategory>();
            foreach (var item in checkedListBox.CheckedItems)
            {
                cabinCategories.Add(categories[item.ToString()]);
            }
            ship.setCabinCategories(cabinCategories);

            //Form1 form = new Form1();
            //form.AddShip(ship);
            if(!shipIndex.HasValue)
            {
                Data.GetShips().Add(ship);
            }
            else
            {
                DialogResult answer = MessageBox.Show("you sure that want to change this item?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(answer == DialogResult.Yes)
                {
                    Data.GetShips()[shipIndex.Value] = ship;
                }
                else
                {
                    return;
                }

            }

            Close();
        }

        private bool CheckValues()
        {
            bool isValuesCorrect = true;
            string message = string.Empty;
            if (string.IsNullOrEmpty(txbName.Text))
            {
                isValuesCorrect = false;
                message += "text box Name must not empty\n";
            }
            if (string.IsNullOrEmpty(txbDisplacement.Text))
            {
                isValuesCorrect = false;
                message += "text box Displacement must not empty\n";
            }
            else
            {
                if (!float.TryParse(txbDisplacement.Text, out float value))
                {
                    isValuesCorrect = false;
                    message += "text box Displacement must be number\n";
                }
            }
            if (!RBCargoShip.Checked && !RBPassengerShip.Checked && !RBIndustrialShip.Checked)
            {
                isValuesCorrect = false;
                message += "you need to check any ship type\n";
            }
            else
            {

            }
            if (checkedListBox.CheckedItems.Count == 0)
            {
                isValuesCorrect = false;
                message += "you need to check any cabin categories\n";
            }

            if (!isValuesCorrect)
            {
                MessageBox.Show(message);
            }
            return isValuesCorrect;
        }

        private void RBCargoShip_CheckedChanged(object sender, EventArgs e)
        {
            shipType = ShipType.CargoShip;
        }

        private void RBPassengerShip_CheckedChanged(object sender, EventArgs e)
        {
            shipType = ShipType.PassengerShip;
        }

        private void RBIndustrialShip_CheckedChanged(object sender, EventArgs e)
        {
            shipType = ShipType.IndustrialShip;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
    }
}
