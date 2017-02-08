using System;
using System.Net.Sockets;
using ChatLogLib;

/// <summary>
/// A Library to handle Chat connections
/// </summary>
namespace ChatLib
{
    /// <summary>
    /// An Class to open a connection to a server.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Public Variable to Gauge if Connection is good
        /// </summary>
        public volatile bool IsConnected = false;
        /// <summary>
        /// Public variable to handle if the program is terminating
        /// </summary>
        public volatile bool ProgramTerminating = false;

        private string connection;
        private string InternetAddress;
        private Int32 NetworkPort;
        private int MaxAttempts = 10;   //max connection attempts

            //Set up a TCP client:
        private TcpClient client;

            //Set up a stream to send by:
        private NetworkStream stream;

            //Set up a log to store logging data
        private Log log = new Log();

        //Event handlers to interface with the GUI:
        public ConnectionMessageEventHandler ConnectionMessage;
        public ConnectionFailedEventHandler ConnectionFailed;
        public ConnectionSuccessfulEventHandler ConnectionSuccessful;
        public ConnectionTerminationEventHandler ConnectionTermination;


        /// <summary>
        /// A constructor for a connection to a server
        /// </summary>
        /// <param name="InternetAddress">The IP Address of the server (eg. "127.0.0.1")</param>
        /// <param name="NetworkPort">The port to listen for a connection on (eg. 1234)</param>
        public Connection(String InternetAddress, Int32 NetworkPort)
        {
                //Assign the incoming variables:
            this.InternetAddress = InternetAddress;
            this.NetworkPort = NetworkPort;

                //Build the connection name:
            this.connection = InternetAddress + ":" + NetworkPort;
        }//End Connection Constructor

        /// <summary>
        /// A method to connect to the server
        /// </summary>
        public void Connect()
        {
                //Counter for attempts:
            int attempt = 0;

                //reset client:
            client = null;

            while (client == null && attempt < MaxAttempts)
            {
                    //handle if program is closing:
                if (ProgramTerminating) break;

                    //Increment Attempt:
                ++attempt;

                    //Raise an event handler to broadcast that a connection attempt is being made:
                ConnectionMessage(this,
                                new ConnectionMessageEventArgs("Attempting to connect to server @ " + connection + " (Attempt #" + attempt + ")...\r\n"));

                    //Attempt the connection:
                try
                {
                        //Set up a new TCP Client
                    client = new TcpClient(InternetAddress, NetworkPort);

                        //Set up a stream to send by:
                    stream = client.GetStream();

                        //Set the connected flag:
                    IsConnected = true;

                        //Raise an event to broadcast the connection has been made:
                    ConnectionSuccessful("Connection made to " + connection + "!\r\n");

                        //Write the successful connection to the log:
                    log.Writer("Connection made to " + connection + "!");

                }
                catch (ArgumentNullException e)
                {
                        //Raise an event to broadcast that this failed:
                    ConnectionMessage(this,
                                new ConnectionMessageEventArgs("\tFailed...\r\n"));
                }
                catch (SocketException e)
                {
                        //Raise an event to broadcast that this failed:
                    ConnectionMessage(this,
                                new ConnectionMessageEventArgs("\tFailed...\r\n"));
                }
                
            }//end while

            if (attempt == MaxAttempts)
            {
                   //Raise an even to broadcast that the attempt failed:
                ConnectionFailed();

                    //Write the failed connection to the log:
                log.Writer("Connection to " + connection + " could not be made, and was aborted after " + 
                            MaxAttempts + " attempts.");
            }

        }//end Connect()


        /// <summary>
        /// A method to recieve a message from the network stream
        /// </summary>
        public void RecieveMessage()
        {
            while (IsConnected) //TODO: figure out polling here client.poll()? tcpclient.poll()?
            {
                    //Set up the Receive Message strings:
                string LogStartMsg = "[SERVER] : ";
                string ScreenStartMsg = ">> ";
                string RecieveMessage = "";
                string EndMsg = "\r\n";

                    //Try to get data:
                try
                {
                        // Buffer to store the response bytes.
                    Byte[] data = new Byte[2048];

                        // Read the first batch of the TcpServer response bytes.
                    while (stream.DataAvailable)
                    {
                        Int32 bytes = stream.Read(data, 0, data.Length);
                        RecieveMessage += System.Text.Encoding.ASCII.GetString(data, 0, bytes);

                        //Handle if RecieveMessage = >>SERVER HAS QUIT<<
                        if (RecieveMessage == ">>SERVER HAS QUIT<<")
                        {

                            IsConnected = false;

                                //Raise an event to disconnect:
                            ConnectionTermination("Server Has Terminated Connection!");

                                //Write the message to the log:
                            log.Writer("Server Has Terminated Connection!");
                        }
                        else
                        {
                            //Raise an event to display the message:
                            ConnectionMessage(this, 
                                new ConnectionMessageEventArgs(ScreenStartMsg + RecieveMessage + EndMsg));

                            //Write the message to the log:
                            log.Writer(LogStartMsg + RecieveMessage);
                        }
                    }
                }
                    //If no data:
                catch
                {
                        //do nothing
                }
            }
        }//end RecieveMessage()

        /// <summary>
        /// A method to send a message to the network stream.
        /// </summary>
        /// <param name="Message">The message to send.</param>
        public void SendMessage(String Message)
        {
            if (Message.Equals(""))
            {
                return;
            }

                //Set up the Send Message strings:
            string LogStartMsg = "<CLIENT> : ";
            string EndMsg = "\r\n";

            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] SendMessage = System.Text.Encoding.ASCII.GetBytes(Message);

                //check if the stream is available:
            if (stream.CanWrite)
            {
                try
                {
                    // Send the message to the connected TcpServer.
                    stream.Write(SendMessage, 0, SendMessage.Length);

                    //Raise an event to display the message:
                    ConnectionMessage(this,
                                new ConnectionMessageEventArgs(Message + EndMsg));

                    //Write the message to the log:
                    log.Writer(LogStartMsg + Message);
                }
                catch
                {
                    IsConnected = false;
                    //Raise an event to display the message:
                    ConnectionTermination("Connection To Server Lost!" + EndMsg);

                    //Write the message to the log:
                    log.Writer("Connection To Server Lost!");
                }
            }
        }//end SendMessage()

        /// <summary>
        /// An Disconnect method to handle quitting the server or client
        /// </summary>
        public void Disconnect()
        {
                //set the connection to false:
            IsConnected = false;

            stream.Close();
            client.Close();

                //Raise an event to disconnect:
            ConnectionTermination("Client Has Terminated Connection");

                //Write the message to the log:
            log.Writer("Client Has Terminated Connection");
        }



    }//end Connection
}//end ChatLib
