using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMErrorLibrary;

namespace ExchangeListBox
{
    public partial class ExChangeList : ListBox
    {

        public bool IsEasyMemberChangeMode { get; set; }

        public ExChangeList()
        {
            InitializeComponent();
        }

        public bool ExchangeSelectedItem(ListBox listBox)
        {
            if (listBox == null)
            {
                BMError.ErrorMessageOutput("引数にオブジェクト参照が追加されていません");
                return false;
            }

            if (this.SelectedItems.Count == 0 || listBox.SelectedItems.Count == 0) return false;

            if (this.SelectedItems.Count != listBox.SelectedItems.Count)
            {
                BMError.ErrorMessageOutput("選択されているアイテムの個数が違います");
                return false;
            }

            try
            {

                List<object> o1 = new List<object>();
                List<object> o2= new List<object>();

                for (var i = 0; i < this.SelectedItems.Count; i++)
                {
                    listBox.Items.Add(this.SelectedItems[i]);
                    this.Items.Add(listBox.SelectedItems[i]);

                    o1.Add(this.SelectedItems[i]);
                    o2.Add(listBox.SelectedItems[i]);
                }

                foreach (var o in o1)
                {
                    this.Items.Remove(o);
                }

                foreach (var o in o2)
                {
                    listBox.Items.Remove(o);
                }
            }
            catch (Exception exc)
            {
                BMError.ErrorMessageOutput(exc.Message);
                return false;
            }

            return true;
        }

        private void ExChangeList_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsEasyMemberChangeMode)
            {
                return;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // マウス座標から選択すべきアイテムのインデックスを取得
                int index = IndexFromPoint(e.Location);

                // インデックスが取得できたら
                if (index >= 0)
                {
                    // すべての選択状態を解除してから
                    ClearSelected();

                    // アイテムを選択
                    SelectedIndex = index;

                    SelectedItem = Items[index];

                    ClearSelected();
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // マウス座標から選択すべきアイテムのインデックスを取得
                int index = IndexFromPoint(e.Location);

                // インデックスが取得できたら
                if (index >= 0)
                {
                    //クリックされたアイテムが選択されていなかったら
                    if (SelectedItems.IndexOf(Items[index]) < 0)
                    {
                        // アイテムを選択
                        SelectedItems.Add(Items[index]);
                    }
                    else
                    {
                        SelectedItems.Remove(Items[index]);
                    }
                    
                }
            }
        }

        public void PerformIndexClick(int index)
        {
            SelectedIndex = index;

            this.OnClick(null);

            // インデックスが取得できたら
            if (index >= 0)
            {
                // すべての選択状態を解除してから
                ClearSelected();

                // アイテムを選択
                SelectedIndex = index;

                SelectedItem = Items[index];

                ClearSelected();
            }
        }
    }
}
