using System.Windows;
using System.Windows.Controls;

namespace TurnPlanner{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Handle character selection
        private void CharacterButton_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            string characterName = "";
            
            // Get character name from button content
            if (button?.Content is StackPanel stackPanel)
            {
                foreach (var child in stackPanel.Children)
                {
                    if (child is TextBlock textBlock)
                    {
                        characterName = textBlock.Text;
                        break;
                    }
                }
            }
            
            // For now, just show a message
            MessageBox.Show($"Selected character: {characterName}");
            
            // In the future, you would navigate to turn planning interface
            // NavigateToTurnPlanning(characterName);
        }

        // Handle add character button
        private void AddCharacterButton_Click(object sender, RoutedEventArgs e)
        {
            // This is a dummy button for now
            MessageBox.Show("Add character functionality not implemented yet");
        }

        // Handle exit button
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}