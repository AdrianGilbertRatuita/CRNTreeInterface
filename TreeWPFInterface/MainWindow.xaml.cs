using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

//
using Microsoft.AspNetCore.SignalR.Client;

namespace TreeWPFInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        HubConnection CRNConnection;

        public MainWindow()
        {

            InitializeComponent();

            CRNConnection = new HubConnectionBuilder().WithUrl("https://montblanccrntreeinterface.azurewebsites.net/chat").Build();

            CRNConnection.Closed += async (error) =>
            {

                MessageBox.Items.Add("CLOSED CONNECTION: " + error.Message);
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await CRNConnection.StartAsync();

            };

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {

            Connect();

        }

        private async void Connect()
        {

            try
            {
                await CRNConnection.StartAsync();
                MessageBox.Items.Add("Connection started");

            }
            catch (Exception ex)
            {

                //
                MessageBox.Items.Add(ex.Message);

                //
                Exception TX = ex;
                while (TX.InnerException != null)
                {

                    MessageBox.Items.Add(TX.InnerException.Message);
                    TX = TX.InnerException;

                }
                
            }

            CRNConnection.On<string>("AddNode", (Node) =>
            {

                TreeList.Items.Add(Node);

            });

            CRNConnection.On<string>("DeleteNode", (Node) =>
            {

                TreeList.Items.Remove(Node);

            });

            CRNConnection.On<string, string>("Echo", (user, message) =>
            {

                this.Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{user}: {message}";
                    MessageBox.Items.Add(newMessage);
                });

            });

            CRNConnection.On<string[]>("SendTree", (Tree) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    TreeList.Items.Clear();
                    for (int i = 0; i < Tree.Length; i++)
                    {

                        TreeList.Items.Add(Tree[i]);

                    }

                });

            });

            CRNConnection.On<string>("Ping", (SourceConnection) =>
            {

                try
                {

                    CRNConnection.InvokeAsync("ReturnPing", SourceConnection);

                }
                catch (Exception ex)
                {

                    MessageBox.Items.Add("RETURN PING FAILED: " + ex.Message);

                }

            });

        }

        private async void PingCMD_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                await CRNConnection.InvokeAsync("Ping");

            }
            catch (Exception ex)
            {

                MessageBox.Items.Add("PING FAILED: " + ex.Message);

            }

        }

        private async void SendCMD_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                await CRNConnection.InvokeAsync("BroadcastMessage", "TESTER", MessageTXT.Text);

            }
            catch (Exception ex)
            {

                MessageBox.Items.Add("MESSAGE SENDING FAILED: " + ex.Message);

            }

        }

        private async void EchoCMD_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                await CRNConnection.InvokeAsync("Echo", "SELF", "ECHO");

            }
            catch (Exception ex)
            {

                MessageBox.Items.Add("MESSAGE SENDING FAILED: " + ex.Message);

            }

        }

        private async void SendTreeCMD_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                List<string> TreeListFinal = new List<string>();

                for (int i = 0; i < TreeList.Items.Count; i++)
                {

                    TreeListFinal.Add(TreeList.Items[i].ToString());

                }

                
                await CRNConnection.InvokeAsync("SendTree", TreeListFinal.ToArray());

            }
            catch (Exception ex)
            {

                MessageBox.Items.Add("MESSAGE SENDING FAILED: " + ex.Message);

            }

        }

        private void LoadTreeCMD_Click(object sender, RoutedEventArgs e)
        {

            //
            Microsoft.Win32.OpenFileDialog OpenDialog = new Microsoft.Win32.OpenFileDialog();

            //
            OpenDialog.DefaultExt = ".txt";

            //
            Nullable<bool> Result = OpenDialog.ShowDialog();

            if (Result == true)
            {

                try
                {

                    string[] LoadedList = System.IO.File.ReadAllLines(OpenDialog.FileName);

                    for (int i = 0; i < LoadedList.Length; i++)
                    {

                        TreeList.Items.Add(LoadedList[i]);

                    }

                }
                catch (Exception Ex)
                {



                }

            }
  
        }

        private async void AddCMD_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                await CRNConnection.InvokeAsync("AddNode", TreeList.SelectedItem.ToString());

            }
            catch (Exception ex)
            {

                MessageBox.Items.Add("ADD FAILED: " + ex.Message);

            }

        }

        private async void DeleteCMD_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                await CRNConnection.InvokeAsync("DeleteNode", TreeList.SelectedItem.ToString());

            }
            catch (Exception ex)
            {

                MessageBox.Items.Add("DELETE FAILED: " + ex.Message);

            }

        }


    }
}
