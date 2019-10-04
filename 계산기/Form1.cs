using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_0904
{
    public partial class Form1 : Form
    {
        bool checkedText = true;  //입력하는 숫자의 처음인지 아닌지 체크
        int result = 0;
        int firstNum = 0;  //입력받는 순간 전의 결과값
        int lastNum = 0;  //입력받는 숫자
        string beforeOpr = "+"; // 직전에 입력한 연산자
        string lastOpr = string.Empty; // 현재 입력한 연산자

        public Form1()
        {
            InitializeComponent();
        }
        // 숫자 or 지우기 버튼 이벤트 처리
        private void Button_Click(object sender, EventArgs e) //sender => 이벤트를 발생한 객체 자신
        {
            // 처음 시작할때, 연산자 입력 후 숫자 입력시 
            // 첫글자는 클리어 후, 입력
            // 그 뒤 문자들은 연결 하여 추가로 입력
            Button btn = (Button)sender;
            if (checkedText)
            {
                this.txtCal.Text += btn.Text; // 복합대입연산자 += 를 사용
            }
            else
            {
                txtCal.Clear();
                this.txtCal.Text += btn.Text;
                checkedText = true;
            }
        }
        // 연산자 버튼 이벤트 처리
        private void Operator_Click(object sender, EventArgs e)
        {
            //시작 
            Button btn = (Button)sender;
            lastNum = int.Parse(txtCal.Text);
            lastOpr = btn.Text;  //입력받은 연산자
            switch (beforeOpr)
            {
                case "+":
                    result = firstNum + lastNum;
                    break;
                case "-":
                    result = firstNum - lastNum;
                    break;
                case "/":
                    result = firstNum / lastNum;
                    break;
                case "x":
                    result = firstNum * lastNum;
                    break;
            }
            firstNum = result;
            this.txtCal.Text = result.ToString();
            beforeOpr = lastOpr;
            checkedText = false;  // 연산자 입력 후 다음 숫자 입력시 클리어 하기위한 bool
        }
        //계산기 리셋 버튼 이벤트(초기 설정)
        private void Reset_Click(object sender, EventArgs e)
        {
            result = 0;
            firstNum = 0;
            lastNum = 0;
            beforeOpr = "+"; // 직전에 입력한 연산자
            lastOpr = string.Empty; // 현재 입력한 연산자
            txtCal.Clear();
        }
        // 지우기 버튼 이벤트
        private void Erase_Click(object sender, EventArgs e)
        {
            this.txtCal.Text = this.txtCal.Text.Substring(0, txtCal.Text.Length - 1);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys temp = e.KeyCode;
        }
    }
}