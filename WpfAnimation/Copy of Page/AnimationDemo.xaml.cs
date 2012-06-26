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
    /// Interaction logic for AnimationDemo.xaml
    /// </summary>
    public partial class AnimationDemo : UserControl,IPage
    {
        public AnimationDemo()
        {
            InitializeComponent();
        }

        //void GoToPage(bool back)
        //{ 
        
            
        //}

        public int PageIndex
        {
            get { return DefinePageIndex.AnimationDemoIndex; }
        }

        public int PrevPageIndex
        {
            get { return DefinePageIndex.HomePageIndex; }
        }

        public int NextPageIndex
        {
            get { return DefinePageIndex.EndPageIndex; }
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
