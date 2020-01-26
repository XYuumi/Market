using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Market.DAT
{
    public class CashAcceptType
    {
        public DataSet GetCashAcceptType()
        {
            //读配置文件到DataSet
            DataSet ds = new DataSet();
            ds.ReadXml(@"C:\Users\hp\Desktop\寒假作业\商场收银系统\Market\Market.DAT\CashAcceptType.xml");
            return ds;
        }
    }
}