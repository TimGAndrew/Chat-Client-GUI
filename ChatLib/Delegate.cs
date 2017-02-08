namespace ChatLib
{

     //Event Delegate to handle A Connection Status (to append conversation:);
    //public delegate void ConnectionMessageEventHandler(string showConnectionMessage);
    public delegate void ConnectionMessageEventHandler(object sender, ConnectionMessageEventArgs e);
    //Event Delegate to handle A successful connection (to append conversation, and enable chat in GUI:);
    public delegate void ConnectionSuccessfulEventHandler(string successfulConnectionAttempt);
        //Event Delegate to handle a failed connection:
    public delegate void ConnectionFailedEventHandler();
        //When the Connection is terminated:
    public delegate void ConnectionTerminationEventHandler(string terminationMessage);

}