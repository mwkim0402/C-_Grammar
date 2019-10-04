using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonGame
{
    public partial class Form1 : Form
    {
        int firstindex = -1;
        int secondindex = -1;
        int FirstTag = -1;
        int secondTag = -1;
        int point = 0;
        int timeSeconds = 0;
        int cnt = 0;

        Button[] button;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            button = new Button[] { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15 };
            foreach (Button btn in button)
            {
                btn.Image = imageList1.Images[8];
                btn.Enabled = false;
            }
        }

        private void 시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer3.Stop();
            timeSeconds = 0;
            lbTime.Text = timeSeconds.ToString();
            MakeRandomButton();
            foreach (Button btn in panel1.Controls)
            {
                btn.Image = imageList1.Images[Convert.ToInt32(btn.Tag)];
                btn.Enabled = false;
            }
            timer1.Start();
            cnt = 16;
        }

        bool FirstClick = true;
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (FirstClick)
            {
                firstindex = btn.TabIndex;
                FirstClick = false;
                FirstTag = Convert.ToInt32(btn.Tag);
                btn.Image = imageList1.Images[Convert.ToInt32(btn.Tag)];
            }
            else
            {
                if (firstindex == btn.TabIndex)
                {
                    return;
                }
                secondindex = btn.TabIndex;
                secondTag = Convert.ToInt32(btn.Tag);
                btn.Image = imageList1.Images[Convert.ToInt32(btn.Tag)];

                timer2.Start();
                FirstClick = true;
            }
        }
        private void MakeRandomButton()
        {
            Random ran = new Random();
            bool isUnique;
            int[] ranNum = new int[16];
            ranNum[0] = ran.Next(0, 16);
            int cnt = 1;
            while (cnt < 16)
            {
                int temp = ran.Next(0, 16);
                isUnique = true;
                for (int i = 0; i < cnt; i++)
                {
                    if (ranNum[i] == temp)
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique)
                {
                    ranNum[cnt] = temp;
                    cnt++;
                }
            }
            int index = 0;
            foreach (Button btn in button)
            {
                btn.Tag = ranNum[index] % 8;
                index++;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            foreach (Button btn in panel1.Controls)
            {
                btn.Image = imageList1.Images[8];
                btn.Enabled = true ;
            }
            timer3.Start();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (FirstTag == secondTag)
            {
                point += 500;
                label2.Text = point.ToString();
                cnt -= 2;
                button[firstindex].Enabled = false;
                button[secondindex].Enabled = false;
                if (cnt == 0)
                {
                    timer3.Stop();
                }
                timer2.Stop();
                return;
            }
            else
            button[firstindex].Image = imageList1.Images[8];
            button[secondindex].Image = imageList1.Images[8];
            firstindex = -1;
            secondindex = -1;
            FirstTag = -1;
            secondTag = -1;
            timer2.Stop();
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            timeSeconds++;
            lbTime.Text = timeSeconds.ToString();
        }
    }
}
