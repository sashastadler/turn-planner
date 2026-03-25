using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace TurnPlanner{
    public partial class MainWindow : Window
    {
        private List<string> characterFiles = new();
        private const string CharacterDirectory = "characters";
        public MainWindow()
        {
            LoadCharacterFiles();
            InitializeComponent();
        }

        // Load character file names at startup
        private void LoadCharacterFiles()
        {
            if (!Directory.Exists(CharacterDirectory))
            {
                Directory.CreateDirectory(CharacterDirectory);
                return;
            }

            characterFiles = Directory.GetFiles(CharacterDirectory, "*.json").ToList();
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
            MessageBox.Show("This does nothing (yet)");
        }

        // Handle exit button
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}