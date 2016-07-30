using ChattingInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChattingClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    class ClientCallback : IClient
    {
        // Server calls GetMessage()
        public void GetMessage(string message, string userName)
        {
            // MainWindow is of type Window, from System.Windows
            // Below casts it to type MainWindow to access MainWindow's methods
            ((MainWindow)Application.Current.MainWindow).TakeMessage(message, userName);

        }

        public void GetUpdate(int value, string userName)
        {
            switch (value)
            {
                case 0:
                    {
                        ((MainWindow)Application.Current.MainWindow).AddUserToList(userName);
                        break;
                    }
                case 1:
                    {
                        ((MainWindow)Application.Current.MainWindow).RemoveUserFromList(userName);
                        break;
                    }
            }
        }
    }
}
