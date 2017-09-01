namespace EmptyMVXProj.Views
{
    using EmptyMVXProjCore.ViewModels;
    using MvvmCross.Wpf.Views;

    public partial class FirstView : MvxWpfView
    {
        public FirstView()
        {
            this.InitializeComponent();
        }

        private void MessageTextBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                ((FirstViewModel)this.DataContext).SendMessage();
            }
        }
    }
}
