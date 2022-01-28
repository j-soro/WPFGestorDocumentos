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
using System.Windows.Shapes;
namespace WPFGestorDocumentos.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    break;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                Point pointToWindow = Mouse.GetPosition(this);
                Point pointToScreen = PointToScreen(pointToWindow);
                this.Top = pointToScreen.Y - this.ActualHeight;
                this.Left = pointToScreen.X - this.ActualWidth;
            }
            this.DragMove();

            //bool outOfBounds = (this.Left <= SystemParameters.VirtualScreenLeft) ||
            //                   (this.Top <= SystemParameters.VirtualScreenTop - this.ActualHeight) ||
            //                   (SystemParameters.VirtualScreenLeft +
            //                   SystemParameters.VirtualScreenWidth <= this.Left + this.ActualWidth) ||
            //                   (SystemParameters.VirtualScreenTop -
            //                    SystemParameters.VirtualScreenHeight <= this.Top - this.ActualHeight);
            //if (outOfBounds)
            //{
            //    this.Left = SystemParameters.VirtualScreenLeft;
            //    this.Top = SystemParameters.VirtualScreenTop;
            //    outOfBounds = false;
            //}
        }

        //private Point GetNearestScreenEdge()
        //{
        //    Point currentPosCenter = new Point((this.Left + this.Width) / 2, (this.Top - this.Height) / 2);

        //    Point left = new Point(SystemParameters.VirtualScreenLeft, SystemParameters.VirtualScreenHeight / 2);
        //    Point right = new Point(SystemParameters.VirtualScreenLeft + SystemParameters.VirtualScreenWidth, SystemParameters.VirtualScreenHeight / 2);
        //    Point top = new Point(SystemParameters.VirtualScreenWidth / 2, SystemParameters.VirtualScreenHeight);
        //    Point bottom = new Point(SystemParameters.VirtualScreenWidth / 2, 0);

        //    List<Point> points = new List<Point> { left, top, right, bottom };
        //    List<double> distances = new List<double>();

        //    foreach (Point p in points)
        //    {
        //        double aux = CalculateEuclideanDistanceBetweenTwoPoints(currentPosCenter, p);
        //        distances.Add(aux);
        //    }

        //    int res = 0;

        //    res = distances.FindIndex(d => d == distances.Min());

        //    switch (res)
        //    {
        //        case 0:
        //            return new Point(SystemParameters.VirtualScreenLeft, currentPosCenter.Y);
        //        case 1:
        //            return new Point(currentPosCenter.X, SystemParameters.VirtualScreenTop);
        //        case 2:
        //            return new Point(SystemParameters.VirtualScreenWidth, currentPosCenter.Y);
        //        case 3:
        //            return new Point(currentPosCenter.X, 0);
        //    }
        //    return currentPosCenter;
        //}

        //private double CalculateEuclideanDistanceBetweenTwoPoints(Point a, Point b)
        //{
        //    return Math.Sqrt((Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2)));
        //}
    }
}
