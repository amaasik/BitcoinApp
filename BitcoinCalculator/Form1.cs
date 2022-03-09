using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitcoinCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetRates_Click(object sender, EventArgs e)
        {
            if(currencyCombo.SelectedItem.ToString() == "EUR")
            {
                resultLabel.Visible = true;
                ResultTextBox.Visible = true;
                BitcoinRates bitcoin = GetRates();
                float result = Int32.Parse(ammountOfCoinBox.Text) * bitcoin.bpi.EUR.rate_float;
                ResultTextBox.Text = $"{result.ToString()} {bitcoin.bpi.EUR.code}";
                
                
            }
            if (currencyCombo.SelectedItem.ToString() == "USD")
            {
                resultLabel.Visible = true;
                ResultTextBox.Visible = true;
                BitcoinRates bitcoin = GetRates();
                float result = Int32.Parse(ammountOfCoinBox.Text) * bitcoin.bpi.USD.rate_float;
                ResultTextBox.Text = $"{result.ToString()} {bitcoin.bpi.USD.code}";


            }
        }

        public static BitcoinRates GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request=(HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse= request.GetResponse();
            var webStream= webResponse.GetResponseStream();

            BitcoinRates bitcoin;
            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<BitcoinRates>(response);

            }
            return bitcoin;
        }

        private void Currency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ammountOfCoin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
