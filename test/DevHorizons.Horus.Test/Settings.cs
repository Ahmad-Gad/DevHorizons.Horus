namespace DevHorizons.Horus.UnitTests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public static class Settings
    {
        #region Properties
        public static string CSJsonData
        {
            get
            {
                var jsonFile = @"Data\ConditionTables.json";
                var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var settingsFileFullPath = Path.Combine(appPath, jsonFile);
                var csJsonData = File.ReadAllText(settingsFileFullPath);
                if (string.IsNullOrWhiteSpace(csJsonData))
                {
                    csJsonData = null;
                }

                return csJsonData;
            }
        }
        #endregion Properties

        #region Public Methods
        public static bool ValidateRule(List<Dictionary<string, string>> expectedOutputs, List<Dictionary<string, object>> actualResults)
        {
            return Engine.Utility.ValidateRule(expectedOutputs, actualResults);
        }
        /*
        public static bool CompareDictionaries(Dictionary<string, object> actualResults, Dictionary<string, object> expectedResults)
        {
            if (actualResults == null || expectedResults == null)
            {
                return false;
            }

            var result = actualResults.Count == expectedResults.Count && !actualResults.Except(expectedResults).Any();
            if (!result)
            {
                return CompareDictionariesAsString(actualResults, expectedResults);
            }

            return result;
        }

        public static bool CompareDictionariesAsString(Dictionary<string, object> actualResults, Dictionary<string, object> expectedResults)
        {
            if (actualResults == null || expectedResults == null)
            {
                return false;
            }

            var ar = new Dictionary<string, string>();
            actualResults.ToList().ForEach(a => ar.Add(a.Key, a.Value.ToString()));

            var er = new Dictionary<string, string>();
            expectedResults.ToList().ForEach(a => er.Add(a.Key, a.Value.ToString()));

            return actualResults.Count == expectedResults.Count && !ar.Except(er).Any();
        }
        */
        #endregion Public Methods
    }
}
