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

namespace WpfAnimation.Page
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl,IPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public int PageIndex
        {
            get { return DefinePageIndex.HomePageIndex; }
        }

        public int PrevPageIndex
        {
            get { return DefinePageIndex.UnkonwPageIndex; }
        }

        public int NextPageIndex
        {
            get { return DefinePageIndex.AnimationDemoIndex; }
        }

        public void PrevLoad()
        {
           
        }

        public void Load()
        {
           
        }

        public event EventHandler GoToPreviousPage;

        public event EventHandler GoToNextPage;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (GoToNextPage != null)
                GoToNextPage(this, null);
        }
    }
}
