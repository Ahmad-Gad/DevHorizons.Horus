// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DecisionTableCondition.cs" company="DevHorizons">
// Copyright (c) DevHorizons. All rights reserved.
// </copyright>
//  <summary>
//    Defines the required members for the Decision Table Condition model class.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//    <DateTime>14/02/2020 11:00 AM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Horus.Model
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    ///    The Decision Table Condition which will be extracted from the rule set JSON data.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///    <DateTime>18/02/2020 05:23 PM</DateTime>
    /// </Created>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "This class will be instantiated by JSON desreialaization.")]
    public class DecisionTableCondition
    {
        /// <summary>
        ///    Gets or sets the list of the conditions as some assigned values to be compared with the input data.
        /// </summary>
        /// <value>
        ///    The conditions.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 05:24 PM</DateTime>
        /// </Created>
        [JsonProperty]
        public List<string> Conditions { get; set; }

        /// <summary>
        ///    Gets or sets the return values in case of the condition is validated.
        /// </summary>
        /// <value>
        ///  The return values in case of the condition is validated.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 05:24 PM</DateTime>
        /// </Created>
        [JsonProperty]
        public List<string> Return { get; set; }
    }
}
