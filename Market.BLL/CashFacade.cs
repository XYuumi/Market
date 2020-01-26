using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Market.DAT;

namespace Market.BLL
{
    public class CashFacade
    {
        const string ASSEMBLY_NAME = "Market.BLL";

        //得到现金收取类型列表，返回字符串数组 
        public string[] GetCashAcceptTypeList()
        {
            CashAcceptType cat = new CashAcceptType();//定义此类,用于读取XML中的数据
            DataSet ds = cat.GetCashAcceptType();//定义DataSet,用来存储数据
            int rowCount = ds.Tables[0].DefaultView.Count;//读取XML中的下拉框项数
            string[] arrarResult = new string[rowCount];//定义下拉框字符数组
            for (int i = 0; i < rowCount; i++)
            {
                arrarResult[i] = (string)ds.Tables[0].DefaultView[i]["name"];//将下拉框项读取并赋值
            }
            return arrarResult;
        }
        /**//// <summary>
            /// 用于根据商品活动的不同和原价格，计算此商品的实际收费 
            /// </summary>
            /// <param name="selectValue">下拉列表选择的折价类型</param> 
            /// <param name="startTotal">原价</param>
            /// <returns>实际价格</returns>
        public double GetFactTotal(string selectValue, double startTotal)
        {
            CashAcceptType cat = new CashAcceptType();
            DataSet ds = cat.GetCashAcceptType();
            CashContext cc = new CashContext();
            DataRow dr = ((DataRow[])ds.Tables[0].Select("name='" + selectValue + "'"))[0];
            object[] args = null;
            if (dr["para"].ToString() != "")
                args = dr["para"].ToString().Split(',');//读取XML的para中的打折或返现具体值
            cc.setBehavior((CashSuper)Assembly.Load(ASSEMBLY_NAME).CreateInstance(ASSEMBLY_NAME + "."
                       + dr["class"].ToString(), false, BindingFlags.Default, null, args, null, null));//提供正常，打折或返利的具体行为
            return cc.GetResult(startTotal);
        }
    }
}