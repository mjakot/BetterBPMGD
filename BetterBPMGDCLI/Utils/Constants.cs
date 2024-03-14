namespace BetterBPMGDCLI.Utils
{
    public readonly struct Constants
    {
        public const string FirstLevelKey = "k_0";
        public const string LevelOnTopKey = "k_-1";

        public const string NameElementKey = "k2";
        public const string DescriptionElementKey = "k3";
        public const string LevelDataElementKey = "k4";
        public const string OfficialSongIdElementKey = "k8";
        public const string CustomSongIdElementKey = "k45";
        public const string ObjectsCountElementKey = "k48";
        public const string LengthElementKey = "k23";

        public const string GuidelinesKey = "kA14";

        public const string KeyElementTag = "k";
        public const string StringElementTag = "s";
        public const string IntegerElementTag = "i";
        public const string DictionaryElementTag = "d";

        public const string NotFoundPlaceholder = "NotFound";

        public const string GuidelinesSeparator = "~";

        public const string DataSeparator = ",";
        public const string ObjectEnd = ";";

        public const string ObjectIdKey = "1";
        public const string PositionXKey = "2";
        public const string PositionYKey = "3";

        public const string CheckedKey = "13";

        public const string MP3Extension = ".mp3";
        public const string TXTExtension = ".txt";

        public const string DefaultInnerSeparator = "=";
        public const string DefaultOuterSeparator = ",";

        public const string GDXMLDeclaration = """<?xml version="1.0"?>""";


        public const int MillisecondsInMinute = 60000;  
        public const int RoundToDecimalPlaces = 5;

        public const int XORDecryptionKey = 11;

        public readonly struct ResourceTypes
        {
            public const string CLICommandsStrings = "CLICommands";
        }

        public readonly struct CLICommandsResourcesKeys
        {
            public const string CommandNameAliases = "COMMAND_NAME_ALIASES";
            public const string CommandDescription = "COMMAND_DESCRIPTION";
            public const string DefaultMessage = "DEFAULT_MESSAGE";

            public const string CanNotBeAnEmptyString = "ERROR_MEMBERCANNOTBEANEMPTYSTRING";
            public const string CanNotBeLongerThan = "ERROR_MEMBERCANNOTBELONGERTHAN";
            public const string CanNotInclude = "ERROR_MEMBERCANNOTINCLUDE";
            public const string DoesNotExists = "ERROR_MEMBERDOESNOTEXISTS";

            public const string CurrentProjectMustBeSpecified = "ERROR_CURRENTPROJECTMUSTBESPECIFIED";

            public const string NameOptionAliases = "OPTION_NAME_ALIASES";
            public const string NameOptionDescription = "OPTION_NAME_DESCRIPTION";

            public const string SongIDOptionAliases = "OPTION_SONGID_ALIASES";
            public const string SongIDOptionDescription = "OPTION_SONGID_DESCRIPTION";

            public const string OffsetOptionAliases = "OPTION_OFFSET_ALIASES";
            public const string OffsetOptionDescription = "OPTION_OFFSET_DESCRIPTION";

            public const string BPMOptionAliases = "OPTION_BPM_ALIASES";
            public const string BPMOptionDescription = "OPTION_BPM_DESCRIPTION";

            public const string BoolOptionAliases = "OPTION_BOOL_ALIASES";
            public const string BoolOptionDescription = "OPTION_BOOL_DESCRIPTION";

            public const string BeatSubdivisionOptionAliases = "OPTION_BEATSSUBDIVISION_ALIASES";
            public const string BeatSubdivisionOptionDescription = "OPTION_BEATSSUBDIVISION_DESCRIPTION";

            public const string SpeedOptionAliases = "OPTION_SPEED_ALIASES";
            public const string SpeedOptionDescription = "OPTION_SPEED_DESCRIPTION";

            public const string ColorPatternOptionAliases = "OPTION_COLORPATTER_ALIASES";
            public const string ColorPatternOptionDescription = "OPTION_COLORPATTER_DESCRIPTION";

            public const string KeyOptionAliases = "OPTION_KEY_ALIASES";
            public const string KeyOptionDescription = "OPTION_KEY_DESCRIPTION";
        }
    }
}
