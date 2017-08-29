using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Log_Easy;
using System.Data;

namespace Log_Easy_Tests
{
    [TestClass]
    public class clsLoggerTests
    {
        //initialize
        clsLogger m_logger = new clsLogger(Environment.CurrentDirectory + "\\log\\log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", 10);

        [TestMethod]
        public void Log_String()
        {
            //Log simple string
            m_logger.Info("Going to process the step1");
        }


        [TestMethod]
        public void Log_Int()
        {
            //Datetime variable
            int intIndex = 456;
            //Log
            m_logger.Info(intIndex);            
        }

        [TestMethod]
        public void Log_Datetime()
        {
            //Datetime variable
            DateTime dtTem = DateTime.Now;
            //Log
            m_logger.Info(dtTem);
        }


        [TestMethod]
        public void LogDataTable()
        {
            //datatable 
            DataTable dtTable = new DataTable();
            dtTable.Columns.Add("ID");
            dtTable.Columns.Add("Name");
            dtTable.Rows.Add(1, "Name1");
            dtTable.Rows.Add(2, "Name2");
            //Log the data table values
            m_logger.Info(dtTable);
        }

        [TestMethod]
        public void Log_MultipleValues()
        {
            //Log simple string
            m_logger.Info("Going to process the step1");
            //Datetime variable
            int intIndex = 456;
            //Log
            m_logger.Info(intIndex);
            //Datetime variable
            DateTime dtTem = DateTime.Now;
            //Log
            m_logger.Info(dtTem);
            //datatable 
            DataTable dtTable = new DataTable();
            dtTable.Columns.Add("ID");
            dtTable.Columns.Add("Name");
            dtTable.Rows.Add(1, "Name1");
            dtTable.Rows.Add(2, "Name2");
            //Log the data table values
            m_logger.Info(dtTable);
        }
    }
}
