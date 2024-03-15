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

            public const string StringOptionAliases = "OPTION_STRING_ALIASES";
            public const string StringOptionDescription = "OPTION_STRING_DESCRIPTION";

            public const string IntOptionAliases = "OPTION_INT_ALIASES";
            public const string IntOptionDescription = "OPTION_INT_DESCRIPTION";

            public const string ULongsOptionAliases = "OPTION_ULONG_ALIASES";
            public const string ULongsOptionDescription = "OPTION_ULONG_DESCRIPTION";

            public const string DoubleOptionAliases = "OPTION_DOUBLE_ALIASES";
            public const string DoubleOptionDescription = "OPTION_DOUBLE_DESCRIPTION";

            public const string BoolOptionAliases = "OPTION_BOOL_ALIASES";
            public const string BoolOptionDescription = "OPTION_BOOL_DESCRIPTION";
        }
    }
}
