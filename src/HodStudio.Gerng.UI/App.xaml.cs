using System.Windows;

namespace HodStudio.Gerng.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string WorkingDir { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            WorkingDir = e.Args.Length == 0 ? string.Empty : e.Args[0];
        }
    }
}
