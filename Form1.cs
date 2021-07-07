using System;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {
        private double frequency; // 晶振
        private int frequencyDivision; // 分频
        private int duration; // 时间
        private int starter; // 初值(10进制)

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int periodicBitValue = 0xffff;

            string fdText = textBox3.Text.Trim();
            if (!int.TryParse(fdText, out frequencyDivision))
            {
                MessageBox.Show("请输入正确的分频值");
                return;
            }
            if (frequencyDivision <= 0)
            {
                MessageBox.Show("分频值必须为正整数");
                return;
            }

            string frText = textBox1.Text.Trim();
            if (!double.TryParse(frText, out frequency))
            {
                MessageBox.Show("请输入正确的晶振值");
                return;
            }
            if (frequency <= 0)
            {
                MessageBox.Show("晶振值必须为正数");
                return;
            }
            frequency = frequency * 10e5;
            double msTimes = (frequency / frequencyDivision) / 1000; // 每ms机器周期次数
        
            string duText = textBox2.Text.Trim();
            if (!int.TryParse(duText, out duration))
            {
                MessageBox.Show("请输入定时时长");
                return;
            }
            if (duration <= 0)
            {
                MessageBox.Show("定时时长值必须为正整数");
                return;
            }
            int durationTimes = (int)(duration * msTimes);
           
            starter = periodicBitValue + 1 - durationTimes;
            label3.Text = Convert.ToString(starter, 16);
        }
    }
}
