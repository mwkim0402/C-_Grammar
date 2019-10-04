namespace PhoneBookWin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;

    public class Form1 : Form
    {
        private HashSet<PhoneInfo> infoStorage = new HashSet<PhoneInfo>();
        //private readonly string dataFile = "PhoneBook.dat";
        private string dataFile;
        private IContainer components = null;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private TabPage tabPage12;
        private TabPage tabPage13;
        private TabPage tabPage14;
        private Panel panel3;
        private Panel panUpdate;
        private Label label3;
        private Label label2;
        private Button btnSearch;
        private Button btnRegister;
        private TextBox txtPhoneNum;
        private TextBox txtName;
        private Label label6;
        private Label label5;
        private Label label8;
        private TextBox txtSearchName;
        private Panel radioPanel;
        private Label label9;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private RadioButton radioButton9;
        private GroupBox groupBox1;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox txtShowEtc;
        private TextBox txtShowPhone;
        private TextBox txtShowName;
        private Label label30;
        private TextBox txtShowCompare;
        private ColumnHeader 이름;
        private ColumnHeader 분류;
        private ColumnHeader 전화번호;
        private ColumnHeader 기타;
        private TabPage tabAll;
        private Label label7;
        private TextBox txtCompany;
        private Panel panSchool;
        private TextBox txtGrade;
        private Label label10;
        private Label label14;
        private TextBox txtSchool;
        private Button btnDelete;
        private ListView listView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem 파일저장ToolStripMenuItem;
        private ToolStripMenuItem 종료ToolStripMenuItem;
        private ToolStripMenuItem 종료ToolStripMenuItem1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private Label labelTxt;
        private TabControl tabControl2;
        private TabPage tabRegis;
        private TabPage tabUpdate;
        private Button btnUpdateSearch;
        private Button btnUpdate;
        string etc = string.Empty;

        public Form1()
        {
            this.InitializeComponent();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string text = this.txtSearchName.Text;
            bool flag = false;
            foreach (PhoneInfo info in this.infoStorage)
            {
                if (text.CompareTo(info.Name) == 0)
                {
                    this.infoStorage.Remove(info);
                    flag = true;
                    MessageBox.Show("주소록 삭제가 완료되었습니다. \n");
                    break;
                }
            }
            if (!flag)
            {
                MessageBox.Show("해당하는 데이터가 존재하지 않습니다. \n");
            }
            this.SelectTabText();
            this.txtShowName.Clear();
            this.txtShowPhone.Clear();
            this.txtShowCompare.Clear();
            this.txtShowEtc.Clear();
        }
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string compare = string.Empty;
            foreach (object obj2 in this.radioPanel.Controls)
            {
                RadioButton button = (RadioButton)obj2;
                if (button.Checked)
                {
                    compare = button.Text;
                    if (compare == "일반")
                    {
                        etc = "";
                    }
                    else if (compare == "회사")
                    {
                        etc = "회사명 :" + txtCompany.Text;
                    }
                    else
                    {
                        txtCompany.Visible = false;
                        panSchool.Visible = true;
                        etc = "학교: " + txtSchool.Text + ", 학년: " + txtGrade.Text;
                    }
                }
            }
            this.infoStorage.Add(new PhoneInfo(this.txtName.Text, this.txtPhoneNum.Text, compare, etc));
            MessageBox.Show("등록하였습니다.");
            this.txtName.Clear();
            this.txtPhoneNum.Clear();
            this.radioButton9.Checked = true;
            this.txtCompany.Clear();
            txtSchool.Clear();
            txtGrade.Clear();
            this.SelectTabText();
        }
        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // this.storeToFile();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // this.readFromFile();
            this.radioButton9.Checked = true;
            //     this.SelectTabText();
            listView1.FullRowSelect = true;
            btnUpdateSearch.Visible = false;
            btnUpdate.Visible = false;
        }
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtShowCompare = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtShowEtc = new System.Windows.Forms.TextBox();
            this.txtShowPhone = new System.Windows.Forms.TextBox();
            this.txtShowName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panUpdate = new System.Windows.Forms.Panel();
            this.labelTxt = new System.Windows.Forms.Label();
            this.panSchool = new System.Windows.Forms.Panel();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSchool = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.radioPanel = new System.Windows.Forms.Panel();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.이름 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.분류 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.전화번호 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.기타 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.파일저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabRegis = new System.Windows.Forms.TabPage();
            this.tabUpdate = new System.Windows.Forms.TabPage();
            this.btnUpdateSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panUpdate.SuspendLayout();
            this.panSchool.SuspendLayout();
            this.radioPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAll);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage13);
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Location = new System.Drawing.Point(0, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(752, 22);
            this.tabControl1.TabIndex = 39;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabAll
            // 
            this.tabAll.Location = new System.Drawing.Point(4, 22);
            this.tabAll.Name = "tabAll";
            this.tabAll.Size = new System.Drawing.Size(744, 0);
            this.tabAll.TabIndex = 14;
            this.tabAll.Text = "All";
            this.tabAll.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(744, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ㄱ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(744, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ㄴ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(744, 0);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ㄷ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(744, 0);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "ㄹ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(744, 0);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "ㅁ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(744, 0);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "ㅂ";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(744, 0);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "ㅅ";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(744, 0);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "ㅇ";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(744, 0);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "ㅈ";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(744, 0);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "ㅊ";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(744, 0);
            this.tabPage11.TabIndex = 10;
            this.tabPage11.Text = "ㅋ";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // tabPage12
            // 
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(744, 0);
            this.tabPage12.TabIndex = 11;
            this.tabPage12.Text = "ㅌ";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // tabPage13
            // 
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Size = new System.Drawing.Size(744, 0);
            this.tabPage13.TabIndex = 12;
            this.tabPage13.Text = "ㅍ";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // tabPage14
            // 
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Size = new System.Drawing.Size(744, 0);
            this.tabPage14.TabIndex = 13;
            this.tabPage14.Text = "ㅎ";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panUpdate);
            this.panel1.Location = new System.Drawing.Point(744, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 711);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtSearchName);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Location = new System.Drawing.Point(0, 315);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(424, 357);
            this.panel3.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(312, 75);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 24);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.txtShowCompare);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtShowEtc);
            this.groupBox1.Controls.Add(this.txtShowPhone);
            this.groupBox1.Controls.Add(this.txtShowName);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(10, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 187);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검색 데이터";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label30.Location = new System.Drawing.Point(24, 68);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(42, 16);
            this.label30.TabIndex = 41;
            this.label30.Text = "분류";
            // 
            // txtShowCompare
            // 
            this.txtShowCompare.Enabled = false;
            this.txtShowCompare.Location = new System.Drawing.Point(129, 65);
            this.txtShowCompare.Name = "txtShowCompare";
            this.txtShowCompare.Size = new System.Drawing.Size(86, 26);
            this.txtShowCompare.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(24, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 16);
            this.label11.TabIndex = 39;
            this.label11.Text = "비고";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(24, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 16);
            this.label12.TabIndex = 38;
            this.label12.Text = "전화번호";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(24, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 16);
            this.label13.TabIndex = 37;
            this.label13.Text = "검색한 이름";
            // 
            // txtShowEtc
            // 
            this.txtShowEtc.Enabled = false;
            this.txtShowEtc.Location = new System.Drawing.Point(129, 129);
            this.txtShowEtc.Name = "txtShowEtc";
            this.txtShowEtc.Size = new System.Drawing.Size(258, 26);
            this.txtShowEtc.TabIndex = 36;
            // 
            // txtShowPhone
            // 
            this.txtShowPhone.Enabled = false;
            this.txtShowPhone.Location = new System.Drawing.Point(129, 97);
            this.txtShowPhone.Name = "txtShowPhone";
            this.txtShowPhone.Size = new System.Drawing.Size(180, 26);
            this.txtShowPhone.TabIndex = 35;
            // 
            // txtShowName
            // 
            this.txtShowName.Enabled = false;
            this.txtShowName.Location = new System.Drawing.Point(129, 33);
            this.txtShowName.Name = "txtShowName";
            this.txtShowName.Size = new System.Drawing.Size(86, 26);
            this.txtShowName.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(23, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 16);
            this.label8.TabIndex = 27;
            this.label8.Text = "이름";
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(94, 75);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(123, 21);
            this.txtSearchName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(2, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(255, 32);
            this.label6.TabIndex = 21;
            this.label6.Text = "전화번호 검색 및 삭제";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(234, 75);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 24);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "찾기";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.Search_Click);
            // 
            // panUpdate
            // 
            this.panUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panUpdate.Controls.Add(this.btnUpdate);
            this.panUpdate.Controls.Add(this.btnUpdateSearch);
            this.panUpdate.Controls.Add(this.labelTxt);
            this.panUpdate.Controls.Add(this.panSchool);
            this.panUpdate.Controls.Add(this.label7);
            this.panUpdate.Controls.Add(this.txtCompany);
            this.panUpdate.Controls.Add(this.label9);
            this.panUpdate.Controls.Add(this.radioPanel);
            this.panUpdate.Controls.Add(this.label5);
            this.panUpdate.Controls.Add(this.label3);
            this.panUpdate.Controls.Add(this.label2);
            this.panUpdate.Controls.Add(this.btnRegister);
            this.panUpdate.Controls.Add(this.txtPhoneNum);
            this.panUpdate.Controls.Add(this.txtName);
            this.panUpdate.Location = new System.Drawing.Point(0, 25);
            this.panUpdate.Name = "panUpdate";
            this.panUpdate.Size = new System.Drawing.Size(424, 293);
            this.panUpdate.TabIndex = 0;
            this.panUpdate.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2_Paint);
            // 
            // labelTxt
            // 
            this.labelTxt.AutoSize = true;
            this.labelTxt.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTxt.Location = new System.Drawing.Point(110, 4);
            this.labelTxt.Name = "labelTxt";
            this.labelTxt.Size = new System.Drawing.Size(63, 32);
            this.labelTxt.TabIndex = 27;
            this.labelTxt.Text = "등록";
            // 
            // panSchool
            // 
            this.panSchool.Controls.Add(this.txtGrade);
            this.panSchool.Controls.Add(this.label10);
            this.panSchool.Controls.Add(this.label14);
            this.panSchool.Controls.Add(this.txtSchool);
            this.panSchool.Location = new System.Drawing.Point(36, 200);
            this.panSchool.Name = "panSchool";
            this.panSchool.Size = new System.Drawing.Size(254, 51);
            this.panSchool.TabIndex = 26;
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(82, 27);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(161, 21);
            this.txtGrade.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(1, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "학년";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(1, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 16);
            this.label14.TabIndex = 25;
            this.label14.Text = "학교";
            // 
            // txtSchool
            // 
            this.txtSchool.Location = new System.Drawing.Point(82, 0);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(161, 21);
            this.txtSchool.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(39, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "회사명";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(121, 173);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(161, 21);
            this.txtCompany.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(39, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "분류";
            // 
            // radioPanel
            // 
            this.radioPanel.Controls.Add(this.radioButton7);
            this.radioPanel.Controls.Add(this.radioButton8);
            this.radioPanel.Controls.Add(this.radioButton9);
            this.radioPanel.Location = new System.Drawing.Point(121, 125);
            this.radioPanel.Name = "radioPanel";
            this.radioPanel.Size = new System.Drawing.Size(161, 41);
            this.radioPanel.TabIndex = 21;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(110, 12);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(47, 16);
            this.radioButton7.TabIndex = 3;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "학교";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.RadioButton9_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(57, 12);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(47, 16);
            this.radioButton8.TabIndex = 2;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "회사";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.RadioButton9_CheckedChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(4, 12);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(47, 16);
            this.radioButton9.TabIndex = 1;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "일반";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.RadioButton9_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 32);
            this.label5.TabIndex = 20;
            this.label5.Text = "전화번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(40, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "전화번호";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(40, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "이름";
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRegister.Location = new System.Drawing.Point(312, 201);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(83, 37);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "등록";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(122, 98);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(258, 21);
            this.txtPhoneNum.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(122, 71);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 21);
            this.txtName.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.이름,
            this.분류,
            this.전화번호,
            this.기타});
            this.listView1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 45);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(744, 629);
            this.listView1.TabIndex = 39;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDoubleClick);
            // 
            // 이름
            // 
            this.이름.Text = "이름";
            this.이름.Width = 109;
            // 
            // 분류
            // 
            this.분류.Text = "분류";
            this.분류.Width = 68;
            // 
            // 전화번호
            // 
            this.전화번호.Text = "전화번호";
            this.전화번호.Width = 202;
            // 
            // 기타
            // 
            this.기타.Text = "기타";
            this.기타.Width = 361;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1169, 24);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일저장ToolStripMenuItem,
            this.종료ToolStripMenuItem,
            this.종료ToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItem1.Text = "메뉴";
            // 
            // 파일저장ToolStripMenuItem
            // 
            this.파일저장ToolStripMenuItem.Name = "파일저장ToolStripMenuItem";
            this.파일저장ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.파일저장ToolStripMenuItem.Text = "파일 열기";
            this.파일저장ToolStripMenuItem.Click += new System.EventHandler(this.파일저장ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.종료ToolStripMenuItem.Text = "파일 저장";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem1
            // 
            this.종료ToolStripMenuItem1.Name = "종료ToolStripMenuItem1";
            this.종료ToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.종료ToolStripMenuItem1.Text = "종료";
            this.종료ToolStripMenuItem1.Click += new System.EventHandler(this.종료ToolStripMenuItem1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "파일|*.dat";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "파일|*.dat";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabRegis);
            this.tabControl2.Controls.Add(this.tabUpdate);
            this.tabControl2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl2.Location = new System.Drawing.Point(744, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(200, 24);
            this.tabControl2.TabIndex = 28;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.TabControl2_SelectedIndexChanged);
            // 
            // tabRegis
            // 
            this.tabRegis.Location = new System.Drawing.Point(4, 26);
            this.tabRegis.Name = "tabRegis";
            this.tabRegis.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegis.Size = new System.Drawing.Size(192, 0);
            this.tabRegis.TabIndex = 0;
            this.tabRegis.Text = "등록";
            this.tabRegis.UseVisualStyleBackColor = true;
            // 
            // tabUpdate
            // 
            this.tabUpdate.Location = new System.Drawing.Point(4, 26);
            this.tabUpdate.Name = "tabUpdate";
            this.tabUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpdate.Size = new System.Drawing.Size(192, 0);
            this.tabUpdate.TabIndex = 1;
            this.tabUpdate.Text = "수정";
            this.tabUpdate.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSearch
            // 
            this.btnUpdateSearch.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdateSearch.Location = new System.Drawing.Point(300, 70);
            this.btnUpdateSearch.Name = "btnUpdateSearch";
            this.btnUpdateSearch.Size = new System.Drawing.Size(80, 22);
            this.btnUpdateSearch.TabIndex = 28;
            this.btnUpdateSearch.Text = "검색";
            this.btnUpdateSearch.UseVisualStyleBackColor = true;
            this.btnUpdateSearch.Click += new System.EventHandler(this.BtnUpdateSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Location = new System.Drawing.Point(312, 200);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(83, 37);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 674);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "전화번호부";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panUpdate.ResumeLayout(false);
            this.panUpdate.PerformLayout();
            this.panSchool.ResumeLayout(false);
            this.panSchool.PerformLayout();
            this.radioPanel.ResumeLayout(false);
            this.radioPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void readFromFile()
        {
            if (File.Exists(this.dataFile))
            {
                try
                {
                    Stream serializationStream = new FileStream(this.dataFile, FileMode.Open);
                    BinaryFormatter formatter = new BinaryFormatter();
                    this.infoStorage.Clear();
                    this.infoStorage = (HashSet<PhoneInfo>)formatter.Deserialize(serializationStream);
                    serializationStream.Close();
                }
                catch (IOException exception1)
                {
                    Console.WriteLine(exception1.Message);
                }
                catch (Exception exception3)
                {
                    Console.WriteLine(exception3.Message);
                }
            }
        }
        private void Search_Click(object sender, EventArgs e)
        {
            this.txtShowName.Clear();
            this.txtShowPhone.Clear();
            this.txtShowCompare.Clear();
            this.txtShowEtc.Clear();
            string text = this.txtSearchName.Text;
            PhoneInfo objA = this.searchName(text);
            if (ReferenceEquals(objA, null))
            {
                MessageBox.Show("해당하는 데이터가 존재하지 않습니다. ");
            }
            else
            {
                this.txtShowName.Text = objA.Name;
                this.txtShowPhone.Text = objA.PhoneNumber;
                this.txtShowCompare.Text = objA.Compare;
                this.txtShowEtc.Text = objA.Etc;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[0].Text == text)
                    {
                        listView1.Items[i].Selected = true;
                    }
                }
            }
        }
        private PhoneInfo searchName(string name)
        {
            using (HashSet<PhoneInfo>.Enumerator enumerator = this.infoStorage.GetEnumerator())
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        break;
                    }
                    PhoneInfo current = enumerator.Current;
                    if (name.CompareTo(current.Name) == 0)
                    {
                        return current;
                    }
                }
            }
            return null;
        }
        private void SelectTabText()
        {
            this.listView1.Items.Clear();
            string text = this.tabControl1.SelectedTab.Text;
            string temp = string.Empty;
            if (text != null)
            {
                if (text == "All")
                {
                    foreach (var v in infoStorage)
                    {
                        ListViewItem item = new ListViewItem(v.Name)
                        {
                            SubItems = {
                                    v.Compare,
                                    v.PhoneNumber,
                                    v.Etc
                                }
                        };
                        this.listView1.Items.Add(item);
                    }
                    this.listView1.EndUpdate();
                    return;
                }
                switch (text)
                {
                    case "ㄱ":
                        temp = "ㄴ";
                        break;
                    case "ㄴ":
                        temp = "ㄷ";
                        break;
                    case "ㄷ":
                        temp = "ㄹ";
                        break;
                    case "ㄹ":
                        temp = "ㅁ";
                        break;
                    case "ㅁ":
                        temp = "ㅂ";
                        break;
                    case "ㅂ":
                        temp = "ㅅ";
                        break;
                    case "ㅅ":
                        temp = "ㅇ";
                        break;
                    case "ㅇ":
                        temp = "ㅈ";
                        break;
                    case "ㅈ":
                        temp = "ㅊ";
                        break;
                    case "ㅊ":
                        temp = "ㅋ";
                        break;
                    case "ㅋ":
                        temp = "ㅌ";
                        break;
                    case "ㅌ":
                        temp = "ㅍ";
                        break;
                    case "ㅍ":
                        temp = "ㅎ";
                        break;
                    case "ㅎ":
                        temp = "힁";
                        break;
                }
                foreach (var v in infoStorage)
                {
                    if (v.Name.CompareTo(text) >= 0 && v.Name.CompareTo(temp) < 0)
                    {
                        ListViewItem item = new ListViewItem(v.Name)
                        {
                            SubItems = {
                                    v.Compare,
                                    v.PhoneNumber,
                                    v.Etc
                                }
                        };
                        this.listView1.Items.Add(item);
                    }
                }
                this.listView1.EndUpdate();
            }
        }
        private void storeToFile()
        {
            try
            {
                Stream serializationStream = new FileStream(this.dataFile, FileMode.Create);
                new BinaryFormatter().Serialize(serializationStream, this.infoStorage);
                serializationStream.Close();
            }
            catch (IOException exception1)
            {
                Console.WriteLine(exception1.Message);
            }
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectTabText();
        }
        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            this.SelectTabText();
        }
        private void TxtShowPhone_TextChanged(object sender, EventArgs e)
        {
        }
        private void RadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            Point point = label7.Location;
            string compare = string.Empty;
            foreach (object obj2 in this.radioPanel.Controls)
            {
                RadioButton button = (RadioButton)obj2;
                if (button.Checked)
                {
                    compare = button.Text;
                    if (compare == "일반")
                    {
                        txtCompany.Visible = false;
                        panSchool.Visible = false;
                        label7.Visible = false;
                    }
                    else if (compare == "회사")
                    {
                        label7.Visible = true;
                        txtCompany.Visible = true;
                        panSchool.Visible = false;
                    }
                    else
                    {
                        label7.Visible = false;
                        txtCompany.Visible = false;
                        panSchool.Location = point;
                        panSchool.Visible = true;
                    }
                }
            }
        }
        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.txtShowName.Clear();
            this.txtShowPhone.Clear();
            this.txtShowCompare.Clear();
            this.txtShowEtc.Clear();
            if (ReferenceEquals(listView1.SelectedItems[0].SubItems[0].Text, null))
            {
                MessageBox.Show("해당하는 데이터가 존재하지 않습니다. ");
            }
            else
            {
                this.txtShowName.Text = listView1.SelectedItems[0].SubItems[0].Text;
                this.txtShowPhone.Text = listView1.SelectedItems[0].SubItems[2].Text;
                this.txtShowCompare.Text = listView1.SelectedItems[0].SubItems[1].Text;
                this.txtShowEtc.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
        }
        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }
        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }
        private void 파일저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataFile = openFileDialog1.FileName;
                readFromFile();
                SelectTabText();
            }
        }
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataFile = saveFileDialog1.FileName;
                storeToFile();
            }
        }
        private void 종료ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void TabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl2.SelectedTab.Text.Equals("등록"))
            {
                btnUpdateSearch.Visible = false;
                labelTxt.Text = "등록";
                btnRegister.Visible = true;
                btnUpdate.Visible = false;
                radioPanel.Enabled = true;
            }
            else
            {
                btnUpdateSearch.Visible = true;
                labelTxt.Text = "수정";
                radioPanel.Enabled = false;
                btnRegister.Visible = false;
                btnUpdate.Visible = true;

            }
        }
        private void BtnUpdateSearch_Click(object sender, EventArgs e)
        {
            string text = this.txtName.Text;
            PhoneInfo objA = this.searchName(text);
            if (ReferenceEquals(objA, null))
            {
                MessageBox.Show("해당하는 데이터가 존재하지 않습니다. ");
            }
            else
            {

                this.txtPhoneNum.Text = objA.PhoneNumber;

                //this.txtShowEtc.Text = objA.Etc;
                Point point = label7.Location;
                string compare = objA.Compare;
                if (compare == "일반")
                {
                    radioButton9.Checked = true;
                    txtCompany.Visible = false;
                    panSchool.Visible = false;
                    label7.Visible = false;
                }
                else if (compare == "회사")
                {
                    radioButton8.Checked = true;
                    label7.Visible = true;
                    txtCompany.Visible = true;
                    panSchool.Visible = false;
                    txtCompany.Text = objA.Etc.Replace("회사명 :","");
                }
                else
                {
                    objA.Etc += ",";
                    radioButton7.Checked = true;
                    label7.Visible = false;
                    txtCompany.Visible = false;
                    panSchool.Location = point;
                    panSchool.Visible = true;
                    txtSchool.Text = objA.Etc.Split(',')[0].Replace("학교: ","");
                    txtGrade.Text = objA.Etc.Split(',')[1].Replace(" 학년: ", "");
                }
            }
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == text)
                {
                    listView1.Items[i].Selected = true;
                }
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string text = this.txtName.Text;
            PhoneInfo objA = this.searchName(text);
            if (ReferenceEquals(objA, null))
            {
                return;
            }
            infoStorage.Remove(objA);
            ////////////////////////////////////////////
            string compare = string.Empty;
            foreach (object obj2 in this.radioPanel.Controls)
            {
                RadioButton button = (RadioButton)obj2;
                if (button.Checked)
                {
                    compare = button.Text;
                    if (compare == "일반")
                    {
                        etc = "";
                    }
                    else if (compare == "회사")
                    {
                        etc = "회사명 :" + txtCompany.Text;
                    }
                    else
                    {
                        txtCompany.Visible = false;
                        panSchool.Visible = true;
                        etc = "학교: " + txtSchool.Text + ", 학년: " + txtGrade.Text;
                    }
                }
            }
            this.infoStorage.Add(new PhoneInfo(this.txtName.Text, this.txtPhoneNum.Text, compare, etc));
            MessageBox.Show("수정하였습니다.");
            this.txtName.Clear();
            this.txtPhoneNum.Clear();
            this.radioButton9.Checked = true;
            this.txtCompany.Clear();
            txtSchool.Clear();
            txtGrade.Clear();
            this.SelectTabText();
        }
    }
}