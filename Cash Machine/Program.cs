using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cash_Machine
{
    class Program
    {
        //Define Variables
        public Dictionary<decimal, int> balance { get; set; } //Stores inital states with key being item value and value being the number of each item left

        /// <summary>
        /// Add Values to the system.
        /// </summary>
        public void setup()
        {
            this.balance = new Dictionary<decimal, int>();
            balance.Add(50, 50);
            balance.Add(20, 50);
            balance.Add(10, 50);
            balance.Add(5, 50);
            balance.Add(2, 100);
            balance.Add(1, 100);
            balance.Add((decimal)0.50, 100);
            balance.Add((decimal)0.20, 100);
            balance.Add((decimal)0.10, 100);
            balance.Add((decimal)0.05 , 100);
            balance.Add((decimal)0.02, 100);
            balance.Add((decimal)0.01, 100);
        }

        /// <summary>
        /// Get Total Amount Left
        /// </summary>
        /// <returns>Double with value</returns>
        public decimal getBalance()
        {
            decimal value = 0;
            foreach (decimal key in balance.Keys)
            {
                value += key * balance[key];
            }
            return value;
        }

        /// <summary>
        /// Alg1 - Least amount of items
        /// </summary>
        /// <param name="amount">Amount to be withdrawn</param>
        public Dictionary<decimal, int> Algorithm1(decimal amount)
        {
            Dictionary<decimal, int> toGive = new Dictionary<decimal, int>();
            //Check if balance > amount
            if (this.getBalance() < amount)
                MessageBox.Show("Not enough funds in cash machine");
            else
            {
                foreach (decimal key in this.balance.Keys)
                {
                    if (amount > 0)
                    {
                        int num = Convert.ToInt32(Math.Floor(amount / key)); // Find how many of the current item can be applied to the amount
                        if (this.balance[key] > num && num > 0) // of the is more than the number of items that can be applied to the amount
                        {
                            toGive.Add(key, num);
                            amount -= key * num;
                        }
                        else if (this.balance[key] > 0 && num > 0)
                        {
                            toGive.Add(key, this.balance[key]);
                            amount -= key * this.balance[key];
                        }
                    }
                    else
                    {

                        break;
                    }

                }
            }

            foreach (decimal key in toGive.Keys) //Update Balance.
            {
                this.balance[key] = this.balance[key] - toGive[key];
            }
            return toGive;

        }

        /// <summary>
        /// Alg2 - Max £20
        /// </summary>
        /// <param name="amount">Amount to be withdrawn</param>
        /// <param name="focus">The item to focus i.e 20</param>
        public Dictionary<decimal, int> Algorithm2(decimal amount,decimal focus)
        {
            Dictionary<decimal, int> toGive = new Dictionary<decimal, int>();
            //Check if balance > amount
            if (this.getBalance() < amount)
                MessageBox.Show("Not enough funds in cash machine");
            else 
            {
                if (amount > 0) //£20 Notes
                {
                    int num = Convert.ToInt32(Math.Floor(amount / focus));
                    if (this.balance[20] > num && num > 0)
                    {
                        toGive.Add(20, num);
                        amount -= 20 * num;
                    }
                }
                foreach (decimal key in this.balance.Keys) //All other values.
                {
                    if (amount > 0)
                    {
                        if (key != 20)
                        {
                            int num = Convert.ToInt32(Math.Floor(amount / key)); // Find how many of the current item can be applied to the amount
                            if (this.balance[key] > num && num > 0) // of the is more than the number of items that can be applied to the amount
                            {
                                toGive.Add(key, num);
                                amount -= key * num;
                            }
                            else if (this.balance[key] > 0 && num > 0)
                            {
                                toGive.Add(key, this.balance[key]);
                                amount -= key * this.balance[key];
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            foreach (decimal key in toGive.Keys) //Update Balance.
            {
                this.balance[key] = this.balance[key] - toGive[key];
            }
            return toGive;
        }
    }
}
