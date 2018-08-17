using Kino.Model;
using Kino.Repository;
using Kino.Services;
using Kino.Services.Interfaces;
using Kino.UI.ViewModel;
using Kino.UI.ViewModel.Interfaces;
using Kino.UI.Views;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Unity;
using System;
using System.Windows;
using Unity;

namespace Kino.UI.Bootstrapper
{
    public class Bootstrapperek : UnityBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            //tworzenie powloczki
            return Container.Resolve<MainWindow>();
        }
        //  IUnityContainer ioc;
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IMainWindowViewModel, MainWindowViewModel>(new ContainerControlledLifetimeManager());

            Container.RegisterType<IAdminViewModel, AdminViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IFilmsViewModel, FilmsViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ISlotsViewModel, SlotsViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<FilmsView, FilmsView>(new ContainerControlledLifetimeManager());
            Container.RegisterType<AdminView, AdminView>(new ContainerControlledLifetimeManager());
            Container.RegisterType<SlotsView, SlotsView>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IEventAggregator, EventAggregator>();
            Container.RegisterType<IRepository<Film>, Repository<Film>>();
            Container.RegisterType<IRepository<Slot>, Repository<Slot>>();

            Container.RegisterType<IFilmService, FilmService>();
            Container.RegisterType<ISlotService, SlotService>();

        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }


    }
}