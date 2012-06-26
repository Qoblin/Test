using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfAnimation.Page
{
    public interface IPage
    {
        int PageIndex { get; }
        int PrevPageIndex { get; }
        int NextPageIndex { get; }


        void PrevLoad();
        void Load();


        event EventHandler GoToPreviousPage;
        event EventHandler GoToNextPage;
    }

    public static class DefinePageIndex
    {
        public static int HomePageIndex { get { return 0; } }
        public static int AnimationDemoIndex { get { return 1; } }
        public static int EndPageIndex { get { return 2; } }
        public static int UnkonwPageIndex { get { return -1; } }
        public static Type TypeFromIndex(int index)
        {
            Type t = typeof(object);

            switch (index)
            { 
                case 0:
                    t = typeof(HomePage);
                    break;
                case 1:
                    t = typeof(AnimationDemo);
                    break;
                case 2:
                    t = typeof(EndPage);
                    break;
                default:
                    break;
            }

            return t;
        }
    }
}
