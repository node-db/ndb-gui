namespace ndb4vs
{
    partial class FormNewItem
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
            this.txtValue = new System.Windows.Forms.TextBox();
            this.labValue = new System.Windows.Forms.Label();
            this.labKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkNode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(57, 53);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(215, 21);
            this.txtValue.TabIndex = 11;
            // 
            // labValue
            // 
            this.labValue.AutoSize = true;
            this.labValue.Location = new System.Drawing.Point(7, 53);
            this.labValue.Name = "labValue";
            this.labValue.Size = new System.Drawing.Size(35, 12);
            this.labValue.TabIndex = 10;
            this.labValue.Text = "Value";
            // 
            // labKey
            // 
            this.labKey.AutoSize = true;
            this.labKey.Location = new System.Drawing.Point(7, 23);
            this.labKey.Name = "labKey";
            this.labKey.Size = new System.Drawing.Size(23, 12);
            this.labKey.TabIndex = 9;
            this.labKey.Text = "Key";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(57, 20);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(215, 21);
            this.txtKey.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(57, 120);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(152, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkNode
            // 
            this.chkNode.AutoSize = true;
            this.chkNode.Location = new System.Drawing.Point(57, 89);
            this.chkNode.Name = "chkNode";
            this.chkNode.Size = new System.Drawing.Size(48, 16);
            this.chkNode.TabIndex = 14;
            this.chkNode.Text = "Node";
            this.chkNode.UseVisualStyleBackColor = true;
            this.chkNode.CheckedChanged += new System.EventHandler(this.chkNode_CheckedChanged);
            // 
            // FormNewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 167);
            this.Controls.Add(this.chkNode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.labValue);
            this.Controls.Add(this.labKey);
            this.Controls.Add(this.txtKey);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewItem";
            this.Text = "New Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label labValue;
        private System.Windows.Forms.Label labKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkNode;
    }
}