using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BLL
{
    abstract class CashSuper
    {
        //抽象方法：收取现金，参数为原价，返回为当前价 
        public abstract double acceptCash(double money);
    }
}
