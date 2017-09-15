using EmptyMVXProjCore.ViewModels;
using MvvmCross.Wpf.Views;

namespace EmptyMVXProj.Views
{
    public partial class FirstView : MvxWpfView
    {
        public FirstView()
        {
            this.InitializeComponent();
        }

        private void RegionSelectComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ((FirstViewModel)this.DataContext).RegionSelected();
        }

        private void HBSelectComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ((FirstViewModel)this.DataContext).HealthBoardSelected(); 
        }
    }
}
