using Kino.UI.ViewModel.Interfaces;
using Kino.UI.Views;
using Microsoft.Practices.Unity;
using Prism.Regions;
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

namespace Kino.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMainWindowViewModel _viewModel;
        public MainWindow(IUnityContainer container, IRegionManager regionManager)
        {
            InitializeComponent();
            _viewModel = container.Resolve<IMainWindowViewModel>();
            RegionManager.SetRegionManager(this, regionManager);
            DataContext = _viewModel;

            regionManager.RegisterViewWithRegion("PanelRegion", typeof(FilmsView));
            regionManager.RegisterViewWithRegion("PanelRegion", typeof(AdminView));
            regionManager.RegisterViewWithRegion("PanelRegion", typeof(SlotsView));

            regionManager.Regions["PanelRegion"].Activate(container.Resolve<AdminView>());
        }
    }
}
