using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BorderSkin.Utilities
{
    class IniFile
    {

        string _Filename;
        #region "API Calls"
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);
	
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern uint GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            [In, Out] char[] lpReturnedString,
            uint nSize,
            string lpFileName);

        #endregion

        public IniFile(string Filename)
        {
            if (!System.IO.File.Exists(Filename))
            {
                throw new ArgumentException("file doesn't exists");
            }
            _Filename = Path.GetFullPath(Filename);
        }

        public string FileName {
            get { return _Filename; }
        }

        public FileInfo File {
            get { return new FileInfo(FileName); }
        }

        public DirectoryInfo Directory {
            get { return File.Directory; }
        }

        public string[] SectionsNames {
            get {
                string[] functionReturnValue = null;
                functionReturnValue = GetValue(null, null, "").Split('\0');
                Array.Resize(ref functionReturnValue, functionReturnValue.Length - 1);
                return functionReturnValue;
            }
        }

        public string[] GetKeys(string SectionName)
        {
            string[] functionReturnValue = null;
            functionReturnValue = GetValue(SectionName, null, "").Split('\0');
            Array.Resize(ref functionReturnValue, functionReturnValue.Length - 1);
            return functionReturnValue;
        }

        public string GetValue(string SectionName, string KeyName, string DefaultValue)
        {
            string functionReturnValue = null;
            // primary version of call gets single value given all parameters
		
            char[] sData = new char[1024];
        
            // allocate some room
            uint n = GetPrivateProfileString(SectionName, KeyName, DefaultValue, sData, (uint)sData.Length, FileName);
            // return whatever it gave us
            if (n > 0) {
                functionReturnValue = new String(sData, 0, (int)n);
            } else {
                functionReturnValue = "";
            }
            return functionReturnValue;
        }

        public int GetValue(string SectionName, string KeyName, int DefaultValue)
        {

            return Convert.ToInt32(GetValue(SectionName, KeyName, DefaultValue.ToString()));
        }

        public bool GetValue(string SectionName, string KeyName, bool DefaultValue)
        {

            return Convert.ToBoolean(GetValue(SectionName, KeyName, DefaultValue.ToString()));
        }

        public void SetValue(string SectionName, string KeyName, string Value)
        {
            WritePrivateProfileString(SectionName, KeyName, Value, FileName);
        }

        public void SetValue(string SectionName, string KeyName, int Value)
        {
            WritePrivateProfileString(SectionName, KeyName, Value.ToString(), FileName);
        }

        public void DeleteSection(string SectionName)
        {
            WritePrivateProfileString(SectionName, null, null, FileName);
        }

        public void DeleteKey(string SectionName, string KeyName)
        {
            WritePrivateProfileString(SectionName, KeyName, null, FileName);
        }

        public bool Exists(string Section)
        {
            return Exists(Section, null);
        }

        public bool Exists(string Section, string Key)
        {
            return GetValue(Section, Key, string.Empty).Length > 0;
        }
    }
}
