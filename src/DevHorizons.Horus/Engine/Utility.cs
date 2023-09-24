// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utility.cs" company="DevHorizons">
// Copyright (c) DevHorizons. All rights reserved.
// </copyright>
//  <summary>
//    Defines all utility/helper methods for the Conditions Engine.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//    <DateTime>14/02/2020 11:00 AM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Horus.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///    A static class to hold all the utility/helper methods for the Conditions Engine.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///    <DateTime>28/01/2021 02:32 PM</DateTime>
    /// </Created>
    public static class Utility
    {
        #region Public Methods

        /// <summary>
        ///    Gets the type from value data type's alias name.
        /// </summary>
        /// <param name="alias">The alias name of a value data type. Eg. int, float, string.</param>
        /// <returns>
        ///    The system type from the alias name as an instance of "<see cref="Type"/>".
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>28/01/2021 02:31 PM</DateTime>
        /// </Created>
        public static Type GetTypeFromAlias(string alias)
        {
            if (alias == null)
            {
                return null;
            }

            alias = alias.Split('.')[0];
            switch (alias.ToUpperInvariant())
            {
                case "CHAR":
                    {
                        return typeof(char);
                    }

                case "STRING":
                    {
                        return typeof(string);
                    }

                case "BOOL":
                case "BOOLEAN":
                    {
                        return typeof(bool);
                    }

                case "DATETIME":
                    {
                        return typeof(DateTime);
                    }

                case "BYTE":
                    {
                        return typeof(byte);
                    }

                case "SBYTE":
                    {
                        return typeof(sbyte);
                    }

                case "SHORT":
                case "INT16":
                    {
                        return typeof(short);
                    }

                case "USHORT":
                case "UINT16":
                    {
                        return typeof(ushort);
                    }

                case "INT":
                case "INT32":
                    {
                        return typeof(int);
                    }

                case "UINT":
                case "UINT32":
                    {
                        return typeof(uint);
                    }

                case "LONG":
                case "INT64":
                    {
                        return typeof(long);
                    }

                case "ULONG":
                case "UINT64":
                    {
                        return typeof(ulong);
                    }

                case "FLOAT":
                case "SINGLE":
                    {
                        return typeof(float);
                    }

                case "DOUBLE":
                    {
                        return typeof(double);
                    }

                case "DECIMAL":
                    {
                        return typeof(decimal);
                    }

                default:
                    {
                        return null;
                    }
            }
        }

        /// <summary>
        ///    Gets the default value from value data type's alias name.
        /// </summary>
        /// <param name="alias">The alias name of a value data type. Eg. int, float, string.</param>
        /// <returns>
        ///    The default value from the alias name as an "<see cref="object"/>".
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>28/01/2021 02:49 PM</DateTime>
        /// </Created>
        public static object GetDefaultValueFromAlias(string alias)
        {
            var type = GetTypeFromAlias(alias);
            return Activator.CreateInstance(type);
        }

        /// <summary>
        ///    Validates the rule by comparing the specified actual results with the specified expected outputs.
        /// </summary>
        /// <param name="expectedOutputs">The expected outputs.</param>
        /// <param name="actualResults">The actual results.</param>
        /// <returns>
        ///    <c>true</c> if the rule has been validated successfully, otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>28/01/2021 09:11 PM</DateTime>
        /// </Created>
        public static bool ValidateRule(List<Dictionary<string, string>> expectedOutputs, List<Dictionary<string, object>> actualResults)
        {
            if (expectedOutputs == null || actualResults == null || actualResults.Count == 0 || expectedOutputs.Count != actualResults.Count)
            {
                return false;
            }

            var sortKeys = GetValidationSortKeys(actualResults);
            var transformedActualOutputList = GetTransformedActualOutputsList(actualResults, sortKeys);
            var transformedExpectedOutputsList = GetTransformedExpectedOutputsList(expectedOutputs, sortKeys);

            var validated = true;
            for (var i = 0; i < actualResults.Count; i++)
            {
                var actualDic = transformedActualOutputList[i];
                var expectedDic = transformedExpectedOutputsList[i];
                validated = CompareDictionaries(actualDic, expectedDic);

                if (!validated)
                {
                    break;
                }
            }

            return validated;
        }
        #endregion Public Methods

        #region Private Methods
        #region Validate Rule
        private static List<string> GetValidationSortKeys(List<Dictionary<string, object>> actualOutPutList)
        {
            return actualOutPutList[0].Keys.ToList();
        }

        private static List<Dictionary<string, string>> GetTransformedActualOutputsList(List<Dictionary<string, object>> actualResults, List<string> sortKeys)
        {
            var actualOutputsStringList = new List<Dictionary<string, string>>();
            foreach (var objDic in actualResults)
            {
                var strDic = new Dictionary<string, string>();
                foreach (var item in objDic)
                {
                    strDic.Add(item.Key, item.Value?.ToString());
                }

                actualOutputsStringList.Add(strDic);
            }

            actualOutputsStringList = GetSortedValidationList(actualOutputsStringList, sortKeys);
            return actualOutputsStringList;
        }

        private static List<Dictionary<string, string>> GetTransformedExpectedOutputsList(List<Dictionary<string, string>> expectedOutputs, List<string> sortKeys)
        {
            var transformedExpectedOutputsList = new List<Dictionary<string, string>>();
            foreach (var expDic in expectedOutputs)
            {
                var transDic = new Dictionary<string, string>();
                foreach (var item in expDic)
                {
                    var value = item.Value;
                    if (bool.TryParse(item.Value, out bool boolValue))
                    {
                        value = boolValue.ToString();
                    }

                    transDic.Add(item.Key, value);
                }

                transformedExpectedOutputsList.Add(transDic);
            }

            transformedExpectedOutputsList = GetSortedValidationList(transformedExpectedOutputsList, sortKeys);
            return transformedExpectedOutputsList;
        }

        private static List<Dictionary<string, string>> GetSortedValidationList(List<Dictionary<string, string>> dicList, List<string> sortKeys)
        {
            var sortedList = dicList.OrderBy(dic => dic[sortKeys[0]]);
            foreach (var key in sortKeys.GetRange(1, sortKeys.Count - 1))
            {
                sortedList = sortedList.ThenBy(dic => dic[key]);
            }

            return sortedList.ToList();
        }

        private static bool CompareDictionaries(Dictionary<string, string> actualResults, Dictionary<string, string> expectedResults)
        {
            if (actualResults == null || expectedResults == null)
            {
                return false;
            }

            var result = actualResults.Count == expectedResults.Count && !actualResults.Except(expectedResults).Any();
            return result;
        }
        #endregion Validate Rule
        #endregion Private Methods
    }
}