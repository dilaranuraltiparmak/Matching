using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Matching
{
    public partial class Form1 : Form
    {
        List<string> icons = new List<string>()
        {
            "d","y","l","m","n","z","v","b",
              "d","y","l","m","n","z","v","b"
        };
        Random rn = new Random();
        int randomindex;
        Timer timer = new Timer();
        Timer timer2 = new Timer();
        Button first, second;
        public Form1()
        {
            InitializeComponent();

            timer.Tick += Timer_Tick;
            //zamanlayıcı ayarlaması
            timer2.Tick += Timer2_Tick;
            timer.Start();
            timer.Interval = 3000;
            show();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            first.ForeColor = first.BackColor;
            second.ForeColor = second.BackColor;
            first = null;
            second = null;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            //butonları gizleme için foreach kullanılmıştır.
            foreach (Button item in Controls)
            {
                //butonların rengi arkaplan rengiyle aynı(gizleme için).
                item.ForeColor = item.BackColor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void show()
        {
            Button buton;
            foreach (Button item in Controls)
            {
                buton = item as Button;
                //buton kontrollere gönderildi
                randomindex = rn.Next(icons.Count);
                buton.Text = icons[randomindex];
                buton.ForeColor = Color.Black;
                //üretilen sayıyı tekrar tekrar kullanmamak için remove kullanılır.
                icons.RemoveAt(randomindex);
            }
        }

        private void Buton_Click(object sender, EventArgs e)
        {
            //hangi butona basarsak onun işlemini gerçekleştirecek.
            Button btnn = sender as Button;
            if (first == null)
            {
                first = btnn;
                first.ForeColor = Color.Black;
                return;
            }
            second = btnn;
            second.ForeColor = Color.Black;
            if (first.Text == second.Text)
            {
                first.ForeColor = Color.Black;
                second.ForeColor = Color.Black;
                first = null;
                second = null;
            }
            else
            {
                timer2.Start();
                timer2.Interval = 1000;
            }
        }
    }
}
