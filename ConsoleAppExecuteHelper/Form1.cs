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
        private Process mainProcess { get; set; } = null;
        private IntPtr workingSet { get; set; } = IntPtr.Zero;

        #region 配置文件信息
        private readonly string configFilename = "options.conf";
        private List<string> allOptionList { get; set; } = null;
        private List<string> mainOptionList { get; set; } = null;
        private string processName { get; set; }
        private List<string> saved { get; set; } = null;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region 程序加载模块
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(configFilename) == false)
            {
                MessageBox.Show("找不到配置文件" + configFilename + "！", "无法启动");
                Application.Exit();
                return;
            }
            // 读取数据
            var moduleMap = FileUtil.ReadConfigFile(configFilename);
            allOptionList = moduleMap["OPTIONS"];
            mainOptionList = moduleMap["MAIN_OPTIONS"];
            processName = moduleMap["PROCESS_NAME"][0];

            if (moduleMap.ContainsKey("SAVED"))
                saved = moduleMap["SAVED"];

            mainOptionList.Sort();
            allOptionList.Sort();

            // 增添标题、选项，恢复内容
            AddTitle();
            AddMainOptions();
            AddTotalOptions();
            ResumeSavedContent();
        }

        private void AddTitle()
        {
            this.Text = this.processName + this.Text;
        }

        /// <summary>
        /// 将参数添加到文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddParmToTextBox(object sender, EventArgs e)
        {
            if (this.textBox参数.Text != "")
                this.textBox参数.Text += "\r\n";

            this.textBox参数.Text += ((ToolStripMenuItem)sender).Text;
        }

        private void AddMainOptions()
        {
            foreach (string itemString in this.mainOptionList)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Text = itemString;
                toolStripMenuItem.Click += AddParmToTextBox;
                常用参数ToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
            }
        }

        private void AddTotalOptions()
        {
            foreach (string itemString in this.allOptionList)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Text = itemString;
                toolStripMenuItem.Click += AddParmToTextBox;
                var optionString = itemString.Replace("-", "");
                if (optionString.CompareTo("k") < 0)
                    全部参数ToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                else
                    全部参数ToolStripMenuItem2.DropDownItems.Add(toolStripMenuItem);
            }
        }

        private void ResumeSavedContent()
        {
            if (saved == null)
                return;
            if (saved.Count < 2)
            {
                MessageBox.Show("备份信息读取失败！");
                return;
            }
            this.textBox执行目录.Text = saved[0];
            this.textBox文件名.Text = saved[1];
            saved.RemoveRange(0, 2);
            this.textBox参数.Lines = this.saved.ToArray();
        }
        #endregion

        #region 拖拽模块
        private void textBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// 检测目标程序的根路径
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private string DetectRootPath(string filename)
        {
            if (!filename.ToLower().Contains(this.processName.ToLower()))
                return filename.Substring(0, filename.LastIndexOf("\\"));
            else
                return filename.Substring(0, filename.IndexOf("\\", filename.ToLower().IndexOf(processName.ToLower())));
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

        private void textBox参数_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filePath.Length != 1)
                return;
            this.textBox参数.Text += " ";
            if (this.textBox执行目录.Text.EndsWith("\\"))
                this.textBox执行目录.Text = this.textBox执行目录.Text.Substring(0, this.textBox执行目录.Text.Length - 1);
            filePath[0] = filePath[0].Replace(this.textBox执行目录.Text, ".");
            if (filePath[0].IndexOf(" ") == -1)
                this.textBox参数.Text += filePath[0];
            else
                this.textBox参数.Text += "\"" + filePath[0] + "\"";
        }

        private void textBox执行目录_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filePath.Length != 1)
                return;
            this.textBox执行目录.Text = filePath[0];
        }
        #endregion

        #region 按钮功能
        private void button拷贝_Click(object sender, EventArgs e)
        {
            if (this.SystemCommandStr != null)
                Clipboard.SetText(this.SystemCommandStr);
        }

        private void button运行_Click(object sender, EventArgs e)
        {
            if (mainProcess != null)
                if (mainProcess.HasExited == false)
                    mainProcess.Kill();
            mainProcess = new Process();
            mainProcess.StartInfo.FileName = this.textBox文件名.Text;
            if (this.textBox参数.Text != "")
                mainProcess.StartInfo.Arguments = this.SystemCommandStr.Substring(this.textBox文件名.TextLength + 1);
            mainProcess.StartInfo.WorkingDirectory = this.textBox执行目录.Text;
            mainProcess.Start();
            if (this.workingSet != IntPtr.Zero)
                mainProcess.MaxWorkingSet = this.workingSet;
        }

        private void button结束进程_Click(object sender, EventArgs e)
        {
            if (!this.mainProcess.HasExited)
                mainProcess.Kill();
        }

        private void button保存_Click(object sender, EventArgs e)
        {
            var savingDictionary = new Dictionary<string, List<string>>();

            savingDictionary["OPTIONS"] = this.allOptionList;
            savingDictionary["MAIN_OPTIONS"] = this.mainOptionList;
            savingDictionary["PROCESS_NAME"] = new List<String>(new String[] { this.processName });
            this.saved = new List<string>();
            saved.Add(this.textBox执行目录.Text);
            saved.Add(this.textBox文件名.Text);
            foreach (var line in this.textBox参数.Lines)
                saved.Add(line);
            savingDictionary["SAVED"] = this.saved;
            FileUtil.WriteConfigFile(configFilename, savingDictionary);
            MessageBox.Show("保存成功！");
        }
        #endregion

        #region 菜单栏
        private void 设置内存上限ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maxWorkingSet = InputBoxUtil.Interaction.InputBox("输入最大内存限制(M):", "请输入", hint: "该限制为推荐内存，不能完全强行限制内存占用。", defaultReturn: "");
            if (maxWorkingSet == "")
                return;
            float 兆count = float.Parse(maxWorkingSet);
            int byteCount = (int)(兆count * 1024 * 1024);
            this.workingSet = (IntPtr)(byteCount);
            this.labelMaxWorkingSet.Text = "[最大内存限制：" + 兆count + " M]";
        }
        #endregion
        
        private string SystemCommandStr
        {
            get
            {
                string result = this.textBox文件名.Text;
                foreach (string 参数 in this.textBox参数.Lines)
                    result += " " + 参数;
                return result;
            }
        }
    }
}
