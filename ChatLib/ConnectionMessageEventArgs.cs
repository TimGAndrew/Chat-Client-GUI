using System;

namespace ChatLib
{
        /// <summary>
        /// Handles the Connection Message Event Args
        /// </summary>
    public class ConnectionMessageEventArgs : EventArgs
    {
        public ConnectionMessageEventArgs(string ConnectionMessage)
        {
            this.ConnectionMessage = ConnectionMessage;
        }

        public string ConnectionMessage { get; }
    }
}