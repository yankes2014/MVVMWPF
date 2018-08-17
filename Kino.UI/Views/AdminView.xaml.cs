using Kino.UI.ViewModel.Interfaces;
using System.Windows.Controls;

namespace Kino.UI.Views
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {
        public AdminView(IAdminViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
