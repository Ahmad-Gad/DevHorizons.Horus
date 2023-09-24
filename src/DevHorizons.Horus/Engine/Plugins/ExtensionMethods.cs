// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="DevHorizons">
// Copyright (c) DevHorizons. All rights reserved.
// </copyright>
//  <summary>
//    Defines the required extension methods which need to be injected with the dynamic script for the dynamic rules validation.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//    <DateTime>14/02/2020 11:00 AM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
#pragma warning disable 1591
namespace DevHorizons.Horus.Engine.Plugins
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    ///    Defines the required extension methods which need to be injected with the dynamic script for the dynamic rules validation.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///    <DateTime>18/06/2020 11:50 AM</DateTime>
    /// </Created>
    [ExcludeFromCodeCoverage]
    public static class ExtensionMethods
    {
        #region In & NotIn
        #region In

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="string"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this string value, params string[] range)
        {
            if (value == null || range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="char"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>04/12/2020 04:23 PM</DateTime>
        /// </Created>
        public static bool In(this char value, params char[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="byte"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this byte value, params byte[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="sbyte"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this sbyte value, params sbyte[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="short"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this short value, params short[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="ushort"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this ushort value, params ushort[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="int"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this int value, params int[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="uint"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this uint value, params uint[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="long"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this long value, params long[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="ulong"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this ulong value, params ulong[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="float"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this float value, params float[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="double"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this double value, params double[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="decimal"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this decimal value, params decimal[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="DateTime"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool In(this DateTime value, params DateTime[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return range.Any(i => i == value);
        }
        #endregion In

        #region NotIn

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="string"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this string value, params string[] range)
        {
            if (value == null || range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="char"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this char value, params char[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="byte"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this byte value, params byte[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="sbyte"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this sbyte value, params sbyte[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="short"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this short value, params short[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="ushort"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this ushort value, params ushort[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="int"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this int value, params int[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="uint"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this uint value, params uint[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="long"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this long value, params long[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="ulong"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this ulong value, params ulong[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="float"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this float value, params float[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="double"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this double value, params double[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="decimal"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this decimal value, params decimal[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }

        /// <summary>
        ///    Check whether the specified value is not in the specified range.
        /// </summary>
        /// <param name="value">The value to be validated/checked against a specfied range.</param>
        /// <param name="range">The range of value as params <see cref="Array"/> of <see cref="DateTime"/>.</param>
        /// <returns>
        ///    <c>true</c> if specified value is not in the specified range of values; otherwise it should return <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:50 AM</DateTime>
        /// </Created>
        public static bool NotIn(this DateTime value, params DateTime[] range)
        {
            if (range == null || range.Length == 0)
            {
                return false;
            }

            return !range.Any(i => i == value);
        }
        #endregion NotIn
        #endregion In & NotIn

        #region Between & NotBetween
        #region Between

        /// <summary>
        ///    Check whether the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool Between(this short value, short minValue, short maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        /// <summary>
        ///    Check whether the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool Between(this ushort value, ushort minValue, ushort maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        /// <summary>
        ///    Check whether the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool Between(this int value, int minValue, int maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        /// <summary>
        ///    Check whether the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool Between(this uint value, uint minValue, uint maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        /// <summary>
        ///    Check whether the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool Between(this long value, long minValue, long maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        /// <summary>
        ///    Check whether the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool Between(this ulong value, ulong minValue, ulong maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        /// <summary>
        ///    Check whether the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool Between(this float value, float minValue, float maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        /// <summary>
        ///    Check whether the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool Between(this double value, double minValue, double maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        /// <summary>
        ///    Check whether the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool Between(this decimal value, decimal minValue, decimal maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        /// <summary>
        ///    Check whether the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is greater than or equal the specified minimum value and less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool Between(this DateTime value, DateTime minValue, DateTime maxValue)
        {
            return value >= minValue && value <= maxValue;
        }
        #endregion Between

        #region NotBetween

        /// <summary>
        ///    Check whether the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool NotBetween(this short value, short minValue, short maxValue)
        {
            return !(value >= minValue && value <= maxValue);
        }

        /// <summary>
        ///    Check whether the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool NotBetween(this ushort value, ushort minValue, ushort maxValue)
        {
            return !(value >= minValue && value <= maxValue);
        }

        /// <summary>
        ///    Check whether the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool NotBetween(this int value, int minValue, int maxValue)
        {
            return !(value >= minValue && value <= maxValue);
        }

        /// <summary>
        ///    Check whether the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool NotBetween(this uint value, uint minValue, uint maxValue)
        {
            return !(value >= minValue && value <= maxValue);
        }

        /// <summary>
        ///    Check whether the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool NotBetween(this long value, long minValue, long maxValue)
        {
            return !(value >= minValue && value <= maxValue);
        }

        /// <summary>
        ///    Check whether the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool NotBetween(this ulong value, ulong minValue, ulong maxValue)
        {
            return !(value >= minValue && value <= maxValue);
        }

        /// <summary>
        ///    Check whether the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool NotBetween(this float value, float minValue, float maxValue)
        {
            return !(value >= minValue && value <= maxValue);
        }

        /// <summary>
        ///    Check whether the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool NotBetween(this double value, double minValue, double maxValue)
        {
            return !(value >= minValue && value <= maxValue);
        }

        /// <summary>
        ///    Check whether the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool NotBetween(this decimal value, decimal minValue, decimal maxValue)
        {
            return !(value >= minValue && value <= maxValue);
        }

        /// <summary>
        ///    Check whether the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value.
        /// </summary>
        /// <param name="value">The value to validated/checked.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///    <c>true</c> if the specified value is not greater than or equal the specified minimum value and not less than or equal the specified maximum value. Otherwise; <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/06/2020 11:55 AM</DateTime>
        /// </Created>
        public static bool NotBetween(this DateTime value, DateTime minValue, DateTime maxValue)
        {
            return !(value >= minValue && value <= maxValue);
        }
        #endregion NotBetween
        #endregion Between & NotBetween

        #region DateTime
        [ExcludeFromCodeCoverage]
        public static DateTime ToDateTime(this string value)
        {
            return Convert.ToDateTime(value);
        }

        public static DateTime ToDT(this string value)
        {
            return Convert.ToDateTime(value);
        }
        #endregion DateTime

        #region Object
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
        #endregion Object

        #region String
        public static bool IsNullOrEmpty(this string str)
        {
            return str == null || str.Length == 0;
        }

        public static bool IsNullOrEmpty(this string str, bool trimWhiteSpace)
        {
            return str == null || str.Length == 0 || (trimWhiteSpace && str.Replace('\t', ' ').Trim().Length == 0);
        }
        #endregion String

        #region Integers
        public static short ToShort(this object obj)
        {
            return Convert.ToInt16(obj);
        }

        public static short ToShort(this object obj, short failOverValue)
        {
            var ok = short.TryParse(obj.ToString(), out short result);
            return ok ? result : failOverValue;
        }

        public static int ToInt(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static int ToInt(this object obj, int failOverValue)
        {
            var ok = int.TryParse(obj.ToString(), out int result);
            return ok ? result : failOverValue;
        }

        public static long ToLong(this object obj)
        {
            return Convert.ToInt64(obj);
        }

        public static long ToLong(this object obj, long failOverValue)
        {
            var ok = long.TryParse(obj.ToString(), out long result);
            return ok ? result : failOverValue;
        }
        #endregion Integers

        #region Floats
        public static float ToFloat(this object obj)
        {
            return Convert.ToSingle(obj);
        }

        public static float ToFloat(this object obj, float failOverValue)
        {
            var ok = float.TryParse(obj.ToString(), out float result);
            return ok ? result : failOverValue;
        }

        public static double ToDouble(this object obj)
        {
            return Convert.ToDouble(obj);
        }

        public static double ToDouble(this object obj, double failOverValue)
        {
            var ok = double.TryParse(obj.ToString(), out double result);
            return ok ? result : failOverValue;
        }

        public static decimal ToDecimal(this object obj)
        {
            return Convert.ToDecimal(obj);
        }

        public static decimal ToDecimal(this object obj, decimal failOverValue)
        {
            var ok = decimal.TryParse(obj.ToString(), out decimal result);
            return ok ? result : failOverValue;
        }
        #endregion Floats

        #region Boolean
        public static bool ToBool(this object obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static bool ToBool(this object obj, bool failOverValue)
        {
            var ok = bool.TryParse(obj.ToString(), out bool result);
            return ok ? result : failOverValue;
        }

        public static bool ToBoolean(this object obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static bool ToBoolean(this object obj, bool failOverValue)
        {
            var ok = bool.TryParse(obj.ToString(), out bool result);
            return ok ? result : failOverValue;
        }
        #endregion Boolean
    }
}
#pragma warning restore 1591