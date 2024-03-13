using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_BD_6.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Wpf_BD_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Lab1Context _db = new Lab1Context();
        public MainWindow()
        {
            InitializeComponent();
            //_db.Database.SetConnectionString("Server=DESKTOP-501ABTG;Database=lab_1;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true;");
            InitializeTables();
        }

        private async void InitializeTables()
        {
            gridTableSpeciality.ItemsSource = await _db.Specialities.ToListAsync();
            gridTableWorker.ItemsSource = await _db.Workers.ToListAsync();
            gridTableBrigade.ItemsSource = await _db.Brigades.ToListAsync();
            gridTableDepartment.ItemsSource = await _db.Departments.ToListAsync();
        }


        private async void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            int i;
            switch(TabControlTable.SelectedIndex)
            {
                case 0:
                    if(!decimal.TryParse(txb_SalaryOneRate.Text, out decimal d))
                    {
                        MessageBox.Show("you entered incorrect data");
                        return;
                    }
                    Speciality speciality = new Speciality()
                    {
                        NameSpeciality = txb_NameSpeciality.Text,
                        Description = txb_DescriptionSpeciality.Text,
                        SalaryOneRate = decimal.Parse(txb_SalaryOneRate.Text)
                    };
                    _db.Specialities.Add(speciality);
                    _db.SaveChanges();
                    gridTableSpeciality.ItemsSource = await _db.Specialities.ToListAsync();
                    break;
                case 1:
                    if (!int.TryParse(txb_IdBrigade.Text, out i) || !int.TryParse(txb_IdSpeciality.Text, out i) || !double.TryParse(txb_Rate.Text, out double dou))
                    {
                        MessageBox.Show("you entered incorrect data");
                        return;
                    }
                    Worker worker = new Worker()
                    {
                        Name = txb_NameWorker.Text,
                        Surname = txb_SurnameWorker.Text,
                        Email = txb_Email.Text,
                        Rate = double.Parse(txb_Rate.Text),
                        IdBrigade = int.Parse(txb_IdBrigade.Text),
                        IdSpeciality = int.Parse(txb_IdSpeciality.Text)
                    };
                    _db.Workers.Add(worker);
                    _db.SaveChanges();
                    gridTableWorker.ItemsSource = await _db.Workers.ToListAsync();
                    break;
                case 2:
                    if (!int.TryParse(txb_CountOfWorkers.Text, out i) || !int.TryParse(txb_IdDepartment.Text, out i))
                    {
                        MessageBox.Show("you entered incorrect data");
                        return;
                    }
                    Brigade brigade = new Brigade()
                    {
                        CountWorker = int.Parse(txb_CountOfWorkers.Text),
                        TypeBrigade = txb_TypeBrigade.Text,
                        IdDepartment = int.Parse(txb_IdDepartment.Text),
                    };
                    _db.Brigades.Add(brigade);
                    _db.SaveChanges();
                    gridTableBrigade.ItemsSource = await _db.Brigades.ToListAsync();
                    break;
                case 3:
                    if (!int.TryParse(txb_CountOfBrigade.Text, out i))
                    {
                        MessageBox.Show("you entered incorrect data");
                        return;
                    }
                    Department department = new Department()
                    {
                        NameDepartment = txb_NameDepartment.Text,
                        DescriptionDepartment = txb_DescriptionDepartment.Text,
                        CountBrigade = int.Parse(txb_CountOfBrigade.Text),
                    };
                    _db.Departments.Add(department);
                    _db.SaveChanges();
                    gridTableDepartment.ItemsSource = await _db.Departments.ToListAsync();
                    break;
                default:
                    break;
            }
        }

        private async void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            int i;
            switch (TabControlTable.SelectedIndex)
            {
                case 0:
                    if (!decimal.TryParse(txb_SalaryOneRate.Text, out decimal d))
                    {
                        MessageBox.Show("you entered incorrect data");
                        return;
                    }
                    Speciality speciality = (Speciality)gridTableSpeciality.SelectedItem;
                    int id = speciality.IdSpeciality;
                    _db.Specialities.Where(x => x.IdSpeciality == id).Single().NameSpeciality = txb_NameSpeciality.Text;
                    _db.Specialities.Where(x => x.IdSpeciality == id).Single().Description = txb_DescriptionSpeciality.Text;
                    _db.Specialities.Where(x => x.IdSpeciality == id).Single().SalaryOneRate = decimal.Parse(txb_SalaryOneRate.Text);
                    _db.SaveChanges();
                    gridTableSpeciality.ItemsSource = await _db.Specialities.ToListAsync();
                    break;
                case 1:
                    if (!int.TryParse(txb_IdBrigade.Text, out i) || !int.TryParse(txb_IdSpeciality.Text, out i) || !double.TryParse(txb_Rate.Text, out double dou))
                    {
                        MessageBox.Show("you entered incorrect data");
                        return;
                    }
                    Worker worker = (Worker)gridTableWorker.SelectedItem;
                    id = worker.IdWorker;
                    _db.Workers.Where(x => x.IdWorker == id).Single().Name = txb_NameWorker.Text;
                    _db.Workers.Where(x => x.IdWorker == id).Single().Surname = txb_SurnameWorker.Text;
                    _db.Workers.Where(x => x.IdWorker == id).Single().Email = txb_Email.Text;
                    _db.Workers.Where(x => x.IdWorker == id).Single().Rate = double.Parse(txb_Rate.Text);
                    _db.Workers.Where(x => x.IdWorker == id).Single().IdBrigade = int.Parse(txb_IdBrigade.Text);
                    _db.Workers.Where(x => x.IdWorker == id).Single().IdSpeciality = int.Parse(txb_IdSpeciality.Text);
                    _db.SaveChanges();
                    gridTableWorker.ItemsSource = await _db.Workers.ToListAsync();
                    break;
                case 2:
                    if (!int.TryParse(txb_CountOfWorkers.Text, out i) || !int.TryParse(txb_IdDepartment.Text, out i))
                    {
                        MessageBox.Show("you entered incorrect data");
                        return;
                    }
                    Brigade brigade = (Brigade)gridTableBrigade.SelectedItem;
                    id = brigade.IdBrigade;
                    _db.Brigades.Where(x => x.IdBrigade == id).Single().CountWorker = int.Parse(txb_CountOfWorkers.Text);
                    _db.Brigades.Where(x => x.IdBrigade == id).Single().TypeBrigade = txb_TypeBrigade.Text;
                    _db.Brigades.Where(x => x.IdBrigade == id).Single().IdDepartment = int.Parse(txb_IdDepartment.Text);

                    _db.SaveChanges();
                    gridTableBrigade.ItemsSource = await _db.Brigades.ToListAsync();
                    break;
                case 3:
                    if (!int.TryParse(txb_CountOfBrigade.Text, out i))
                    {
                        MessageBox.Show("you entered incorrect data");
                        return;
                    }
                    Department department = (Department)gridTableDepartment.SelectedItem;
                    id = department.IdDepartment;
                    _db.Departments.Where(x => x.IdDepartment == id).Single().NameDepartment = txb_NameDepartment.Text;
                    _db.Departments.Where(x => x.IdDepartment == id).Single().DescriptionDepartment = txb_DescriptionDepartment.Text;
                    _db.Departments.Where(x => x.IdDepartment == id).Single().CountBrigade = int.Parse(txb_CountOfBrigade.Text);

                    _db.SaveChanges();
                    gridTableDepartment.ItemsSource = await _db.Departments.ToListAsync();
                    break;
                default:
                    break;
            }
        }

        private void gridTableSpeciality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Speciality speciality = (Speciality)gridTableSpeciality.SelectedItem;
            if (speciality == null)
                return;
            txb_NameSpeciality.Text = speciality.NameSpeciality;
            txb_DescriptionSpeciality.Text = speciality.Description;
            txb_SalaryOneRate.Text = speciality.SalaryOneRate.ToString();
        }

        private void gridTableWorker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Worker worker = (Worker)gridTableWorker.SelectedItem;
            if (worker == null)
                return;
            txb_NameWorker.Text = worker.Name;
            txb_SurnameWorker.Text = worker?.Surname;
            txb_Email.Text = worker.Email;
            txb_Rate.Text = worker.Rate.ToString();
            txb_IdBrigade.Text = worker.IdBrigade.ToString();
            txb_IdSpeciality.Text = worker.IdSpeciality.ToString();
        }

        private void gridTableBrigade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Brigade brigade = (Brigade)gridTableBrigade.SelectedItem;
            if (brigade == null)
                return;
            txb_CountOfWorkers.Text = brigade.CountWorker.ToString();
            txb_TypeBrigade.Text = brigade.TypeBrigade;
            txb_IdDepartment.Text = brigade.IdDepartment.ToString();
        }

        private void gridTableDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department department = (Department)gridTableDepartment.SelectedItem;
            if (department == null)
                return;
            txb_NameDepartment.Text = department.NameDepartment;
            txb_DescriptionDepartment.Text = department.DescriptionDepartment;
            txb_CountOfBrigade.Text = department.CountBrigade.ToString();
        }

        private async void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            switch (TabControlTable.SelectedIndex)
            {
                case 0:
                    Speciality speciality = (Speciality)gridTableSpeciality.SelectedItem;
                    int id = speciality.IdSpeciality;
                    _db.Specialities.Remove(speciality);
                    _db.SaveChanges();
                    gridTableSpeciality.ItemsSource = await _db.Specialities.ToListAsync();
                    break;
                case 1:
                    Worker worker = (Worker)gridTableWorker.SelectedItem;
                    _db.Workers.Remove(worker);
                    _db.SaveChanges();
                    gridTableWorker.ItemsSource = await _db.Workers.ToListAsync();
                    break;
                case 2:
                    Brigade brigade = (Brigade)gridTableBrigade.SelectedItem;
                    _db.Brigades.Remove(brigade);
                    _db.SaveChanges();
                    gridTableBrigade.ItemsSource = await _db.Brigades.ToListAsync();
                    break;
                case 3:
                    Department department = (Department)gridTableDepartment.SelectedItem;
                    _db.Departments.Remove(department);
                    _db.SaveChanges();
                    gridTableDepartment.ItemsSource = await _db.Departments.ToListAsync();
                    break;
                default:
                    break;
            }
        }
    }
}