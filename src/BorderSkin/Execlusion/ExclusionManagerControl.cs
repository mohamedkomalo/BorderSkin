using System;
using System.ComponentModel;
using System.Windows.Forms;
using BorderSkin.Language;

namespace BorderSkin.Execlusion
{
    partial class ExclusionManagerControl
    {


        public bool _IsInclusion = false;
        public ExclusionManagerControl()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public bool IsInclusionList {
            get { return _IsInclusion; }
            set { _IsInclusion = value; }
        }

        private ExcludeList List {
            get {
                if (IsInclusionList) {
                    return Settings.Settings.IncludeList;
                }
                return Settings.Settings.ExcludeList;
            }
        }

        public void RebuildList()
        {
            ExcList.Items.Clear();
            foreach (ExcludedWindow w in List.Values) {
                ListViewItem ExcludeItem = new ListViewItem();
                ExcludeItem.Name = w.ExclusionName;
                ExcludeItem.Text = w.ExclusionName;
                ExcludeItem.SubItems.Add(w.ProcessName);
                ExcludeItem.SubItems.Add(w.ClassNames);
                ExcludeItem.SubItems.Add(w.HasSkin.ToString());
                ExcludeItem.SubItems.Add(w.SkinName.ToString());
                ExcList.Items.Add(ExcludeItem);
            }
        }

        private void Add_Click()
        {
            ExclusionDialogue NewDialgue = new ExclusionDialogue();
            NewDialgue.ShowDialog(this);

            if (NewDialgue.DialogResult == DialogResult.OK) {
                ExcludedWindow NewInfo = NewDialgue.ExcludeInfo;
                List.Add(NewInfo);
                RebuildList();
            }
        }

        private void Edit_Click()
        {
            if (ExcList.SelectedItems.Count > 0) {
                ExclusionDialogue EditDialogue = new ExclusionDialogue();
                ExcludedWindow OldWindow = List[ExcList.SelectedItems[0].SubItems[1].Text];
                
                EditDialogue.ExcludeInfo = OldWindow;
                EditDialogue.ShowDialog(this);

                if (EditDialogue.DialogResult == DialogResult.OK) {
                    List.Remove(OldWindow);
                    List.Add(EditDialogue.ExcludeInfo);
                    RebuildList();
                }
            }
        }

        private void Remove_Click()
        {
            if (ExcList.SelectedItems.Count > 0) {
                ListViewItem Sel = ExcList.SelectedItems[0];
                if (Confirm(Sel.Text)) {
                    List.Remove(Sel.SubItems[1].Text);
                    ExcList.Items.Remove(Sel);
                }
            }
        }

        private void RemoveAll_Click()
        {
            if (ExcList.Items.Count > 0) {
                if (Confirm("AllListDelte")) {
                    ExcList.Items.Clear();
                    List.Clear();
                }
            }
        }

        public bool Confirm(string Name)
        {
            string Message = Settings.Settings.Language.Dialog(LanguageFile.AreYouSureKey);
            string QMark = Settings.Settings.Language.Dialog(LanguageFile.QuestionMarkKey);
            if (Name == "AllListDelte") {
                Name = Settings.Settings.Language.Dialog(LanguageFile.AllTheListKey);
            }

            return MessageBox.Show(Message + "\"" + Name + "\" " + QMark, ProductName, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private void AddExc_Click(object sender, EventArgs e)
        {
            Add_Click();
        }

        private void RemoveExc_Click(object sender, EventArgs e)
        {
            Remove_Click();
        }

        private void EditExc_Click(object sender, EventArgs e)
        {
            Edit_Click();
        }

        private void RemoveAllExc_Click(object sender, EventArgs e)
        {
            RemoveAll_Click();
        }
    }
}
