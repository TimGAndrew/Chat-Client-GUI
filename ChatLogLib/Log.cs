using System;
using System.IO;

namespace ChatLogLib
{
    /// <summary>
    /// Log class to handle logging
    /// </summary>
    public class Log
    {
        private string LogFileName = "";

        /// <summary>
        /// Log constructor
        /// </summary>
        public Log()
        {
                //Grab the current time as a string:
            string time = DateTime.Now.ToString("yyyy-MM-dd(hh_mm_tt)", 
                            System.Globalization.CultureInfo.GetCultureInfo("en-CA"));
                
                //Use the time to set the LogFileName:
            LogFileName = "ChatLog[" + time + "].log";
            
        }//End Log() constructor

        /// <summary>
        /// A method to write to the log file.
        /// </summary>
        /// <param name="logEntry">The string to append to the log</param>
        public void Writer(string logEntry)
        {
                //Open a new streamwriter to the LogFileName:
            StreamWriter file = new StreamWriter(@LogFileName, true);

                //Attempt to write the Log Entry
            try
            {
                file.WriteLine(LogTimestamp() + logEntry);
            }
                //What to do if this fails:
            catch
            {
                    //Nothing
            }
                //Close the file:
            file.Close();

        }//End Writer() method

        /// <summary>
        /// A method to get the leading timestamp for a ChatLog
        /// </summary>
        /// <returns>Current Timestamp</returns>
        private string LogTimestamp()
        {
            string now = DateTime.Now.ToString("[yyyy-MM-dd@hh:mm tt] - ",
                            System.Globalization.CultureInfo.GetCultureInfo("en-CA"));
            return now;
        }
    }//End Log class
}//End ChatLogLib library
