using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02HandsOnActivity
{
    public partial class CashierWindowQueueForm : Form
    {
        public CashierWindowQueueForm()
        {
            InitializeComponent();
        }
        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (Object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
            timer1.Stop();
        }

        private int click1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                click1++;
                lblTimer.Text = click1.ToString();
                if (click1 == 5)
                {
                    timer1.Stop();
                    click1 = 0;
                    DisplayCashierQueue(CashierClass.CashierQueue.Dequeue());
                    DisplayCashierQueue(CashierClass.CashierQueue);
                }
            }
            catch (System.InvalidOperationException ex)
            {
                timer1.Stop();
                click1 = 0;
                this.Close();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
