namespace ConsoleAppExecuteHelper
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.常用参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部参数ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.设置内存上限ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox文件名 = new System.Windows.Forms.TextBox();
            this.label可执行文件 = new System.Windows.Forms.Label();
            this.groupBox参数列表 = new System.Windows.Forms.GroupBox();
            this.textBox参数 = new System.Windows.Forms.TextBox();
            this.button拷贝 = new System.Windows.Forms.Button();
            this.button运行 = new System.Windows.Forms.Button();
            this.button清空 = new System.Windows.Forms.Button();
            this.label执行目录 = new System.Windows.Forms.Label();
            this.textBox执行目录 = new System.Windows.Forms.TextBox();
            this.button结束进程 = new System.Windows.Forms.Button();
            this.labelMaxWorkingSet = new System.Windows.Forms.Label();
            this.menuStripMain.SuspendLayout();
            this.groupBox参数列表.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.常用参数ToolStripMenuItem,
            this.全部参数ToolStripMenuItem,
            this.全部参数ToolStripMenuItem2,
            this.设置内存上限ToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(684, 25);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // 常用参数ToolStripMenuItem
            // 
            this.常用参数ToolStripMenuItem.Name = "常用参数ToolStripMenuItem";
            this.常用参数ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.常用参数ToolStripMenuItem.Text = "常用参数";
            // 
            // 全部参数ToolStripMenuItem
            // 
            this.全部参数ToolStripMenuItem.Name = "全部参数ToolStripMenuItem";
            this.全部参数ToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.全部参数ToolStripMenuItem.Text = "全部参数a-j";
            // 
            // 全部参数ToolStripMenuItem2
            // 
            this.全部参数ToolStripMenuItem2.Name = "全部参数ToolStripMenuItem2";
            this.全部参数ToolStripMenuItem2.Size = new System.Drawing.Size(86, 21);
            this.全部参数ToolStripMenuItem2.Text = "全部参数k-z";
            // 
            // 设置内存上限ToolStripMenuItem
            // 
            this.设置内存上限ToolStripMenuItem.Name = "设置内存上限ToolStripMenuItem";
            this.设置内存上限ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.设置内存上限ToolStripMenuItem.Text = "推荐内存上限";
            this.设置内存上限ToolStripMenuItem.Click += new System.EventHandler(this.设置内存上限ToolStripMenuItem_Click);
            // 
            // textBox文件名
            // 
            this.textBox文件名.AllowDrop = true;
            this.textBox文件名.Location = new System.Drawing.Point(90, 51);
            this.textBox文件名.Name = "textBox文件名";
            this.textBox文件名.Size = new System.Drawing.Size(334, 21);
            this.textBox文件名.TabIndex = 1;
            this.textBox文件名.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox文件名_DragDrop);
            this.textBox文件名.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox文件名_DragEnter);
            // 
            // label可执行文件
            // 
            this.label可执行文件.AutoSize = true;
            this.label可执行文件.Location = new System.Drawing.Point(12, 54);
            this.label可执行文件.Name = "label可执行文件";
            this.label可执行文件.Size = new System.Drawing.Size(77, 12);
            this.label可执行文件.TabIndex = 2;
            this.label可执行文件.Text = "可执行文件：";
            // 
            // groupBox参数列表
            // 
            this.groupBox参数列表.Controls.Add(this.textBox参数);
            this.groupBox参数列表.Font = new System.Drawing.Font("宋体", 8F);
            this.groupBox参数列表.Location = new System.Drawing.Point(14, 78);
            this.groupBox参数列表.Name = "groupBox参数列表";
            this.groupBox参数列表.Size = new System.Drawing.Size(658, 363);
            this.groupBox参数列表.TabIndex = 3;
            this.groupBox参数列表.TabStop = false;
            this.groupBox参数列表.Text = "参数列表";
            // 
            // textBox参数
            // 
            this.textBox参数.AllowDrop = true;
            this.textBox参数.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox参数.Location = new System.Drawing.Point(7, 11);
            this.textBox参数.Multiline = true;
            this.textBox参数.Name = "textBox参数";
            this.textBox参数.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox参数.Size = new System.Drawing.Size(651, 346);
            this.textBox参数.TabIndex = 0;
            this.textBox参数.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox参数_DragDrop);
            this.textBox参数.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox文件名_DragEnter);
            // 
            // button拷贝
            // 
            this.button拷贝.Location = new System.Drawing.Point(430, 30);
            this.button拷贝.Name = "button拷贝";
            this.button拷贝.Size = new System.Drawing.Size(59, 36);
            this.button拷贝.TabIndex = 4;
            this.button拷贝.Text = "拷贝至剪切板";
            this.button拷贝.UseVisualStyleBackColor = true;
            this.button拷贝.Click += new System.EventHandler(this.button拷贝_Click);
            // 
            // button运行
            // 
            this.button运行.Location = new System.Drawing.Point(491, 30);
            this.button运行.Name = "button运行";
            this.button运行.Size = new System.Drawing.Size(63, 36);
            this.button运行.TabIndex = 5;
            this.button运行.Text = "开启进程";
            this.button运行.UseVisualStyleBackColor = true;
            this.button运行.Click += new System.EventHandler(this.button运行_Click);
            // 
            // button清空
            // 
            this.button清空.Location = new System.Drawing.Point(624, 30);
            this.button清空.Name = "button清空";
            this.button清空.Size = new System.Drawing.Size(48, 36);
            this.button清空.TabIndex = 6;
            this.button清空.Text = "清空";
            this.button清空.UseVisualStyleBackColor = true;
            this.button清空.Click += new System.EventHandler(this.button清空_Click);
            // 
            // label执行目录
            // 
            this.label执行目录.AutoSize = true;
            this.label执行目录.Location = new System.Drawing.Point(18, 34);
            this.label执行目录.Name = "label执行目录";
            this.label执行目录.Size = new System.Drawing.Size(65, 12);
            this.label执行目录.TabIndex = 7;
            this.label执行目录.Text = "执行目录：";
            // 
            // textBox执行目录
            // 
            this.textBox执行目录.Location = new System.Drawing.Point(90, 30);
            this.textBox执行目录.Name = "textBox执行目录";
            this.textBox执行目录.Size = new System.Drawing.Size(334, 21);
            this.textBox执行目录.TabIndex = 8;
            // 
            // button结束进程
            // 
            this.button结束进程.Location = new System.Drawing.Point(558, 30);
            this.button结束进程.Name = "button结束进程";
            this.button结束进程.Size = new System.Drawing.Size(61, 36);
            this.button结束进程.TabIndex = 9;
            this.button结束进程.Text = "结束进程";
            this.button结束进程.UseVisualStyleBackColor = true;
            this.button结束进程.Click += new System.EventHandler(this.button结束进程_Click);
            // 
            // labelMaxWorkingSet
            // 
            this.labelMaxWorkingSet.AutoSize = true;
            this.labelMaxWorkingSet.Location = new System.Drawing.Point(340, 7);
            this.labelMaxWorkingSet.Name = "labelMaxWorkingSet";
            this.labelMaxWorkingSet.Size = new System.Drawing.Size(0, 12);
            this.labelMaxWorkingSet.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 449);
            this.Controls.Add(this.labelMaxWorkingSet);
            this.Controls.Add(this.button结束进程);
            this.Controls.Add(this.textBox执行目录);
            this.Controls.Add(this.label执行目录);
            this.Controls.Add(this.button清空);
            this.Controls.Add(this.button运行);
            this.Controls.Add(this.button拷贝);
            this.Controls.Add(this.groupBox参数列表);
            this.Controls.Add(this.label可执行文件);
            this.Controls.Add(this.textBox文件名);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "进程管理";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.groupBox参数列表.ResumeLayout(false);
            this.groupBox参数列表.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem 常用参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部参数ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox文件名;
        private System.Windows.Forms.Label label可执行文件;
        private System.Windows.Forms.GroupBox groupBox参数列表;
        private System.Windows.Forms.TextBox textBox参数;
        private System.Windows.Forms.Button button拷贝;
        private System.Windows.Forms.Button button运行;
        private System.Windows.Forms.ToolStripMenuItem 全部参数ToolStripMenuItem2;
        private System.Windows.Forms.Button button清空;
        private System.Windows.Forms.Label label执行目录;
        private System.Windows.Forms.TextBox textBox执行目录;
        private System.Windows.Forms.Button button结束进程;
        private System.Windows.Forms.Label labelMaxWorkingSet;
        private System.Windows.Forms.ToolStripMenuItem 设置内存上限ToolStripMenuItem;
    }
}

