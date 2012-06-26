using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Media.Animation;
using WpfAnimation.Page;
namespace WpfAnimation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///     
    public partial class MainWindow : Window
    {

        Dictionary<int, IPage> _pages = new Dictionary<int, IPage>();
        Storyboard _story = new Storyboard();

        IPage _currentPage = null;

        bool swapingPage = false;
        public MainWindow()
        {

            InitializeComponent();
            //this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
            _pageContainer.TransitionCompleted += new EventHandler(_pageContainer_TransitionCompleted);
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            this.Closed += new EventHandler(MainWindow_Closed);

            this.MouseDown += new MouseButtonEventHandler(MainWindow_MouseDown);

        }

        void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseButton nmb = new MouseButton();
            nmb = e.ChangedButton;
            switch (nmb)
            {
                case MouseButton.Middle:
                    break;
                case MouseButton.Right:
                    break;
                case MouseButton.XButton1:
                    break;
                case MouseButton.XButton2:
                    break;

            }

        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = (int)DefinePageIndex.HomePageIndex; i < (int)DefinePageIndex.EndPageIndex + 1; i++)
            {
                IPage page = (IPage)Activator.CreateInstance(DefinePageIndex.TypeFromIndex(i));
                if (page != null)
                {
                    page.GoToPreviousPage += new EventHandler(page_GoToPreviousPage);
                    page.GoToNextPage += new EventHandler(page_GoToNextPage);
                    _pages.Add(page.PageIndex, page);
                    _pageContainer.Items.Add(page);
                }
            }

            _currentPage = _pages[(int)DefinePageIndex.HomePageIndex];
            GoToPage((int)DefinePageIndex.HomePageIndex, false);
        }

        void page_GoToNextPage(object sender, EventArgs e)
        {
            IPage page = sender as IPage;
            if (page != null)
            {
                if (_pages.ContainsKey(page.NextPageIndex))
                {
                    IPage nextP = _pages[page.NextPageIndex];

                    nextP.PrevLoad();

                    GoToPage(nextP, false);
                }
            }
        }

        void page_GoToPreviousPage(object sender, EventArgs e)
        {
            IPage page = sender as IPage;
            if (page != null)
            {
                if (_pages.ContainsKey(page.PrevPageIndex))
                {
                    IPage prev = _pages[page.NextPageIndex];

                    prev.PrevLoad();

                    GoToPage(prev, false);
                }
            }
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
           // System.Diagnostics.Process.GetCurrentProcess().Kill();

            DoubleAnimation rorates = new DoubleAnimation(-360, TimeSpan.FromSeconds(0.2));
            rorates.Completed+=new EventHandler(rorate_Completed);
            rorates.AutoReverse=false;
            rorates.FillBehavior=FillBehavior.HoldEnd;
            this.rotate.BeginAnimation(RotateTransform.AngleProperty, rorates);

        }

        void rorate_Completed(object sender, EventArgs e)
        {
            this.Close();
        }

        void _pageContainer_TransitionCompleted(object sender, EventArgs e)
        {

            if (_currentPage != null)
            {
                _currentPage.Load();
            }
            //if (_currentPage is HomePage || _currentPage is EndPage)
            //{
            //    button1.Visibility = Visibility.Hidden;
            //}
            //else
            //{
            //    button1.Visibility = Visibility.Visible;
            //}
            swapingPage = false;
        }

        void _story_Completed(object sender, EventArgs e)
        {
            this.Close();
        }


        void GoToPage(int index, bool back)
        {
            IPage page = _pages[index];
            if (page != null)
            {
                GoToPage(page, false);
            }
        }

        void GoToPage(IPage toPage, bool back)
        {
            if (toPage != null)
            {
                if (back)
                    (_pageContainer.Transition as FluidKit.Controls.SlideTransition).Direction = FluidKit.Controls.Direction.LeftToRight;
                else
                    (_pageContainer.Transition as FluidKit.Controls.SlideTransition).Direction = FluidKit.Controls.Direction.RightToLeft;
                //if (back)
                //    (_pageContainer.Transition as FluidKit.Controls.CubeTransition).Rotation = FluidKit.Controls.Direction.TopToBottom;
                //else (_pageContainer.Transition as FluidKit.Controls.CubeTransition).Rotation = FluidKit.Controls.Direction.TopToBottom;
                _pageContainer.ApplyTransition(_currentPage as FrameworkElement, toPage as FrameworkElement);
                swapingPage = true;
                _currentPage = toPage;
            }
        }


        void AnimountionToWindow()
        {
            DoubleAnimation dou = new DoubleAnimation();
            dou.From = Canvas.GetTop(thissss);
            dou.To = 0;
            dou.Duration = TimeSpan.FromMilliseconds(300);
            thissss.BeginAnimation(Canvas.TopProperty, dou);
        }
    }


}
