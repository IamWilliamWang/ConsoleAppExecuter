using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleAppExecuteHelper
{
    public partial class Form1 : Form
    {
        private Process mainProcess = null;
        private IntPtr workingSet = IntPtr.Zero;

        private string CommandStr { get {
                string result = this.textBox文件名.Text;
                foreach (string 参数 in this.textBox参数.Lines)
                    result += " " + 参数;
                return result;
            } }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string configFilename = "options.conf";
            if (File.Exists(configFilename) == false)
            {
                MessageBox.Show("找不到配置文件" + configFilename + "！", "无法启动");
                Application.Exit();
            }

            List<string> allStrings = File.ReadAllLines(configFilename).ToList();
            string title = ""; //2
            List<string> mainList = new List<string>();//1
            List<string> allList = new List<string>();//0
            int insertFlag = 0;
            foreach(string line in allStrings)
            {
                if(line == "#####MAIN_OPTIONS#####")
                    insertFlag = 1;
                else if(line == "#####PROCESS_NAME#####")
                    insertFlag = 2;
                else
                {
                    switch(insertFlag)
                    {
                        case 0:
                            allList.Add(line);
                            break;
                        case 1:
                            mainList.Add(line);
                            break;
                        case 2:
                            title = line;
                            break;
                        default:
                            throw new Exception("发生未知错误");
                    }
                }
            }
            mainList.Sort();
            allList.Sort();

            AddTitle(title);
            AddMainOptions(mainList);
            AddTotalOptions(allList);
        }

        private void AddTitle(string title)
        {
            this.Text = title + this.Text;
        }

        private void AddMainOptions(List<string> mainOptions)
        {
            foreach (string itemString in mainOptions)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Text = itemString.Replace("-", "");
                toolStripMenuItem.Click += AddParm;
                常用参数ToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
            }
        }

        private void AddTotalOptions(List<string> totalOptions)
        {
            foreach (string itemString in totalOptions)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Text = itemString.Replace("-", "");
                toolStripMenuItem.Click += AddParm;
                if (toolStripMenuItem.Text.CompareTo("--k") < 0)
                    全部参数ToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                else
                    全部参数ToolStripMenuItem2.DropDownItems.Add(toolStripMenuItem);
            }
        }

        private void textBox文件名_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox文件名_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            this.textBox文件名.Text = filePath[0];
            this.textBox执行目录.Text = DetectRootPath(filePath[0]);
            
            this.textBox执行目录.Focus();
            this.textBox执行目录.Select(this.textBox文件名.TextLength, 0);
            this.textBox执行目录.ScrollToCaret();
            this.textBox文件名.Focus();
            this.textBox文件名.Select(this.textBox文件名.TextLength, 0);
            this.textBox文件名.ScrollToCaret();
        }

        private string DetectRootPath(string filename)
        {
            if (filename.IndexOf("openpose") == -1)
                return filename.Substring(0,filename.LastIndexOf("\\"));
            else
                return filename.Substring(0, filename.IndexOf("\\", filename.IndexOf("openpose")));
        }

        private void button拷贝_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.CommandStr);
        }

        private void button运行_Click(object sender, EventArgs e)
        {
            if (mainProcess != null)
            {
                if (mainProcess.HasExited == false)
                    mainProcess.Kill();
            }
            mainProcess = new Process();
            mainProcess.StartInfo.FileName = this.textBox文件名.Text;
            if (this.textBox参数.Text != "")
                mainProcess.StartInfo.Arguments = this.CommandStr.Substring(this.textBox文件名.TextLength + 1);
            mainProcess.StartInfo.WorkingDirectory = this.textBox执行目录.Text;
            mainProcess.Start();
            if (this.workingSet != IntPtr.Zero)
                mainProcess.MaxWorkingSet = this.workingSet;
            
        }

        public void AddParm(object sender, EventArgs e)
        {
            if (this.textBox参数.Text != "")
                this.textBox参数.Text += "\r\n";

            this.textBox参数.Text += "--" + ((ToolStripMenuItem)sender).Text;
        }

        private void button清空_Click(object sender, EventArgs e)
        {
            this.textBox参数.Text = "";
        }

        private void textBox参数_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filePath.Length != 1)
                return;
            this.textBox参数.Text += " ";
            if (this.textBox执行目录.Text.EndsWith("\\"))
                this.textBox执行目录.Text = this.textBox执行目录.Text.Substring(0, this.textBox执行目录.Text.Length - 1);
            filePath[0] = filePath[0].Replace(this.textBox执行目录.Text, ".");
            if(filePath[0].IndexOf(" ") == -1)
            	this.textBox参数.Text += filePath[0];
            else
            	this.textBox参数.Text += "\"" + filePath[0] + "\"";
        }

        private void button结束进程_Click(object sender, EventArgs e)
        {
            if(!this.mainProcess.HasExited)
                mainProcess.Kill();
        }

        private void 设置内存上限ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maxWorkingSet = Microsoft.VisualBasic.Interaction.InputBox("输入最大内存限制(M):","请输入");
            if (maxWorkingSet == "")
                return;
            float 兆count = float.Parse(maxWorkingSet);
            int byteCount = (int)(兆count * 1024 * 1024);
            this.workingSet = (IntPtr)(byteCount);
            this.labelMaxWorkingSet.Text = "[最大内存限制：" + 兆count + " M]";
        }
    }
}
