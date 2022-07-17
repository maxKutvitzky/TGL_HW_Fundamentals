using System;
using System.Collections.Generic;
using System.IO;
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
using CharacterModel;
using CharacterModel.Battle;
using CharacterModel.Collection;
using CharacterModel.Util;

namespace CharacterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BattleManager _battleManager = new BattleManager();
        private event Action showBattleAction;
        public MainWindow()
        {
            InitializeComponent();
            showBattleAction = ShowCharacters;
            FileLogger.NewLog();
        }
        private void buttonWarrior_Click(object sender, RoutedEventArgs e)
        {
            _battleManager.AddWarrior(InputCharacterName());
            showBattleAction.Invoke();
        }

        private void buttonArcher_Click(object sender, RoutedEventArgs e)
        {
            _battleManager.AddArcher(InputCharacterName());
            showBattleAction.Invoke();
        }

        private void buttonMage_Click(object sender, RoutedEventArgs e)
        {
            _battleManager.AddMage(InputCharacterName());
            showBattleAction.Invoke();
        }

        private void buttonRandomFill_Click(object sender, RoutedEventArgs e)
        {
            _battleManager.ClearBattle();
            _battleManager.RandomFillBattle(4);
            showBattleAction.Invoke();
        }
        private void buttonFight_Click(object sender, RoutedEventArgs e)
        {
            ClearWinnerPanel();
            if (_battleManager.GetCharacters().Count <= 1)
            {
                MessageBox.Show("Not enough characters to fight!");
                return;
            }
            Character character = _battleManager.Fight();
            AddLabelToWinnerPanel(NewLabel($"{character.Name}: class {character.ClassName}, remaining health {character.Health}"));
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            _battleManager.ClearBattle();
            ClearBattlePanel();
            ClearWinnerPanel();
            showBattleAction.Invoke();
        }
        private void ShowCharacters()
        {
            ClearBattlePanel();
            CharacterCollection characterCollection = _battleManager.GetCharacters();
            if (characterCollection.Count == 0)
            {
                AddLabelToBattlePanel(NewLabel("None"));
            }
            else
            {
                foreach (Character character in characterCollection)
                {
                    AddLabelToBattlePanel(NewLabel($"{character.Name}: class {character.ClassName}, health {character.Health}"));
                }
            }
        }
        private string InputCharacterName()
        {
            NameInputWindow inputWindow = new NameInputWindow();
            if (inputWindow.ShowDialog() == true)
            {
                return inputWindow.ResponseText;
            }
            return "NoName";
        }
        private Label NewLabel(string content)
        {
            Label label = new Label
            {
                Content = content,
                Style = Application.Current.FindResource("CharacterLabel") as Style
            };
            return label;
        }
        private void AddLabelToWinnerPanel(Label label)
        {
            WinnerPanel.Children.Add(label);
        }
        private void AddLabelToBattlePanel(Label label)
        {
            BattlePanel.Children.Add(label);
        }

        private void ClearBattlePanel()
        {
            BattlePanel.Children.Clear();
        }

        private void ClearWinnerPanel()
        {
            WinnerPanel.Children.Clear();
        }

        private void BattleLogMenu_Click(object sender, RoutedEventArgs e)
        {
            FileLogger.OpenLog();
        }

        private void HelpMenu_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.Show();
        }
    }
}
