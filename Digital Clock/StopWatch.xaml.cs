using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using System.Threading;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Digital_Clock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StopWatch : Page
    {
        //Buitl in Timer methods/funtions object creation//
        DispatcherTimer timer = new DispatcherTimer();
        
        //assigning time to variables//
        int seconds = 0;
        int minutes = 0;
        int hours = 0;
   
        //background color in case choosen will be returning true//
        bool black, white, red = false;
       
       //intializing the stop watch on start of programm//
        public StopWatch() { 
            this.InitializeComponent();
        }

        #region Timer Methods

        // getting the methods form timer class and assigning them to time//
        private void StartTimer()
        {
            this.timer.Interval = new TimeSpan(0, 0, 1);
            this.timer.Tick += timer_Tick;
            this.timer.Start();
        }

        // stop the timer method//
        private void StopTimer()
        {
            this.timer.Tick -= timer_Tick;
            this.timer.Stop();
        }
    //reseting the timer//
        private void ResetTimer()
        {
            this.minutes = this.seconds = this.hours = 0;
            this.txtBox.Text = "0 : 0 : 0";
        }

        #endregion
        private void timer_Tick(object sender, object e)
        {
            //assigning current time to variables//
            ++this.seconds;
            if (this.seconds == 60)
            {
                this.minutes++;
                this.seconds = 0;
            }
            if (this.minutes == 60)
            {
                this.hours++;
                this.minutes = 0;
            }
            // output standard from timer class//
            this.txtBox.Text = string.Format("{0} : {1} : {2}", hours, minutes, seconds);
        }
        
        // if timer not start start it, if started stop, and reseting//
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (!this.timer.IsEnabled)
            {
                this.StartTimer();
            }
        }
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            this.StopTimer();
            this.ResetTimer();
        }
        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.timer.IsEnabled)
            {
                this.StopTimer();
            }
        }
        
        //to the mainPage of Digital clock//
        private void stopWatchNavigation_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        //background selector with radio event sender//
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

        private void radioBackground()
        {
            if (black == true)
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
