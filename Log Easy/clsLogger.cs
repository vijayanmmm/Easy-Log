using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Log_Easy
{
    public class clsLogger
    {
        private System.IO.StreamWriter m_fswLogFile;
        private DateTime m_dtLastTimeLog = DateTime.MinValue;
        private int m_intTimeLogInterVal;

        //Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFilePath">Location of the log file-will be created if not exists</param>
        /// <param name="intTimeLog_InterVal_Mins">Automatic Time stamp interval</param>
        public clsLogger(string strFilePath, int intTimeLog_InterVal_Mins = 30)
        {
            m_dtLastTimeLog = System.DateTime.MinValue;
            m_intTimeLogInterVal = 30;
            try
            {
                if (!System.IO.File.Exists(strFilePath))
                {
                    System.IO.File.Create(strFilePath).Close();
                }
                //Open the log file
                m_fswLogFile = new System.IO.StreamWriter(strFilePath, true);
                m_fswLogFile.AutoFlush = true;

                //Time stamp
                m_dtLastTimeLog = DateTime.Now;
                m_fswLogFile.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " TimeStamp");
                m_intTimeLogInterVal = intTimeLog_InterVal_Mins;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Log the data in the log file
        /// </summary>
        /// <param name="objData">direct string value or variable with the following data types string, int, int16,int32,int64, datetime, datatable</param>
        public void Info(string strText)
        {
            //add Timestamp
            checkTimeStamp();
            //Log
            m_fswLogFile.WriteLine(strText);
        }

        /// <summary>
        /// Log the data in the log file
        /// </summary>
        /// <param name="objData">direct string value or variable with the following data types string, int, int16,int32,int64, datetime, datatable</param>
        public void Info(DataTable dtTable)
        {
            //add Timestamp
            checkTimeStamp();
            //Log
            DataTable dtData = dtTable;
            //Print the titles
            m_fswLogFile.WriteLine("====================================================");
            foreach (DataColumn dcHeader in dtTable.Columns)
            {
                m_fswLogFile.WriteLine(dcHeader.ColumnName + "\t");
            }
            m_fswLogFile.WriteLine("====================================================");
            foreach (DataRow drRow in dtTable.Rows)
            {
                for (int j = 0; j < dtTable.Columns.Count; j++)
                {
                    m_fswLogFile.WriteLine(drRow[j].ToString() + "\t");
                }
            }
            m_fswLogFile.WriteLine("====================================================");
        }

        /// <summary>
        /// Log the data in the log file
        /// </summary>
        /// <param name="objData">direct string value or variable with the following data types string, int, int16,int32,int64, datetime, datatable</param>
        public void Info(DateTime dteDateTime)
        {
            //add Timestamp
            checkTimeStamp();
            //Log
            m_fswLogFile.WriteLine(dteDateTime.ToShortDateString() + " " + dteDateTime.ToShortTimeString());
        }

        /// <summary>
        /// Log the data in the log file
        /// </summary>
        /// <param name="objData">int/Int32 dataType</param>
        public void Info(int Value)
        {
            //add Timestamp
            checkTimeStamp();
            //Log
            m_fswLogFile.WriteLine(Value.ToString());
        }

        /// <summary>
        /// Log the data in the log file
        /// </summary>
        /// <param name="objData">direct string value or variable with the following data types string, int, int16,int32,int64, datetime, datatable</param>
        public void Info(Int16 Value)
        {
            //add Timestamp
            checkTimeStamp();
            //Log
            m_fswLogFile.WriteLine(Value.ToString());
        }

        /// <summary>
        /// Log the data in the log file
        /// </summary>
        /// <param name="objData">direct string value or variable with the following data types string, int, int16,int32,int64, datetime, datatable</param>
        public void Info(Int64 Value)
        {
            //add Timestamp
            checkTimeStamp();
            //Log
            m_fswLogFile.WriteLine(Value.ToString());
        }
       
        private void checkTimeStamp()
        {
            //Add the time stamp
            if ((DateTime.Now - m_dtLastTimeLog).Minutes >= 30)
            {
                m_fswLogFile.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " TimeStamp");
                m_dtLastTimeLog = DateTime.Now;
            }
        }

        //destructor
        ~clsLogger()
        {
            if (m_fswLogFile != null)
            {
                m_fswLogFile.Close();
                m_fswLogFile = null;
            }            
        }

    }
}
