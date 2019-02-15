using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastRegsvrWinForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Cmd.SelectedIndex = 0;
            RefreshItem();
        }
        public void RefreshItem()
        {
            Copy.Checked=(string)AppRegedit.Get("CopyToSys","False")=="True"?true:false;
            RegList.Items.Clear();
            UnRegList.Items.Clear();
            RegList.Items.AddRange(AppRegedit.GetRegItem().ToArray());
            UnRegList.Items.AddRange(AppRegedit.GetUnRegItem().ToArray());
        }

        private void button_Click(object sender, EventArgs e)
        {

        }

        private void Copy_CheckedChanged(object sender, EventArgs e)
        {
 
        }

        private void Copy_CheckedChanged_1(object sender, EventArgs e)
        {
           AppRegedit.Set("CopyToSys", Copy.Checked);
        }

        private void button_Click_1(object sender, EventArgs e)
        {

            List<string> Lines = new List<string>();
            string Name;
            switch (Cmd.SelectedIndex)
            {
                case 0://反注册   
                    foreach(string Item in RegList.CheckedItems)
                    {
                       if(Regsvr.UnRegLib(AppRegedit.GetRegPath(Item),out Name)>=0)
                          Lines.Add(Name + "反注册成功，文件位于"+ AppRegedit.GetRegPath(Item));
                       else
                          Lines.Add(Name + "反注册失败，文件位于"+ AppRegedit.GetRegPath(Item));
              
                    }
                    break;

                case 1://反注册并删除
                    DialogResult result = MessageBox.Show("确定要反注册并删除选中的文件吗？" + Environment.NewLine + "该操作不可逆。", "警告", MessageBoxButtons.YesNo);
                    if(result==DialogResult.Yes)
                    {
                        foreach (string Item in RegList.CheckedItems)
                        {
                            if(Regsvr.UnRegLib(AppRegedit.GetRegPath(Item), out Name)>=0)
                            {
                                Regsvr.DeleteRegLib(AppRegedit.GetRegPath(Item));
                                Lines.Add(Name + "成功反注册并删除");
                            }
                            else
                            {
                                Lines.Add(Name + "反注册失败，文件位于"+ AppRegedit.GetRegPath(Item));
                            }
                        }
                    }
                    break;
            }
            Form1 form = new Form1(Lines);
            form.ShowDialog();
            RefreshItem();
        }

        private void RegBtn_Click(object sender, EventArgs e)
        {
            List<string> Lines = new List<string>();
            string Name, LibPath;
            foreach (string Item in UnRegList.CheckedItems)
            {
                if (Regsvr.RegLib(AppRegedit.GetRegPath(Item), out Name,out LibPath) >= 0)
                    Lines.Add(Name + "注册成功于" + LibPath);
                else
                    Lines.Add(Name + "注册失败，文件位于"+ AppRegedit.GetRegPath(Item));

            }
            Form1 form = new Form1(Lines);
            form.ShowDialog();
            RefreshItem();
        }

        private void RegList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RegList_DragDrop(object sender, DragEventArgs e)
        {
            string[] drops = (string[])e.Data.GetData(DataFormats.FileDrop);
        }

        private void RegList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void RegList_MouseHover(object sender, MouseEventArgs e)
        {
 
        }

        private void RegList_MouseClick(object sender, MouseEventArgs e)
        {
            Label.Text = RegList.SelectedItem == null ? " " : "位于 " + AppRegedit.GetRegPath(RegList.SelectedItem.ToString());
        }

        private void UnRegList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label.Text = UnRegList.SelectedItem == null ? " " : "位于 " + AppRegedit.GetRegPath(UnRegList.SelectedItem.ToString());
        }

        private void UnRegList_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label.Text = "";
        }
    }
}
