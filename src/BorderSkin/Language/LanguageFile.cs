using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BorderSkin.Utilities;

namespace BorderSkin.Language
{
    class LanguageFile : InfoFile
    {


        const string LanguageSection = "Language";
        public const string LanguageFolderName = "Language";
        public const string LanguageExtension = "ini";

        public static readonly string LanguagesFolder = Path.Combine(Program.AppPath, LanguageFolderName);
        public const string DialogBox = "DialogBox";
        public const string AreYouSureKey = "Are you sure you want to delete";
        public const string AllTheListKey = "all the list";

        public const string QuestionMarkKey = "?";
        public LanguageFile(string LanguageFilePath) : base(LanguageFilePath)
        {
        }

        public string Name {
            get { return Path.GetFileNameWithoutExtension(base.FileName); }
        }

        public static LanguageFile LoadFromDefault(string LanguageName)
        {
            return new LanguageFile(Path.Combine(LanguagesFolder, LanguageName + ".ini"));
        }

        public override string ToString()
        {
            return Path.GetFileNameWithoutExtension(FileName);
        }

        public string GetTranslation(string EnglishText)
        {
            return GetValue(LanguageSection, EnglishText, EnglishText);
        }

        public void ApplyTranslation(Control.ControlCollection Controls)
        {
            foreach (Control c in Controls) {
                if (c.Tag != null) {
                    c.Text = GetValue(LanguageSection, c.Tag.ToString(), c.Text);
                }
                if (c is TabControl) {
                    ApplyTranslation(((TabControl)c).TabPages);
                } else if (c is ListView) {
                    ApplyTranslation(((ListView)c).Columns);
                }
                ApplyTranslation(c.Controls);
            }

        }

        public void ApplyTranslation(ToolStripItemCollection Items)
        {
            foreach (ToolStripItem c in Items) {
                if (c.Tag != null) {
                    c.Text = GetValue(LanguageSection, c.Tag.ToString(), c.Text);
                }
            }
        }

        public void ApplyTranslation(ListView.ColumnHeaderCollection Pages)
        {
            foreach (ColumnHeader c in Pages) {
                if (c.Tag != null) {
                    c.Text = GetValue(LanguageSection, c.Tag.ToString(), c.Text);
                }
            }
        }

        public void ApplyTranslation(TabControl.TabPageCollection Pages)
        {
            foreach (TabPage c in Pages) {
                if (c.Tag != null) {
                    c.Text = GetValue(LanguageSection, c.Tag.ToString(), c.Text);
                }
            }
        }

        public string Dialog(String Type) {
            return base.GetValue(DialogBox, Type, "");
        }

        public static List<LanguageFile> LanguageFiles {
            get {
                List<LanguageFile> functionReturnValue = default(List<LanguageFile>);
                functionReturnValue = new List<LanguageFile>();
                foreach (FileInfo FileName in new DirectoryInfo(LanguagesFolder).GetFiles("*." + LanguageExtension)) {
                    functionReturnValue.Add(new LanguageFile(FileName.FullName));
                }
                return functionReturnValue;
            }
        }
    }
}
