using System;
using System.Windows;
using EmptyMVXProjCore.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Wpf.Views;

namespace EmptyMVXProj
{
    public partial class App : Application
    {
        private bool _setupComplete;

        private void DoSetup()
        {
            LoadMvxAssemblyResources();
            
            var presenter = new MvxSimpleWpfViewPresenter(MainWindow);

            var setup = new Setup(Dispatcher, presenter);
            setup.Initialize();

            MainWindow.DataContext = new MainWindowViewModel();

            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();

            _setupComplete = true;
        }

        protected override void OnActivated(EventArgs e)
        {
            if (!_setupComplete)
            {
                DoSetup();
            }

            base.OnActivated(e);
        }

        private void LoadMvxAssemblyResources()
        {
            for (var i = 0;; i++)
            {
                var key = "MvxAssemblyImport" + i;
                var data = TryFindResource(key);
                if (data == null)
                {
                    return;
                }
            }
        }
    }
}