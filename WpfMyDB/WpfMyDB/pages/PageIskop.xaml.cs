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
    /// Логика взаимодействия для PageIskop.xaml
    /// </summary>
    public partial class PageIskop : Page
    {
        public PageIskop()
        {
            InitializeComponent();

            DtgListIskop.ItemsSource =
                lesuserEntities.GetContext().Iskop.ToList();

            CmbUnit.ItemsSource = lesuserEntities.GetContext().
                 Sale.ToList();
            CmbUnit.SelectedValuePath = "ID_Sale";
            CmbUnit.DisplayMemberPath = "Unit";
        }

        private void CmbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idDisc = int.Parse(CmbUnit.SelectedValue.ToString());
            DtgListIskop.ItemsSource =
                lesuserEntities.GetContext().Iskop.
                Where(x => x.ID_Sale == idDisc).ToList();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TxtSearch.Text;
            DtgListIskop.ItemsSource =
                lesuserEntities.GetContext().Iskop.
                Where(x => x.Name.Contains(search)).ToList();
        }

        private void RbtnAsc_Click(object sender, RoutedEventArgs e)
        {
            //сортировка по возрастанию
            DtgListIskop.ItemsSource =
                lesuserEntities.GetContext().Iskop.
                OrderBy(x => x.Sale).ToList();
        }

        private void RbtnDesc_Click(object sender, RoutedEventArgs e)
        {
            //сортировка по убыванию
            DtgListIskop.ItemsSource =
                lesuserEntities.GetContext().Iskop.
                OrderByDescending(x => x.Sale).ToList();
        }

        private void BtnResults_Click(object sender, RoutedEventArgs e)
        {
            LstResults.Items.Clear();
            //подсчет агрегатных функций

            int count = lesuserEntities.GetContext().
                Iskop.Count();

            double averageMark = (double)lesuserEntities.GetContext().
                Iskop.Select(x => x.Sale).Average();

            double minMark = (double)lesuserEntities.GetContext().
                Iskop.Select(x => x.Sale).Min();

            double maxMark = (double)lesuserEntities.GetContext().
                Iskop.Select(x => x.Sale).Max();

            double sumMark = (double)lesuserEntities.GetContext().
                Iskop.Select(x => x.Sale).Sum();

            LstResults.Items.Add($"количество записей - {count}");
            LstResults.Items.Add($"Средняя цена - {averageMark}");
            LstResults.Items.Add($"Минимальная цена - {minMark}");
            LstResults.Items.Add($"Максимальная цена - {maxMark}");
            LstResults.Items.Add($"Общая сумма цен - {sumMark}");
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.
                Navigate(new PageAddEdit());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление нескольких строк
            var studentsForRemoving =
                DtgListIskop.SelectedItems.
                Cast<Iskop>().ToList();

            if (MessageBox.Show
                ($"Удалить {studentsForRemoving.Count()} " +
                $"записей?",
                "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    lesuserEntities.GetContext().
                        Iskop.RemoveRange(studentsForRemoving);

                    lesuserEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены");
                    DtgListIskop.ItemsSource =
                        lesuserEntities.GetContext().
                        Iskop.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }
    }
}
