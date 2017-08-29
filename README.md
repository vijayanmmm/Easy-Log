# Easy-Log
This project is for logging in the files. it supports multiple data type to log without requiring any conversion.
# Nuget Pacakge
This is available as the nuget package, search "Log.Easy" in the nuget package manager.
# Sample code
## Log a string

       //initialize
        clsLogger m_logger = new clsLogger(Environment.CurrentDirectory + "\\log\\log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", 10);

         
## Log a datatable

            //initialize
            clsLogger m_logger = new clsLogger(Environment.CurrentDirectory + "\\log\\log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", 10);
            //datatable 
            DataTable dtTable = new DataTable();
            dtTable.Columns.Add("ID");
            dtTable.Columns.Add("Name");
            dtTable.Rows.Add(1, "Name1");
            dtTable.Rows.Add(2, "Name2");
            //Log the data table values
            m_logger.Info(dtTable);

## Log a datetime

            //initialize
            clsLogger m_logger = new clsLogger(Environment.CurrentDirectory + "\\log\\log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", 10);
            //Datetime variable
            DateTime dtTem = DateTime.Now;
            //Log
            m_logger.Info(dtTem);

## Log a integer

            //initialize
            clsLogger m_logger = new clsLogger(Environment.CurrentDirectory + "\\log\\log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", 10);
            //Datetime variable
            int intIndex = 456;
            //Log
            m_logger.Info(intIndex);

# why the parameter "intTimeLog_InterVal_Mins" 
This is to add the time stamp in the log file automatically. based on the interval time you have passed as parameter, it will add the time stamp in the log file. (This interval will be checked and added time stamp at the time of new log is been added)
