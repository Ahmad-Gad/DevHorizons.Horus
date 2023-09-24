// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
// </copyright>
//  <summary>
//    Defines the required members for the command template.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//    <DateTime>14/02/2020 11:00 AM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Horus.Internal
{
    using System;

    /// <summary>
    ///    A class holds all the required extension methods to support the project.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///    <DateTime>08/12/2020 10:08 AM</DateTime>
    /// </Created>
    internal static class ExtensionMethods
    {
        /// <summary>
        ///    Get the masked date time with a parsed C# syntax.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>
        ///    The masked date time with a parsed C# syntax.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>07/12/2020 05:23 PM</DateTime>
        /// </Created>
        internal static string ReplaceMaskedDateTime(this string input)
        {
            var delimeter = "#";
            var startPos = -1;
            var result = string.Empty;

            for (var i = 0; i < input.Length; i++)
            {
                var delSplit = i + delimeter.Length > input.Length ? string.Empty : input.Substring(i, delimeter.Length);
                if (delSplit.Equals(delimeter, StringComparison.InvariantCulture))
                {
                    if (startPos == -1)
                    {
                        startPos = i;
                        i += delimeter.Length - 1;
                    }
                    else
                    {
                        string cutValue;
                        cutValue = input.Substring(startPos + delimeter.Length, i - startPos - delimeter.Length);
                        var replacedValue = $"Convert.ToDateTime(\"{cutValue}\")";
                        result += replacedValue;
                        i += delimeter.Length - 1;
                        startPos = -1;
                    }
                }
                else
                {
                    if (startPos == -1 && i < input.Length)
                    {
                        result += input[i];
                    }
                }
            }

            if (startPos != -1)
            {
                result += input.Substring(startPos);
            }

            return result;
        }
    }
}