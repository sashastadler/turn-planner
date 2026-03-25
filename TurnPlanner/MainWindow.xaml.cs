using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace TurnPlanner
{
    public partial class MainWindow : Window
    {
        private List<string> characterFiles = [];
        private const string CharacterDirectory = "characters";
        public MainWindow()
        {
            LoadCharacterFiles();
            InitializeComponent();
            PopulateCharacterButtons();
        }


        // Load character file names at startup
        private void LoadCharacterFiles()
        {
            if (!Directory.Exists(CharacterDirectory))
            {
                Directory.CreateDirectory(CharacterDirectory);
                return;
            }

            characterFiles = [.. Directory.GetFiles(CharacterDirectory, "*.json")];
        }

        // Set character buttons
        private void PopulateCharacterButtons()
        {
            CharacterButtonsPanel.Children.Clear();

            foreach (string characterFile in characterFiles)
            {
                StackPanel stackPanel = new();
                Button characterButton = new()
                {
                    Height = 100,
                    Width = 100,
                    Margin = new Thickness(10),
                    Tag = characterFile // Store file path for json parsing step
                };

                //TODO: Add image
                //Image characterImage = new Image { Source = new BitmapImage(new Uri(".\assets\cusdakesh.jpg")), Height = 60, Width = 60 };
                //stackPanel.Children.Add(characterImage);

                string characterName = Path.GetFileNameWithoutExtension(characterFile);
                stackPanel.Children.Add(
                    new TextBlock
                    {
                        Text = characterName,
                        HorizontalAlignment = HorizontalAlignment.Center
                    });
                characterButton.Content = stackPanel;
                characterButton.Click += CharacterButton_Click;

                CharacterButtonsPanel.Children.Add(characterButton);
            }
        }
        
        #region button handlers
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

            //TODO: navigate to turn planning interface
            // Open json from button.Tag
            // NavigateToTurnPlanning(characterName);
        }

        // Handle add character button
        private void AddCharacterButton_Click(object sender, RoutedEventArgs e)
        {
            // This is a dummy button for now
            // TODO: Add character creation? much later maybe
            MessageBox.Show("This does nothing (yet)");
        }

        // Handle exit button
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion
    }
}