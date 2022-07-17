using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CharacterWPF
{
    /// <summary>
    /// Interaction logic for NameInputWindow.xaml
    /// </summary>
    public partial class NameInputWindow : Window
    {
        public NameInputWindow()
        {
            InitializeComponent();
        }

        public string ResponseText
        {
            get { return inputTextBox.Text; }
            set { inputTextBox.Text = value; }
        }

        private void OKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (inputTextBox.Text == String.Empty)
            {
                DialogResult = false;
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}
