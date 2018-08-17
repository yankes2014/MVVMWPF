using Kino.UI.ViewModel.Interfaces;
using System.Windows.Controls;

namespace Kino.UI.Views
{
    /// <summary>
    /// Interaction logic for FilmsView.xaml
    /// </summary>
    public partial class FilmsView : UserControl
    {
        public FilmsView(IFilmsViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
