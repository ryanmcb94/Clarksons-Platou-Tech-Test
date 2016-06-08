using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cash_Machine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Define Variables
        private Program pgm;

        public MainWindow()
        {
            InitializeComponent();
            //Setup system.
            this.pgm = new Program();
            this.pgm.setup();
            this.displayBalance();
        }


        /// <summary>
        /// Alg 1 least items
        /// </summary>
        private void btnAlg1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(Convert.ToDecimal(txtInput.Text) <0)
                {
                    throw new Exception();
                }
                this.displayWithdraw(this.pgm.Algorithm1(Convert.ToDecimal(txtInput.Text)));
                this.displayBalance();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input is empty or not a valid input. Correct Format XXX.XX","Format Error");
            }
            
        }

        /// <summary>
        /// Alg 2 - Max £20
        /// </summary>
        private void btnAlg2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtInput.Text) < 0)
                {
                    throw new Exception();
                }
                this.displayWithdraw(this.pgm.Algorithm2(Convert.ToDecimal(txtInput.Text),20));
                this.displayBalance();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input is empty or not a valid input. Correct Format XXX.XX", "Format Error");
            }
        }


        /// <summary>
        /// Displays the amount being withdrawn from the system.
        /// </summary>
        /// <param name="withdraw"></param>
        private void displayWithdraw(Dictionary<decimal, int> withdraw)
        {
            
            string strWithdraw = "Withdraw: \n";
            foreach (decimal key in withdraw.Keys)
            {
                if (withdraw[key] > 0)
                {
                    if (key > 1) //if pound
                    {
                        strWithdraw += string.Format("£{0} x {1} \n",key, withdraw[key]);
                    }
                    else
                    {
                        string strKey = String.Format("{0:0.00}", key);
                        strWithdraw += string.Format("{0}p x {1} \n", strKey, withdraw[key]);
                    }
                }
            }
            txtReturned.Text = strWithdraw;
        }

        /// <summary>
        /// Displays balance left in the system.
        /// </summary>
        private void displayBalance()
        {
            string total = String.Format("{0:0.00}", this.pgm.getBalance());
            string balance= String.Format("Total Balance: £{0} \n Items Remaning \n",total);
            foreach(decimal key in this.pgm.balance.Keys)
            {
                if(this.pgm.balance[key] >0)
                {
                    if(key >1) //if pound
                    {
                        balance += string.Format("£{0} x {1} \n", key, this.pgm.balance[key]);
                    }
                    else
                    {
                        balance += string.Format("{0}p x {1} \n", key, this.pgm.balance[key]);
                    }
                }
            }
            txtBalance.Text = balance;
        }

        /// <summary>
        /// Reset Balance.
        /// </summary>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.pgm.setup();
            this.displayBalance();
            this.txtReturned.Text = "";
        }
    }
}
