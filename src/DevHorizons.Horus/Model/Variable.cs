// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Variable.cs" company="DevHorizons">
// Copyright (c) DevHorizons. All rights reserved.
// </copyright>
//  <summary>
//    Defines the required members for the Decision Table model class.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//    <DateTime>14/02/2020 11:00 AM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Horus.Model
{
    using Newtonsoft.Json;

    /// <summary>
    ///    The variable definition which will be extracted from the rule structure from the JSON data.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///    <DateTime>19/02/2020 10:45 AM</DateTime>
    /// </Created>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "This class will be instantiated by JSON desreialaization.")]
    public class Variable
    {
        /// <summary>
        ///    Gets or sets the name of the variable. This variable name should be unique for all the rules.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>19/02/2020 10:47 AM</DateTime>
        /// </Created>
        [JsonProperty]
        public string Name { get; set; }

        /// <summary>
        ///    Gets or sets the type of the variable.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>19/02/2020 10:48 AM</DateTime>
        /// </Created>
        [JsonProperty]
        public string Type { get; set; }

        /// <summary>
        ///    Gets or sets the default value if no value is set.
        /// </summary>
        /// <value>
        ///    The default value if no value is set.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>02/07/2020 08:44 PM</DateTime>
        /// </Created>
        [JsonProperty]
        public string DefaultValue { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the variable could be nullable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allows null]; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>04/12/2020 04:07 PM</DateTime>
        /// </Created>
        [JsonProperty]
        public bool AllowNull { get; set; }
    }
}
