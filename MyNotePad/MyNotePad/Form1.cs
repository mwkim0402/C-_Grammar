using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace MyNotePad
{
    public partial class Form1 : Form
    {
        bool dirty = false;
        string editingFileName = string.Empty;
        string notDirthCaptionFormat = "{0} - Windows 메모장";
        string dirthCaptionFormat = "*{0} - Windows 메모장";
        public Form1()
        {
            InitializeComponent();
        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtArea.Clear();
            dirty = false;
            editingFileName = string.Empty;
            UpdateFormText();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                editingFileName = openFileDialog1.FileName;
                this.txtArea.TextChanged -= new System.EventHandler(this.TxtArea_TextChanged);
                try
                {
                    StreamReader sr = new StreamReader(editingFileName, Encoding.Default);
                    txtArea.Text = sr.ReadToEnd();
                    sr.Close();

                    dirty = false;
                    UpdateFormText();
                }
                catch (IOException err)
                {
                    MessageBox.Show(err.Message);
                }
                finally
                {
                    this.txtArea.TextChanged += new System.EventHandler(this.TxtArea_TextChanged);
                }
            }
        }

        //저장 다이얼로그
        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //새로만들고 나서 처음 저장
            if (editingFileName.Length < 1)
            {
                SaveAs();
            }
            else
            {
                FileStream fs;
                try
                {
                    if (File.Exists(editingFileName))
                    {
                        fs = new FileStream(editingFileName, FileMode.Open);
                    }
                    else
                    {
                        fs = new FileStream(editingFileName, FileMode.Create);
                    }
                    fs.Close();
                    StreamWriter sw = new StreamWriter(editingFileName, false, Encoding.Default);
                    sw.Write(txtArea.Text);
                    sw.Close();
                }
                catch (IOException err)
                {
                    MessageBox.Show(err.Message);
                }
                finally
                {
                    dirty = false;
                    UpdateFormText();
                }
            }

        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TxtArea_TextChanged(object sender, EventArgs e)
        {
            if (!dirty)
            {
                dirty = true;
                UpdateFormText();
            }
        }
        private void SaveAs()
        {
            //*.txt , *.* 와 같은경우 정확히 붙여서 써야함. 안그러면 필터링 X
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                editingFileName = saveFileDialog1.FileName;
                FileStream fs = new FileStream(editingFileName, FileMode.Create);
                fs.Close();
                StreamWriter sw = new StreamWriter(editingFileName, false, Encoding.Default);
                sw.Write(txtArea.Text);
                sw.Close();

                dirty = false;
                UpdateFormText();
            }
        }
        private void UpdateFormText()
        {
            string filename = string.Empty;
            if (editingFileName.Length > 1)
            {
                filename = editingFileName.Substring(editingFileName.LastIndexOf('\\') + 1);
            }
            else
            {
                filename = "제목없음";
            }
            if (dirty)
            {
                this.Text = string.Format(dirthCaptionFormat, filename);
            }
            else
            {
                this.Text = string.Format(notDirthCaptionFormat, filename);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //새로만들기 버튼을 클릭한거처럼 실행
            새로만들기ToolStripMenuItem.PerformClick();
        }
    }
}
