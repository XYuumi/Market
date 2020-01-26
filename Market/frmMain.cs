using System;
using System.Windows.Forms;
using Market.BLL;

namespace Market
{
    public partial class frmMain : Form
    {
        double total = 0.0d;//用于总计 
        CashFacade cf = new CashFacade();
        public frmMain()
        {
            InitializeComponent();
        }
        //加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            //读数据绑定下拉列表 
            cbxType.DataSource = cf.GetCashAcceptTypeList();
            cbxType.SelectedIndex = 0;
        }
        //确定按钮
        private void btnOk_Click(object sender, EventArgs e)
        {
            double totalPrices = 0d;
            //传进下拉选择值和原价，计算实际收费结果
            totalPrices = cf.GetFactTotal(cbxType.SelectedItem.ToString(), Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text));
            total = total + totalPrices;
            lbxList.Items.Add("单价：" + txtPrice.Text + " 数量：" + txtNum.Text + " " + cbxType.SelectedItem + " 合计： " + totalPrices.ToString());
            lblResult.Text = total.ToString();
        }
        //重置按钮
        private void reset_Click(object sender, EventArgs e)
        {
            lbxList.Items.Clear();
            total = 0;
            txtPrice.Text = "0";
            txtNum.Text = "0";
            lblResult.Text = "0.00";
            cbxType.SelectedIndex = 0;
        }
    }
}
