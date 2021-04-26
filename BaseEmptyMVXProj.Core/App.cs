//------------------------------------------------------------------
//
// Copyright (c) 2020 INPS Ltd.
// All rights reserved.
//
//------------------------------------------------------------------
namespace BaseEmptyMVXProj.Core
{
    using BaseEmptyMVXProj.Core.ViewModel;
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
