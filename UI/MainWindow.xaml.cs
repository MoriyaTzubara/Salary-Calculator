using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using BE;
using BL;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL BL = new BL.BL();
        Work _work;
        List<string> minutes = new List<string>();
        List<string> hours = new List<string>();

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                for (int i = 0; i < 24; i++)
                    hours.Add(String.Format("{0}", i));
                for (int i = 0; i < 60; i++)
                    minutes.Add(String.Format("{0:00}", i));
                StartHoursCBox.ItemsSource = EndHoursCBox.ItemsSource = hours;
                StartMinutesCBox.ItemsSource = EndMinutesCBox.ItemsSource = minutes;
                workHoursTable.ItemsSource = BL.getWork().WorkHours;
                salary.Text = BL.getWork().GetTotalSalary().ToString("0.00") + "₪";
                TotalHours.Text = BL.getWork().GetTotalHours().ToString("0.00");
                perHours.Text = BL.getWork().MoneyPerHour.ToString();
                moneyPerHourSlider.Value = BL.getWork().MoneyPerHour;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אופס משהו השתבש, פרטי השגיאה:\n"  + ex);

            }

        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime start = new DateTime(Date.SelectedDate.Value.Year, Date.SelectedDate.Value.Month, Date.SelectedDate.Value.Day, StartHoursCBox.SelectedIndex, StartMinutesCBox.SelectedIndex, 0);
                DateTime end = new DateTime(Date.SelectedDate.Value.Year, Date.SelectedDate.Value.Month, Date.SelectedDate.Value.Day, EndHoursCBox.SelectedIndex, EndMinutesCBox.SelectedIndex, 0);
                _work = BL.getWork();
                _work.addTime(start, end);
            }
            catch (Exception ex)
            {
                MessageBox.Show("אנא מלא את כל השדות בצורה תקינה");
            }
            BL.setWork(_work);
                salary.Text = BL.getWork().GetTotalSalary().ToString("0.00") + "₪";
                workHoursTable.DataContext = BL.getWork().WorkHours;
                TotalHours.Text = BL.GetTotalHours().ToString("0.00");
                ICollectionView view = CollectionViewSource.GetDefaultView(BL.getWork().WorkHours);
                view.Refresh();
        }
        private void Deleate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _work = BL.getWork();
                _work.deleteTime(workHoursTable.SelectedItems.Cast<WorkHours>());
            }
            catch (Exception ex)
            {
                MessageBox.Show("אין אפשרות למחוק");

            }
            BL.setWork(_work);

            workHoursTable.DataContext = BL.getWork().WorkHours;
            TotalHours.Text = BL.getWork().GetTotalHours().ToString("0.00");
            salary.Text = BL.getWork().GetTotalSalary().ToString("0.00") + "₪";
            ICollectionView view = CollectionViewSource.GetDefaultView(BL.getWork().WorkHours);
            view.Refresh();
            //workHours.Items.Add(work.WorkHours);
            //InitializeComponent();
            //workHoursTable.ItemsSource = work.WorkHours;
            //StartHoursCBox.ItemsSource = EndHoursCBox.ItemsSource = hours;
            //StartMinutesCBox.ItemsSource = EndMinutesCBox.ItemsSource = minutes;
            //salary.Text = work.GetSalary().ToString("0.00") + "₪";
        }

        private void UpdateMoneyPerHour_Click(object sender, RoutedEventArgs e)
        {
            //perHours.Text
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                _work = BL.getWork();
                _work.MoneyPerHour = moneyPerHourSlider.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אי אפשר לבצע את העדכון, בדוק שהערך שהוזן תקין.");

            }
            BL.setWork(_work);

            salary.Text = BL.GetTotalSalary().ToString("0.00") + "₪";
            perHours.Text = moneyPerHourSlider.Value.ToString("0.00");
        }
    }
}
