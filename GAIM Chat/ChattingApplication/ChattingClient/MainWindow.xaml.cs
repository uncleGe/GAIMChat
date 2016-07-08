using ChattingInterface;
using System.ServiceModel;
using System.Windows;

namespace ChattingClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IChattingService Server;
        private static DuplexChannelFactory<IChattingService> _channelFactory;

        public MainWindow()
        {
            InitializeComponent();
            _channelFactory = new DuplexChannelFactory<IChattingService>(new ClientCallback(), "ChattingServiceEndPoint");
            Server = _channelFactory.CreateChannel();

            TextDisplayTextBox.IsReadOnly = true;
        }

        // Takes message text from GetMessage() and displays in main text box
        public void TakeMessage(string message, string userName)
        {
            TextDisplayTextBox.Text += userName + ": " + message + "\n";
            TextDisplayTextBox.ScrollToEnd();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageTextBox.Text.Length == 0)
            {
                return;
            }
            Server.SendMessageToAll(MessageTextBox.Text, UserNameTextBox.Text);
            TakeMessage(MessageTextBox.Text, "Me");
            MessageTextBox.Text = "";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int returnValue = Server.Login(UserNameTextBox.Text);
            if (returnValue == 1)
            {
                MessageBox.Show("Name is already in use!");
            }
            else if (returnValue == 2)
            {
                MessageBox.Show("You didn't enter your name!");
            }
            else if (returnValue == 0)
            {
                MessageBox.Show("You're logged in!");
                UserNameTextBox.IsEnabled = false;
                LoginButton.IsEnabled = false;
            }
        }
    }
}
