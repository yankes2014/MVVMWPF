using Kino.UI.Bootstrapper;
using System.Windows;

namespace Kino.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootstrapper = new Bootstrapperek();
            bootstrapper.Run();
        }

    }
}
