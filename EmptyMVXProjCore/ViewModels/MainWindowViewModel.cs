namespace EmptyMVXProjCore.ViewModels
{
    using MvvmCross.Core.ViewModels;

    public class MainWindowViewModel : MvxViewModel
    {
        private bool hideTaskBar;

        private bool isDraggable;

        private string isMaximized;

        private MvxCommand hideButtonCommand;

        public MainWindowViewModel()
        { 
            this.HideTaskBar = true;
            this.IsDraggable = false;
            this.IsMaximized = "Maximized";
        }

        public bool HideTaskBar 
        {
            get { return this.hideTaskBar; }
            set { this.SetProperty(ref this.hideTaskBar, value); }
        }
        public bool IsDraggable
        {
            get { return this.isDraggable; }
            set { this.SetProperty(ref this.isDraggable, value); }
        }

        public string IsMaximized
        {
            get { return this.isMaximized; }
            set { this.SetProperty(ref this.isMaximized, value); }
        }

        public MvxCommand HideButtonCommand
        {
            get
            {
                return this.hideButtonCommand ?? (this.hideButtonCommand = new MvxCommand(HideButtonAction));
            }
        }

        private void HideButtonAction()
        {
            HideTaskBar = !HideTaskBar;
            IsDraggable = !IsDraggable;

            if (HideTaskBar)
            {
                IsMaximized = "Maximized";
            }
            else
            {
                IsMaximized = "Normal";
            }
        }
    }
}
