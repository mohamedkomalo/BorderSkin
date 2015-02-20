namespace BorderSkin.Utilities
{
    class ShellClassID
    {

        public static readonly string[,] ShellCSLID = {
            {
                "Administrative Tools",
                "::{D20EA4E1-3957-11d2-A40B-0C5020524153}"
            },
            {
                "Briefcase",
                "::{85BBD920-42A0-1069-A2E4-08002B30309D}"
            },
            {
                "Control Panel",
                "::{21EC2020-3AEA-1069-A2DD-08002b30309d}"
            },
            {
                "Fonts",
                "::{D20EA4E1-3957-11d2-A40B-0C5020524152}"
            },
            {
                "History",
                "::{FF393560-C2A7-11CF-BFF4-444553540000}"
            },
            {
                "Inbox",
                "::{00020D75-0000-0000-C000-000000000046}"
            },
            {
                "Microsoft Network ",
                "::{00028B00-0000-0000-C000-000000000046}"
            },
            {
                "My Computer",
                "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"
            },
            {
                "My Documents",
                "::{450D8FBA-AD25-11D0-98A8-0800361B1103}"
            },
            {
                "My Network Places",
                "::{208D2C60-3AEA-1069-A2D7-08002B30309D}"
            },
            {
                "Network Computers",
                "::{1f4de370-d627-11d1-ba4f-00a0c91eedba}"
            },
            {
                "Network Connections",
                "::{7007ACC7-3202-11D1-AAD2-00805FC1270E}"
            },
            {
                "Printers and Faxes",
                "::{2227A280-3AEA-1069-A2DE-08002B30309D}"
            },
            {
                "Programs Folder",
                "::{7be9d83c-a729-4d97-b5a7-1b7313c39e0a}"
            },
            {
                "Recycle Bin",
                "::{645FF040-5081-101B-9F08-00AA002F954E}"
            },
            {
                "Scanners and Cameras",
                "::{E211B736-43FD-11D1-9EFB-0000F8757FCD}"
            },
            {
                "Scheduled Tasks",
                "::{D6277990-4C6A-11CF-8D87-00AA0060F5BF}"
            },
            {
                "Start Menu Folder",
                "::{48e7caab-b918-4e58-a94d-505519c795dc}"
            },
            {
                "Temporary Internet Files",
                "::{7BD29E00-76C1-11CF-9DD0-00A0C9034933}"
            },
            {
                "Web Folders",
                "::{BDEADF00-C265-11d0-BCED-00A0C90AB50F}"
            }

        };
        private enum SearchType
        {
            Name = 0,
            ID = 1
        }

        public static string NameFromID(string ID)
        {
            string functionReturnValue = null;
            functionReturnValue = ID;
            ID = ID.ToLower();
            for (int i = 0; i <= ShellCSLID.GetUpperBound(0) - 1; i++) {
                if (ShellCSLID[i, (int)SearchType.ID] == ID) {
                    return ShellCSLID[i, (int)SearchType.Name];
                }
            }
            return functionReturnValue;
        }

        public static string IDFromName(string Name)
        {
            for (int i = 0; i <= ShellCSLID.GetUpperBound(0) - 1; i++)
            {
                if (ShellCSLID[i, (int)SearchType.Name] == Name)
                {
                    return ShellCSLID[i, (int)SearchType.ID];
                }
            }
            return Name;
        }

        private static string SearchBoth(string SearchString, SearchType t)
        {
            for (int i = 0; i <= ShellCSLID.GetUpperBound(0) - 1; i++) {
                string Found = ShellCSLID[i, (int)t];
                if (Found == SearchString) {
                    if (t == SearchType.ID) {
                        return ShellCSLID[i, (int)SearchType.Name];
                    } else {
                        return ShellCSLID[i, (int)SearchType.ID];
                    }
                }
            }
            return SearchString;
        }
    }
}
