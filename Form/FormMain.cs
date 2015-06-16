using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ndb4vs
{
    public partial class FormMain : Form
    {

        private Statement statement = new Statement();

        public FormMain()
        {
            InitializeComponent();
        }

        private TreeNode BuildTree(string title, Dictionary<string, object> nodeInfo)
        {
            TreeNode node = new TreeNode();
            node.Text = title;

            foreach(string key in nodeInfo.Keys)
            {
                object value = nodeInfo[key];
                if (value != null)
                {
                    if (value is Dictionary<string, object>)
                    {
                        node.Nodes.Add(BuildTree(key, (Dictionary<string, object>)value));
                    }
                    else if (value is List<object>)
                    {
                        List<object> list = (List<object>)value;

                        foreach (object item in list)
                        {
                            if (item is Dictionary<string, object>)
                            {
                                node.Nodes.Add(BuildTree(key, (Dictionary<string, object>)item));
                            }
                            else
                            {
                                TreeNode textNode = new TreeNode();
                                textNode.Text = key + ":" + value.ToString();
                                node.Nodes.Add(textNode);
                            }
                        }
                    }
                    else
                    {
                        TreeNode textNode = new TreeNode();
                        textNode.Text = key + ":" + value.ToString();
                        node.Nodes.Add(textNode);
                    }
                }
            }

            return node;
            
        }

        private void treeNodeInfo_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = treeNodeInfo.SelectedNode;
            
        }

        private void treeNodeInfo_AfterSelect(object sender, TreeViewEventArgs e)
        {

            TreeNode node = treeNodeInfo.SelectedNode;

            if (node.Parent == null)
            {
                return;
            }
            else
            {
                string filename = openNodeFile.FileName;
                string path = node.FullPath;
                if (path.StartsWith(filename))
                {
                    path = path.Substring(filename.Length + 1);
                }
                else if (path.StartsWith("result"))
                {
                    path = path.Substring("result".Length + 1);
                }
                path = path.Replace("\\", "->");
                txtExecute.Text = "select:" + path;
            }

            if (node.Text.IndexOf(":") > 0)
            {
                txtValue.Enabled = true;

                string line = node.Text;
                int splitSym = line.IndexOf(":");
                txtKey.Text = line.Substring(0, splitSym).Trim();
                txtValue.Text = line.Substring(splitSym + 1, line.Length - splitSym - 1);
            }
            else
            {
                txtValue.Enabled = false;

                txtKey.Text = node.Text;
                txtValue.Text = "";
                
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            openNodeFile.ShowDialog();
            string filename = openNodeFile.FileName;

            if (filename != null && !filename.Trim().Equals(""))
            {
                treeNodeInfo.Nodes.Clear();

                Dictionary<string, object> nodeInfo = statement.Read(filename);
                TreeNode node = BuildTree(filename, nodeInfo);
                treeNodeInfo.Nodes.Add(node);

            }

            ExpandAll();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            TreeNode node = treeNodeInfo.SelectedNode;
            if (txtValue.Enabled == true)
            {
                node.Text = txtKey.Text + ":" + txtValue.Text;
            }
            else
            {
                node.Text = txtKey.Text;
            }
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            TreeNode node = treeNodeInfo.SelectedNode;
            if (txtValue.Enabled == true)
            {
                node.Text = txtKey.Text + ":" + txtValue.Text;
            }
            else
            {
                node.Text = txtKey.Text;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            treeNodeInfo.Height = this.Height - mnuMain.Height - 41;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            treeNodeInfo.Height = this.Height - mnuMain.Height - 20;
        }

        private void mnuTreeNodeContext_Opening(object sender, CancelEventArgs e)
        {
            TreeNode node = treeNodeInfo.SelectedNode;
            if (node == null)
            {
                mnuAddItem.Enabled = false;
                mnuRemoveItem.Enabled = false;
            }
            else
            {
                mnuAddItem.Enabled = true;
                mnuRemoveItem.Enabled = true;
            }
        }

        private void mnuAddItem_Click(object sender, EventArgs e)
        {
            FormNewItem frmNewItem = new FormNewItem(treeNodeInfo);
            frmNewItem.Show();
        }

        private void mnuRemoveItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeNodeInfo.SelectedNode;
            node.Remove();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            saveNodeFile.ShowDialog();
            string filename = saveNodeFile.FileName;

            if (!filename.Trim().Equals(""))
            {
                Dictionary<string, object> ndb = ReadTree(treeNodeInfo.Nodes);
                foreach (string filepath in ndb.Keys)
                {
                    object node = ndb[filepath];

                    if (node is Dictionary<string, object>)
                    {
                        Dictionary<string, object> nodeInfo = (Dictionary<string, object>)node;
                        foreach (string rootNodeName in nodeInfo.Keys)
                        {
                            if (nodeInfo[rootNodeName] is Dictionary<string, object>)
                            {
                                statement.Write(filename, rootNodeName, (Dictionary<string, object>)nodeInfo[rootNodeName]);
                            }
                        }
                    }
                }
            }
        }

        private Dictionary<string, object> ReadTree(TreeNodeCollection treeNodes)
        {
            Dictionary<string, object> nodeInfo = new Dictionary<string, object>();

            foreach (TreeNode treeNode in treeNodes)
            {
                if (treeNode.Nodes.Count > 0)
                {
                    string title = treeNode.Text;
                    Dictionary<string, object> nodeValue = ReadTree(treeNode.Nodes);


                    if (nodeInfo.ContainsKey(title))
                    {
                        object itemValue = nodeInfo[title];
                        List<object> itemValueList = new List<object>();

                        if (itemValue is List<object>)
                        {
                            ((List<object>)itemValue).Add(nodeValue);

                            nodeInfo.Remove(title);
                            nodeInfo.Add(title, itemValue);
                        }
                        else
                        {
                            itemValueList.Add(itemValue);
                            itemValueList.Add(nodeValue);

                            nodeInfo.Remove(title);
                            nodeInfo.Add(title, itemValueList);
                        }
                    }
                    else
                    {
                        nodeInfo.Add(title, nodeValue);
                    }
                }
                else
                {
                    string line = treeNode.Text;
                    int splitSym = line.IndexOf(":");
                    if (splitSym > 0)
                    {
                        string key = line.Substring(0, splitSym).Trim();
                        string value = line.Substring(splitSym + 1, line.Length - splitSym - 1);

                        if (nodeInfo.ContainsKey(key))
                        {
                            object itemValue = nodeInfo[key];
                            List<object> itemValueList = new List<object>();

                            if (itemValue is List<object>)
                            {
                                ((List<object>)itemValue).Add(value);

                                nodeInfo.Remove(key);
                                nodeInfo.Add(key, itemValue);
                            }
                            else
                            {
                                itemValueList.Add(itemValue);
                                itemValueList.Add(value);

                                nodeInfo.Remove(key);
                                nodeInfo.Add(key, itemValueList);
                            }
                        }
                        else
                        {
                            nodeInfo.Add(key, value);
                        }
                    }
                }
            }

            return nodeInfo;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> ndb = ReadTree(treeNodeInfo.Nodes);
            foreach (string filepath in ndb.Keys)
            {
                object node = ndb[filepath];

                if (node is Dictionary<string, object>)
                {
                    object result = statement.Execute((Dictionary<string, object>)node, txtExecute.Text);

                    if (result is List<object>)
                    {
                        List<object> list = (List<object>)result;
                        TreeNode[] treeNodes = new TreeNode[list.Count];

                        for (int i = 0; i < list.Count; i++ )
                        {
                            object item = list[i];
                            if (item is Dictionary<string, object>)
                            {
                                TreeNode treeNode = BuildTree("result", (Dictionary<string, object>)item);
                                treeNodes[i] = treeNode;
                            }
                        }
                        treeNodeInfo.Nodes.Clear();
                        treeNodeInfo.Nodes.AddRange(treeNodes);

                    }
                    else if (result is Dictionary<string, object>)
                    {
                        TreeNode treeNode = BuildTree("result", (Dictionary<string, object>)result);
                        treeNodeInfo.Nodes.Clear();
                        treeNodeInfo.Nodes.Add(treeNode);
                    }
                    
                }
            }

            ExpandAll();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定重载配置：" + openNodeFile.FileName, "配置重载", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                string filename = openNodeFile.FileName;

                if (filename != null && !filename.Trim().Equals(""))
                {
                    treeNodeInfo.Nodes.Clear();

                    Dictionary<string, object> nodeInfo = statement.Read(filename);
                    TreeNode node = BuildTree(filename, nodeInfo);
                    treeNodeInfo.Nodes.Add(node);

                }

                txtExecute.Text = "";

                ExpandAll();
            }
        }

        private void chkExpandAll_CheckedChanged(object sender, EventArgs e)
        {
            ExpandAll();
        }

        private void ExpandAll()
        {
            if (chkExpandAll.Checked)
            {
                treeNodeInfo.ExpandAll();
            }
            else
            {
                treeNodeInfo.CollapseAll();
            }
        }

        private void combOperate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nsql = txtExecute.Text;
            if (nsql.IndexOf(":") > 0)
            {
                string path = nsql.Substring(nsql.IndexOf(":") + 1);
                txtExecute.Text = combOperate.Text + ":" + path;
            }
            if (combOperate.Text.Equals("clean", StringComparison.OrdinalIgnoreCase))
            {
                txtExecute.Text = "clean";
            }
        }
    }
}
