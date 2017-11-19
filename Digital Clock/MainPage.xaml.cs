using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Digital_Clock
{
    

    public sealed partial class MainPage : Page
    {
        ApplicationDataContainer set;
        DispatcherTimer timer = new DispatcherTimer();
        public MainPage()
        {
            set = ApplicationData.Current.RoamingSettings;
            this.InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
         
        }

        private void Timer_Tick(object sender, object e)
        {
            String month;
            String realMonth;
            seconds.Text = (DateTime.Now.Second).ToString();
            minutes.Text = (DateTime.Now.Minute).ToString();
            hours.Text = (DateTime.Now.Hour).ToString();
            txtDay.Text = (DateTime.Now.DayOfWeek).ToString();
            month = (DateTime.Now.Month).ToString();
            if (month == "1")
            {
                realMonth = "JAN";
            }
            if (month == "2")
            {
                realMonth = "FEB";
            }
            if (month == "3")
            {
                realMonth = "MAR";

            }
            if (month == "4")
            {
                realMonth = "APR";
            }
            if (month == "5")
            {
                realMonth = "MAY";
            }
            if (month == "6")
            {
                realMonth = "JUN";
            }
            if (month == "7")
            {
                realMonth = "JUL";
            }
            if (month == "8")
            {
                realMonth = "AUG";
            }
            if (month == "9")
            {
                realMonth = "SEP";
            }
            if (month == "10")
            {
                realMonth = "OCT";
            }
            if (month == "11")
            {
                realMonth = "NOV";
                Month.Text = realMonth.ToString();
            }
            if (month == "12")
            {
                realMonth = "DEC";
                Month.Text = realMonth.ToString();
            }

            Day.Text = (DateTime.Now.Day).ToString();
            Year.Text = (DateTime.Now.Year).ToString();
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(sender == radioButtonBlack)
            {
                backGrid.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            }
            else if (sender == radioButtonRed){
                backGrid.Background = new SolidColorBrush(Windows.UI.Colors.Red);

            }
            else if (sender == radioButtonWhite)
            {
                backGrid.Background = new SolidColorBrush(Windows.UI.Colors.White);

            }
        }
    }
}
