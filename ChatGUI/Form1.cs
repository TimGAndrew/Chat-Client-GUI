using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatLib;
using System.Threading;


namespace ChatGUI
{
    public partial class MainForm : Form
    {
            //Some strings for the app:
        private string ProgramName = "Network Chat";
        private string ContactInfo = "\n\nBy Tim Andrew"+
                                     "\n\nW0212032@NSCC.CA" +
                                     "\n\n5685 Leeds St," + 
                                     "\nHalifax, NS" +
                                     "\nB3K 2T3";
        private string SendConnected = "Type Your Message Here:";
        private string SendNotConnected = "Connect Using Network/Connect";
        private string ConversationConnected = "Conversation:";
        private string ConversationNotConnected = "Not Connected!";

            //Network Information:
        private static String InternetAddress = "127.0.0.1";
        private static Int32 NetworkPort = 12345;

            //Set up an uninitailzed connection:
        Connection connection = new Connection(InternetAddress, NetworkPort);

            //Global Recieve message thread:
        Thread recieveMessageThread;



        /// <summary>
        /// Initilizes the MainForm:
        /// </summary>
        public MainForm()
        {
                //Event Handlers:
            connection.ConnectionMessage += new ChatLib.ConnectionMessageEventHandler(Connection_Message);
            connection.ConnectionSuccessful += new ChatLib.ConnectionSuccessfulEventHandler(Connection_Successful);
            connection.ConnectionFailed += new ChatLib.ConnectionFailedEventHandler(Connection_Failed);
            connection.ConnectionTermination += new ChatLib.ConnectionTerminationEventHandler(Connection_Termination);

            InitializeComponent();

                //Set up the name of the program:
            this.Text = ProgramName;
                //Set the active box:
            this.ActiveControl = SendMessageBox;

                //Set form elements depending on the connection status::
                    //Menu:
            MenuNetworkDisconnect.Enabled = false;
            MenuNetworkConnect.Enabled = true;
                    //SendMessageBoxGroup:
            SendMessageBoxGroup.Text = SendNotConnected;
            SendMessageBox.Enabled = false;
            SendMessageBoxButton.Enabled = false;
            SendMessageBoxClear.Enabled = false;
                    //ConversationBoxGroup:
            ConversationBoxGroup.Text = ConversationNotConnected;
            ConversationBox.BackColor = System.Drawing.Color.LightGray;

        } //end MainForm()

        /*--------------BEGIN EVENT FUNCTIONS--------------*/

        /// <summary>
        /// Event Handler for when the connection is terminated:
        /// </summary>
        /// <param name="terminationMessage">The Message to display upon termination</param>
        private void Connection_Termination(string terminationMessage)
        {
            //Check if the ConversationBox is on a seperate thread:
            if (ConversationBox.InvokeRequired)
            {
                //If it is, create an invoker..
                MethodInvoker invoker = new MethodInvoker(
                    //with an anonymous function,
                    delegate () {
                        //that will run:
                        ConversationBox.AppendText(terminationMessage);

                        //Set some form elements for..
                        //Send:
                        SendMessageBoxGroup.Text = SendNotConnected;
                        SendMessageBox.Enabled = false;
                        SendMessageBoxButton.Enabled = false;
                        SendMessageBoxClear.Enabled = false;
                        //Menu:
                        MenuNetworkDisconnect.Enabled = false;
                        MenuNetworkConnect.Enabled = true;
                        //Conversation:
                        ConversationBoxGroup.Text = ConversationNotConnected;
                        ConversationBox.BackColor = System.Drawing.Color.LightGray;
                    });

                //Then invoke it:
                ConversationBox.Invoke(invoker);
            }
            else
            {
                ConversationBox.AppendText(terminationMessage);

                //Set some form elements for..
                //Send:
                SendMessageBoxGroup.Text = SendNotConnected;
                SendMessageBox.Enabled = false;
                SendMessageBoxButton.Enabled = false;
                SendMessageBoxClear.Enabled = false;
                //Menu:
                MenuNetworkDisconnect.Enabled = false;
                MenuNetworkConnect.Enabled = true;
                //Conversation:
                ConversationBoxGroup.Text = ConversationNotConnected;
                ConversationBox.BackColor = System.Drawing.Color.LightGray;
            }

        }//END Connection_Termination()

        /// <summary>
        /// Handles event when a ConnectionMaxTries are met
        /// </summary>
        private void Connection_Failed()
        {
                //Check if the MenuNetworkConnect is on a seperate thread:
            if (Menu.InvokeRequired)
            {
                    //If it is, create an invoker..
                MethodInvoker invoker = new MethodInvoker(
                        //with an anonymous function,
                    delegate () {
                            //that will run:
                        MenuNetworkConnect.Enabled = true;
                    });

                //Then invoke it:
                Menu.Invoke(invoker);
            }
            else
                    //renable the Network/Connect:
                MenuNetworkConnect.Enabled = true;

        }//End Connection_Failed()

        /// <summary>
        /// Handles event when a connection is successful:
        /// </summary>
        /// <param name="successfulConnectionAttempt"></param>
        private void Connection_Successful(string successfulConnectionAttempt)
        {

            if (connection.ProgramTerminating)
            {
                return;
            }

                //Check if the ConversationBox is on a seperate thread:
            if (ConversationBox.InvokeRequired)
            {
                    //If it is, create an invoker..
                MethodInvoker invoker = new MethodInvoker(
                        //with an anonymous function,
                    delegate () {
                            //that will run:
                        ConversationBox.AppendText(successfulConnectionAttempt);

                            //It will also set up some other GUI elements:
                                //Conversation:
                        ConversationBox.BackColor = System.Drawing.Color.White;
                        ConversationBoxGroup.Text = ConversationConnected;
                                //Send:
                        SendMessageBoxGroup.Text = SendConnected;
                        SendMessageBox.Enabled = true;
                        SendMessageBoxButton.Enabled = true;
                        SendMessageBoxClear.Enabled = true;
                                //Menu:
                        MenuNetworkDisconnect.Enabled = true;
                        MenuNetworkConnect.Enabled = false;
                    });

                    //Then invoke it:
                ConversationBox.Invoke(invoker);
            }
            else
            {
                    //update the conversation box:
                ConversationBox.AppendText(successfulConnectionAttempt);
                    //Also set up some other GUI elements:
                        //Conversation:
                ConversationBox.BackColor = System.Drawing.Color.White;
                ConversationBoxGroup.Text = ConversationConnected;
                        //Send:
                SendMessageBoxGroup.Text = SendConnected;
                SendMessageBox.Enabled = true;
                SendMessageBoxButton.Enabled = true;
                SendMessageBoxClear.Enabled = true;
                        //Menu:
                MenuNetworkDisconnect.Enabled = true;
                MenuNetworkConnect.Enabled = false;
            }

                //Then set up a new thread to handle listening for incoming messages:
            recieveMessageThread = new Thread(connection.RecieveMessage);
            recieveMessageThread.Name = "Recieve Message Thread";
            recieveMessageThread.Start();

        } //end Connection_Successful()

        /// <summary>
        /// Handles event when a connection message occurs:
        /// </summary>
        /// <param name="displayConnectionStatus"></param>
        private void Connection_Message(object sender, ConnectionMessageEventArgs e)
        {
            if (connection.ProgramTerminating)
            {
                return;
            }
            
            //check if the ConversationBox is on a seperate thread:
            if (ConversationBox.InvokeRequired)
            {
                //If it is, create an invoker..
                MethodInvoker invoker = new MethodInvoker(
                    //with an anonymous function,
                    delegate () {
                        //that will run:
                        ConversationBox.AppendText(e.ConnectionMessage);
                    });

                //Then invoke it:
                if (connection.ProgramTerminating)
                {
                    return;
                }
                else
                    ConversationBox.Invoke(invoker);
            }
            else
            {
                if (connection.ProgramTerminating)
                {
                    return;
                }
                else
                    //update the conversation box:
                    ConversationBox.AppendText(e.ConnectionMessage);
            }
            
        }//End Connection_Message()

        /*--------------END EVENT FUNCTIONS--------------*/

        /// <summary>
        /// Sends a message to the server
        /// </summary>
        /// <param name="sender">The Object</param>
        /// <param name="e">The EventArgs</param>
        private void SendMessageBoxButton_Click(object sender, EventArgs e)
        {
                //Get the SendMessageBox Text
            string messageToSend = SendMessageBox.Text;
                //Reset it:
            SendMessageBox.Text = "";

                //Send the message:
            connection.SendMessage(messageToSend);

        }//End SendMessageBoxButton_Click

        /// <summary>
        /// Handles when the File/Exit menu is clicked.
        /// </summary>
        /// <param name="sender">The Object</param>
        /// <param name="e">The EventArgs</param>
        private void MenuFileExit_Click(object sender, EventArgs e)
        {
                //close the form (this invokes the FormClosing_Click methnod)
            this.Close();
        }//End MenuFileExit_Click()

        /// <summary>
        /// Handles when the Network/Connect menu is clicked.
        /// </summary>
        /// <param name="sender">The Object</param>
        /// <param name="e">The EventArgs</param>
        private void MenuNetworkConnect_Click(object sender, EventArgs e)
        {
                //First disable Network/Connect so the user can't click it again:
            MenuNetworkConnect.Enabled = false;
                //Then clear the Conversation box:
            ConversationBox.Text = "";

                //Then set up a new thread:
            Thread connectionThread = new Thread(connection.Connect);
            connectionThread.Name = "Connection Thread";
                //Run the thread:
            connectionThread.Start();

        }//End MenuNetworkConnect_Click()

        /// <summary>
        /// Handles when the Network/Disconnect menu is clicked.
        /// </summary>
        /// <param name="sender">The Object</param>
        /// <param name="e">The EventArgs</param>
        private void MenuNetworkDisconnect_Click(object sender, EventArgs e)
        {
                //Disconnect the connection:
            connection.Disconnect();

        }//END MenuNetworkDisconnect_Click()

        /// <summary>
        /// Handles when the Help/About menu is clicked.
        /// </summary>
        /// <param name="sender">The Object</param>
        /// <param name="e">The EventArgs</param>
        private void MenuHelpAbout_Click(object sender, EventArgs e)
        {
                //Set up some variables for the about message box:
            string messageBoxCaption = "About";
            string messageBoxText = ProgramName + ContactInfo;
            MessageBoxButtons messageBoxButton = MessageBoxButtons.OK;
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information;

                //Display the about message box:
            MessageBox.Show(messageBoxText, messageBoxCaption, messageBoxButton, messageBoxIcon);
        }//END MenuHelpAbout_Click()

        private void FormClosing_Click(object sender, FormClosingEventArgs e)
        {
                //Set ChatLib connection to false and if it's closing:
            connection.ProgramTerminating = true;
                //Set the connection to false:
            connection.IsConnected = false;

            //Handle graceful closing here..

            // MessageBox.Show("You clicked X", "MainForm_Load");
        }// END FormClosing_Click()

        /// <summary>
        /// Clears the Send Message Box Text
        /// </summary>
        /// <param name="sender">The Object</param>
        /// <param name="e">The EventArgs</param>
        private void SendMessageBoxClear_Click(object sender, EventArgs e)
        {

                //Resets the MessageBox:
            SendMessageBox.Text = "";

        }//END SendMessageBoxClear_Click
    }
}
