// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConditionTable.cs" company="DevHorizons">
// Copyright (c) DevHorizons. All rights reserved.
// </copyright>
//  <summary>
//    Defines the required members for the condition table model class. The condition table is an extension of the decision table with advanced/complex rules/conditions.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//    <DateTime>17/06/2020 01:29 PM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Horus.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    /// <summary>
    ///    The Condition Table definition which will be extracted from the rule set JSON data.
    ///    <para> The condition table is an extension of the decision table with advanced/complex rules/conditions.</para>
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///    <DateTime>17/06/2020 01:29 PM</DateTime>
    /// </Created>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "This class will be instantiated by JSON desreialaization.")]
    public class ConditionTable
    {
        /// <summary>
        ///    Gets or sets the Decision Table name.
        /// </summary>
        /// <value>
        ///    The Decision Table name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 05:39 PM</DateTime>
        /// </Created>
        [JsonProperty]
        [Required]
        public string Name { get; set; }

        /// <summary>
        ///    Gets or sets the group name.
        /// </summary>
        /// <value>
        ///    The group name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>02/07/2020 08:41 PM</DateTime>
        /// </Created>
        [JsonProperty]
        public string Group { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether [reset the cache for this rule only once], the next time attempting to call this rules.
        ///    <para>This will be managed by the <c>"DevHorizons.Horus.WebApi"</c> project and no user should explicitly alter it.</para>
        /// </summary>
        /// <value>
        ///    If set to <c>true</c> the entire cache will be flushed for this rule with the next execution only and then it will be automatically set to <c>false</c> again.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>06/07/2020 11:37 AM</DateTime>
        /// </Created>
        [JsonProperty]
        public bool ResetCache { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the whole rule design/body can be cached.
        ///    <para>By default the rule will be cached unless it is explicitly set to <c>false</c>.</para>
        /// </summary>
        /// <value>
        ///   <c>null</c> or <c>true</c>, cache the whole rule; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>19/02/2020 10:37 AM</DateTime>
        /// </Created>
        [JsonProperty]
        public bool? DataCached { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the generated/parsed command can be cached.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [command cached]; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>19/02/2020 10:37 AM</DateTime>
        /// </Created>
        [JsonProperty]
        public bool CommandCached { get; set; } = true;

        /// <summary>
        ///     Gets or sets a value indicating whether the return values of the rule can be cached as unique cache for each different/unique inputs.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [value cached]; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>19/02/2020 10:38 AM</DateTime>
        /// </Created>
        [JsonProperty]
        public bool ValueCached { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the rule's executiona output/result will be [two dimensional results] as a collection of "<see cref="System.Collections.Generic.ICollection{T}"/>" instead of a single one.
        /// </summary>
        /// <value>
        ///   If set to <c>true</c>, the output/result of the rule's exection will be a collection of "<see cref="System.Collections.Generic.ICollection{T}"/>", otherwise, the out put will be a single  "<see cref="System.Collections.Generic.ICollection{T}"/>".
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>27/01/2021 10:38 AM</DateTime>
        /// </Created>
        [JsonProperty]
        public bool TwoDimResults { get; set; }

        /// <summary>
        ///    Gets or sets the rule's description.
        /// </summary>
        /// <value>
        ///    The rule's description.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>19/02/2020 10:37 AM</DateTime>
        /// </Created>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>
        ///    Gets or sets the inputs.
        /// </summary>
        /// <value>
        /// The inputs.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 05:39 PM</DateTime>
        /// </Created>
        [JsonProperty]
        [Required]
        public List<Variable> Inputs { get; set; }

        /// <summary>
        ///    Gets or sets the outputs.
        /// </summary>
        /// <value>
        /// The outputs.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 05:39 PM</DateTime>
        /// </Created>
        [JsonProperty]
        [Required]
        public List<Variable> Outputs { get; set; }

        /// <summary>
        ///    Gets or sets the decisions.
        /// </summary>
        /// <value>
        /// The decisions.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 05:39 PM</DateTime>
        /// </Created>
        [JsonProperty]
        [Required]
        public List<DecisionTableCondition> Decisions { get; set; }
    }
}
