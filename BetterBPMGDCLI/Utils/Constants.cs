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

        public const string ResourceKeySeparator = "_";

        public const string CommandNameAliasesResourceKey = "COMMAND_NAME_ALIASES";
        public const string CommandDescriptionResourceKey = "COMMAND_DESCRIPTION";
        public const string DefaultMessageResourceKey = "DEFAULT_MESSAGE";

        public const string CanNotBeAnEmptyStringResourceKey = "ERROR_MEMBERCANNOTBEANEMPTYSTRING";
        public const string CanNotBeLongerThanResourceKey = "ERROR_MEMBERCANNOTBELONGERTHAN";
        public const string CanNotIncludeResourceKey = "ERROR_MEMBERCANNOTINCLUDE";
        public const string DoesNotExistsResourceKey = "ERROR_MEMBERDOESNOTEXISTS";

        public const string CurrentProjectMustBeSpecifiedResourceKey = "ERROR_CURRENTPROJECTMUSTBESPECIFIED";

        public const string SuccessResourceKey = "MESSAGE_SUCCESS";

        public const string BaseOptionAliasesResourceKey = "OPTION__ALIASES";
        public const string BaseOptionDescriptionResourceKey = "OPTION__DESCRIPTION";

        public const string StringOptionAliasesResourceKey = "OPTION_STRING_ALIASES";
        public const string StringOptionDescriptionResourceKey = "OPTION_STRING_DESCRIPTION";

        public const string IntOptionAliasesResourceKey = "OPTION_INT32_ALIASES";
        public const string IntOptionDescriptionResourceKey = "OPTION_INT32_DESCRIPTION";

        public const string ULongsOptionAliasesResourceKey = "OPTION_UINT64_ALIASES";
        public const string ULongsOptionDescriptionResourceKey = "OPTION_UINT64_DESCRIPTION";

        public const string DoubleOptionAliasesResourceKey = "OPTION_DOUBLE_ALIASES";
        public const string DoubleOptionDescriptionResourceKey = "OPTION_DOUBLE_DESCRIPTION";

        public const string BoolOptionAliasesResourceKey = "OPTION_BOOLEAN_ALIASES";
        public const string BoolOptionDescriptionResourceKey = "OPTION_BOOLEAN_DESCRIPTION";

        public const string CLICommandsResourceType = "CLICommands";


        public const int MillisecondsInMinute = MillisecondsInSecond * 60;
        public const int MillisecondsInSecond = 1000;
        public const int RoundToDecimalPlaces = 5;

        public const int XORDecryptionKey = 11;

        public const int BaseOptionInsertionIndex = 7;
    }
}
