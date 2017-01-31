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
using MahApps.Metro.Controls;

namespace EmptyMVXProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    { 
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        /// <summary>
        /// Called when [loaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="routedEventArgs">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            WindowState = WindowState.Maximized;
            ShowMinButton = true;
            Loaded -= OnLoaded;
        }
    }
}
