namespace BorderSkin.Utilities
{
    class InfoFile : IniFile
    {

        const string InfoSection = "Info";
        const string AuthorKey = "Author";

        const string WebsiteKey = "Website";
        public InfoFile(string SkinFile) : base(SkinFile)
        {
        }

        public string Author {
            get { return base.GetValue(InfoSection, AuthorKey, string.Empty); }
        }

        public string Website {

            get { return base.GetValue(InfoSection, WebsiteKey, string.Empty); }
        }

        public static string GetWebSite(string FilePath)
        {
            return new InfoFile(FilePath).Website;
        }
    }
}
