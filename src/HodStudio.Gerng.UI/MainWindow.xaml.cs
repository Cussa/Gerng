using System;
using System.Windows;
using HodStudio.ReleaseNotesGenerator.Library;
using HodStudio.ReleaseNotesGenerator.Library.Configs;

namespace HodStudio.Gerng.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BtnGenerate.Click += BtnGenerate_Click;
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var hasError = false;
                if (string.IsNullOrEmpty(TxtCommitFromFormat.Text))
                {
                    hasError = true;
                    MessageBox.Show("Commit from can't be null", "Gerng", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (string.IsNullOrEmpty(TxtCommitToFormat.Text))
                {
                    hasError = true;
                    MessageBox.Show("Commit to can't be null", "Gerng", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (hasError)
                    return;

                var config = new GeneratorConfig(
                    ((App)Application.Current).WorkingDir,
                    TxtCommitFromFormat.Text,
                    TxtCommitToFormat.Text,
                    TxtMessageFormat.Text,
                    TxtHeaderFormat.Text,
                    TxtBreakingChangesFormat.Text);

                var output = new ChangelogGenerator(config).GenerateOutput();

                TxtOutput.Text = output;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
