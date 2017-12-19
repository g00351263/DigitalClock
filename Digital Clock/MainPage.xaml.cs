using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.Storage;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
//Authour : Raja Naseer Ahmed Khan//
//GMIT Software Development//
namespace Digital_Clock
{
    public sealed partial class MainPage : Page
    {
        //Global Variable for Colour returns true if clicked//
        bool black,white,red = false;
        
        //Timer Built in functions and object Creation//
        DispatcherTimer timer = new DispatcherTimer(); //library pre-made functions for time and date
        
        // main method which is running at start//
        public MainPage()
        {      
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);// set time to seconds
            timer.Tick += Timer_Tick; // call timer tick method for other detaisl
            timer.Start(); // timer start at app start  
        }

        private void Timer_Tick(object sender, object e)
        {
            String month;
            String realMonth;
            
            //current seconds//
            seconds.Text = (DateTime.Now.Second).ToString();
            
            //current minutes//
            minutes.Text = (DateTime.Now.Minute).ToString();
            
            //current hours//
            hours.Text = (DateTime.Now.Hour).ToString();
            
            //current day//
            txtDay.Text = (DateTime.Now.DayOfWeek).ToString();
            
            //current month//
            month = (DateTime.Now.Month).ToString();
            
            //Number to Month Mapping//
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

            //getting day and year current//
            Day.Text = (DateTime.Now.Day).ToString();
            Year.Text = (DateTime.Now.Year).ToString();
        }

        private void stopWatchNavigation_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(StopWatch));  
        }

        //BackGround Colour Chooser Event
        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton current = (RadioButton)sender;
            
            if (sender == radioButtonBlack)
            {
                white = false;
                red = false;
                black = radioButtonBlack.IsEnabled = true;
                radioBackground();
                radioButtonBlack.Background = new SolidColorBrush(Windows.UI.Colors.Black);

                backGrid.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            }
            else if (sender == radioButtonRed)
            {
                black = false;
                white = false;
                red = radioButtonRed.IsEnabled = true;
                radioBackground();
                radioButtonRed.Background = new SolidColorBrush(Windows.UI.Colors.Red);

                backGrid.Background = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else if (sender == radioButtonWhite)
            {
                black = false;
                red = false;
                white = radioButtonWhite.IsEnabled = true;
                radioBackground();
                radioButtonWhite.Background = new SolidColorBrush(Windows.UI.Colors.White);

                backGrid.Background = new SolidColorBrush(Windows.UI.Colors.White);
            }
        }
//Radiobuttons background colours true if clicked//
        private void radioBackground()
        {
            if(black == true)
            {
                radioButtonRed.Background = new SolidColorBrush(Windows.UI.Colors.Black);
                radioButtonWhite.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            }
            else if (white == true)
            {
                radioButtonRed.Background = new SolidColorBrush(Windows.UI.Colors.White);
                radioButtonBlack.Background = new SolidColorBrush(Windows.UI.Colors.White);
            }
            else if (red == true)
            {
                radioButtonWhite.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                radioButtonBlack.Background = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }
    }
}
