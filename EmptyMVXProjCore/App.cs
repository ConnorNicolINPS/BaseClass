

namespace EmptyMVXProjCore
{
    using EmptyMVXProjCore.ViewModels;
    using MvvmCross.Platform.IoC;

    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<FirstViewModel>();
        }
    }
}
