using Kino.UI.ViewModel.Interfaces;
using System.Windows.Controls;

namespace Kino.UI.Views
{
    /// <summary>
    /// Interaction logic for SlotsView.xaml
    /// </summary>
    public partial class SlotsView : UserControl
    {
        public SlotsView(ISlotsViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
