using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ndb4vs
{
    public partial class FormNewItem : Form
    {
        private TreeView treeView;

        public FormNewItem(TreeView treeView)
        {
            InitializeComponent();

            this.treeView = treeView;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!txtKey.Text.Trim().Equals(""))
            {
                if (chkNode.Checked)
                {
                    treeView.SelectedNode.Nodes.Add(txtKey.Text);
                }
                else
                {
                    if (!txtValue.Text.Trim().Equals(""))
                    {
                        treeView.SelectedNode.Nodes.Add(txtKey.Text + ":" + txtValue.Text);
                    }
                }
            }
            this.Close();
        }

        private void chkNode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNode.Checked)
            {
                txtValue.Text = "";
                txtValue.Enabled = false;
            }
            else
            {
                txtValue.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
