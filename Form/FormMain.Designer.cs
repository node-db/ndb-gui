namespace ndb4vs
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openNodeFile = new System.Windows.Forms.OpenFileDialog();
            this.treeNodeInfo = new System.Windows.Forms.TreeView();
            this.mnuTreeNodeContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.labKey = new System.Windows.Forms.Label();
            this.labValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.saveNodeFile = new System.Windows.Forms.SaveFileDialog();
            this.labSearch = new System.Windows.Forms.Label();
            this.txtExecute = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.chkExpandAll = new System.Windows.Forms.CheckBox();
            this.labOperate = new System.Windows.Forms.Label();
            this.combOperate = new System.Windows.Forms.ComboBox();
            this.mnuTreeNodeContext.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeNodeInfo
            // 
            this.treeNodeInfo.ContextMenuStrip = this.mnuTreeNodeContext;
            this.treeNodeInfo.Location = new System.Drawing.Point(0, 28);
            this.treeNodeInfo.Name = "treeNodeInfo";
            this.treeNodeInfo.Size = new System.Drawing.Size(420, 364);
            this.treeNodeInfo.TabIndex = 2;
            this.treeNodeInfo.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeNodeInfo_AfterSelect);
            this.treeNodeInfo.DoubleClick += new System.EventHandler(this.treeNodeInfo_DoubleClick);
            // 
            // mnuTreeNodeContext
            // 
            this.mnuTreeNodeContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddItem,
            this.mnuRemoveItem});
            this.mnuTreeNodeContext.Name = "mnuTreeNodeContext";
            this.mnuTreeNodeContext.Size = new System.Drawing.Size(124, 48);
            this.mnuTreeNodeContext.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTreeNodeContext_Opening);
            // 
            // mnuAddItem
            // 
            this.mnuAddItem.Name = "mnuAddItem";
            this.mnuAddItem.Size = new System.Drawing.Size(123, 22);
            this.mnuAddItem.Text = "Add";
            this.mnuAddItem.Click += new System.EventHandler(this.mnuAddItem_Click);
            // 
            // mnuRemoveItem
            // 
            this.mnuRemoveItem.Name = "mnuRemoveItem";
            this.mnuRemoveItem.Size = new System.Drawing.Size(123, 22);
            this.mnuRemoveItem.Text = "Remove";
            this.mnuRemoveItem.Click += new System.EventHandler(this.mnuRemoveItem_Click);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(732, 25);
            this.mnuMain.TabIndex = 3;
            this.mnuMain.Text = "menuBar";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuSave,
            this.toolStripSeparator1,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(108, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(108, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(105, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(108, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(492, 190);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(215, 21);
            this.txtKey.TabIndex = 4;
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // labKey
            // 
            this.labKey.AutoSize = true;
            this.labKey.Location = new System.Drawing.Point(442, 193);
            this.labKey.Name = "labKey";
            this.labKey.Size = new System.Drawing.Size(23, 12);
            this.labKey.TabIndex = 5;
            this.labKey.Text = "Key";
            // 
            // labValue
            // 
            this.labValue.AutoSize = true;
            this.labValue.Location = new System.Drawing.Point(442, 223);
            this.labValue.Name = "labValue";
            this.labValue.Size = new System.Drawing.Size(35, 12);
            this.labValue.TabIndex = 6;
            this.labValue.Text = "Value";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(492, 223);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(215, 21);
            this.txtValue.TabIndex = 7;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // labSearch
            // 
            this.labSearch.AutoSize = true;
            this.labSearch.Location = new System.Drawing.Point(442, 67);
            this.labSearch.Name = "labSearch";
            this.labSearch.Size = new System.Drawing.Size(35, 12);
            this.labSearch.TabIndex = 8;
            this.labSearch.Text = "N-SQL";
            // 
            // txtExecute
            // 
            this.txtExecute.Location = new System.Drawing.Point(492, 67);
            this.txtExecute.Multiline = true;
            this.txtExecute.Name = "txtExecute";
            this.txtExecute.Size = new System.Drawing.Size(215, 51);
            this.txtExecute.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(632, 135);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Execute";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(543, 135);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 11;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // chkExpandAll
            // 
            this.chkExpandAll.AutoSize = true;
            this.chkExpandAll.Location = new System.Drawing.Point(444, 269);
            this.chkExpandAll.Name = "chkExpandAll";
            this.chkExpandAll.Size = new System.Drawing.Size(84, 16);
            this.chkExpandAll.TabIndex = 12;
            this.chkExpandAll.Text = "Expand All";
            this.chkExpandAll.UseVisualStyleBackColor = true;
            this.chkExpandAll.CheckedChanged += new System.EventHandler(this.chkExpandAll_CheckedChanged);
            // 
            // labOperate
            // 
            this.labOperate.AutoSize = true;
            this.labOperate.Location = new System.Drawing.Point(442, 34);
            this.labOperate.Name = "labOperate";
            this.labOperate.Size = new System.Drawing.Size(47, 12);
            this.labOperate.TabIndex = 13;
            this.labOperate.Text = "Operate";
            // 
            // combOperate
            // 
            this.combOperate.FormattingEnabled = true;
            this.combOperate.Items.AddRange(new object[] {
            "select",
            "update",
            "delete",
            "insert",
            "clean"});
            this.combOperate.Location = new System.Drawing.Point(494, 34);
            this.combOperate.Name = "combOperate";
            this.combOperate.Size = new System.Drawing.Size(121, 20);
            this.combOperate.TabIndex = 14;
            this.combOperate.Text = "select";
            this.combOperate.SelectedIndexChanged += new System.EventHandler(this.combOperate_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 412);
            this.Controls.Add(this.combOperate);
            this.Controls.Add(this.labOperate);
            this.Controls.Add(this.chkExpandAll);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtExecute);
            this.Controls.Add(this.labSearch);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.labValue);
            this.Controls.Add(this.labKey);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.treeNodeInfo);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "NodeDB Tools";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.mnuTreeNodeContext.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openNodeFile;
        private System.Windows.Forms.TreeView treeNodeInfo;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label labKey;
        private System.Windows.Forms.Label labValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ContextMenuStrip mnuTreeNodeContext;
        private System.Windows.Forms.ToolStripMenuItem mnuAddItem;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SaveFileDialog saveNodeFile;
        private System.Windows.Forms.Label labSearch;
        private System.Windows.Forms.TextBox txtExecute;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.CheckBox chkExpandAll;
        private System.Windows.Forms.Label labOperate;
        private System.Windows.Forms.ComboBox combOperate;
    }
}