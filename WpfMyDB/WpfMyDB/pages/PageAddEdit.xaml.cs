using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMyDB.classes;

namespace WpfMyDB.pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddEdit.xaml
    /// </summary>
    public partial class PageAddEdit : Page
    {
        private Iskop Isk = new Iskop();
        private Iskop dishes;

        public PageAddEdit(Iskop dishlocal)
        {
            InitializeComponent();

            CmbUnit.ItemsSource =
                lesuserEntities.GetContext().Sale.ToList();
            CmbUnit.SelectedValuePath = "ID_Sale";
            CmbUnit.DisplayMemberPath = "Unit";

            CmbMine.ItemsSource =
                lesuserEntities.GetContext().Mine.ToList();
            CmbMine.SelectedValuePath = "ID_Mine";
            CmbMine.DisplayMemberPath = "Mine_Name";

            if (dishlocal != null)
                dishes = dishlocal;

            //создаем контекст

            DataContext = Isk;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Isk.ID == 0)
                lesuserEntities.GetContext().
                    Iskop.Add(Isk); //добавить в контекст

            try
            {
                lesuserEntities.GetContext().SaveChanges();
                MessageBox.Show("Изменения успешно сохранены");
                ClassFrame.frmObj.Navigate(new PageIskop());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
