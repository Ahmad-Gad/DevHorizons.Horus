// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInvoker.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
// </copyright>
//  <summary>
//    Defines the required members for the invoker classes.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//    <DateTime>14/02/2020 11:00 AM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Horus.Interfaces
{
    using System.Collections.Generic;
    using Model;

    /// <summary>
    /// Defines all the required members for the invoker classes.
    /// </summary>
    /// <Created>
    ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///   <DateTime>18/02/2020 11:28 AM</DateTime>
    /// </Created>
    public interface IInvoker
    {
        #region Delegates

        /// <summary>
        ///    The error raised delegate to handle all the raised errors and or for logging them if required.
        /// </summary>
        /// <param name="error">The error raised as an instance of "<see cref="LogEntry"/>".</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 11:29 AM</DateTime>
        /// </Created>
        public delegate void ErrorRaisedHandler(LogEntry error);

        /// <summary>
        ///    Caches parsed command generated from the passed JSON data.
        ///    <para>This method will be triggered only if the "CommandCached" property is marked as <c>true</c> inside the rule's JSON data.</para>
        ///    <para>This method needs to be implemented by the caller/consumer application.</para>
        /// </summary>
        /// <param name="ruleKey">The unique key of the specified rule.</param>
        /// <param name="parsedCmd">The parsed command generated from the passed JSON data.</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>19/02/2020 11:48 AM</DateTime>
        /// </Created>
        public delegate void CacheParsedCommandHandler(string ruleKey, string parsedCmd);

        /// <summary>
        ///    Gets the cached parsed command generated from the passed JSON data. This method needs to be implemented by the caller/consumer application.
        ///    <para>This method will be triggered only if the "CommandCached" property is marked as <c>true</c> inside the rule's JSON data.</para>
        ///    <para>This method needs to be implemented by the caller/consumer application.</para>
        /// </summary>
        /// <param name="ruleKey">The unique key of the specified rule.</param>
        /// <returns>
        ///    The cached parsed command generated from the passed JSON data.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 11:39 AM</DateTime>
        /// </Created>
        public delegate string GetCachedParsedCommandHandler(string ruleKey);

        /// <summary>
        ///    Caches the execution value/result after executing a successful command generated from the specified rule.
        ///    <para>This method will be triggered only if the "ValueCached" property is marked as <c>true</c> inside the rule's JSON data.</para>
        ///    <para>The "ValueCached" property should only marked as <c>true</c> if we are pretty sure that this rule can be called over and over by the same inputs.</para>
        ///    <para>This method needs to be implemented by the caller/consumer application.</para>
        /// </summary>
        /// <param name="ruleKey">The unique key of the specified rule.</param>
        /// <param name="inputs">The inputs values to be combined with the rule key in the cache to distinguish the cached values by different inputs for the same rule.</param>
        /// <param name="ruleValue">The rule value.</param>
        /// <param name="flushCache">if set to <c>true</c> [flush all the cached execution values for this rule].</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 11:45 AM</DateTime>
        /// </Created>
        public delegate void CacheExecutionValueHandler(string ruleKey, IDictionary<string, string> inputs, List<Dictionary<string, object>> ruleValue, bool flushCache);

        /// <summary>
        ///    Gets the cached execution value/result after executing a successful command generated from the specified rule.
        ///    <para>This method will be triggered only if the "ValueCached" property is marked as <c>true</c> inside the rule's JSON data.</para>
        ///    <para>The "ValueCached" property should only marked as <c>true</c> if we are pretty sure that this rule can be called over and over by the same inputs.</para>
        ///    <para>This method needs to be implemented by the caller/consumer application.</para>
        /// </summary>
        /// <param name="ruleKey">The unique key of the specified rule.</param>
        /// <param name="inputs">The inputs values to be combined with the rule key in the cache to distinguish the cached values by different inputs for the same rule.</param>
        /// <returns>
        ///    The cached execution value/result after executing a successful command generated from the specified rule.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 11:45 AM</DateTime>
        /// </Created>
        public delegate List<Dictionary<string, object>> GetCachedExecutionValueHandler(string ruleKey, IDictionary<string, string> inputs);

        /// <summary>
        ///    Called when caches the Condition Table.
        /// </summary>
        /// <param name="conditionTable">The Condition Table.</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>02/07/2020 05:08 PM</DateTime>
        /// </Created>
        public delegate void CacheConditionTableHandler(ConditionTable conditionTable);

        /// <summary>
        ///    Called when [get the cached condition table].
        /// </summary>
        /// <returns>
        ///    Returns the cached condition table.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>02/07/2020 05:09 PM</DateTime>
        /// </Created>
        public delegate ConditionTable GetCachedConditionTableHandler();

        /// <summary>
        ///    Called when [get the Condition Table from either some data source or cache].
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="name">The rule/condition table's name.</param>
        /// <returns>
        ///    The Condition Table from either some data source or cache.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>03/07/2020 05:58 PM</DateTime>
        /// </Created>
        public delegate ConditionTable GetConditionTableFromSourceHandler(string group, string name);
        #endregion Delegates

        #region Events

        /// <summary>
        ///    Occurs when [error raised].
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 12:38 PM</DateTime>
        /// </Created>
        public event ErrorRaisedHandler ErrorRaised;

        /// <summary>
        ///    Occurs when [on cache parsed command] which is handled by "<see cref="OnCacheParsedCommand(string, string)"/>".
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>19/02/2020 12:27 PM</DateTime>
        /// </Created>
        public event CacheParsedCommandHandler CacheParsedCommand;

        /// <summary>
        ///    Occurs when [on get cached parsed command] which is handled by "<see cref="OnGetCachedParsedCommand(string)"/>".
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>19/02/2020 01:44 PM</DateTime>
        /// </Created>
        public event GetCachedParsedCommandHandler GetCachedParsedCommand;

        /// <summary>
        ///    Occurs when [on cache execution value] which is handled by "<see cref="OnCacheExecutionValue(string, IDictionary{string, string}, List{Dictionary{string, object}}, bool)"/>".
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>19/02/2020 01:44 PM</DateTime>
        /// </Created>
        public event CacheExecutionValueHandler CacheExecutionValue;

        /// <summary>
        ///    Occurs when [on get cached execution value] which is handled by "<see cref="OnGetCachedExecutionValue(string, IDictionary{string, string})"/>".
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>19/02/2020 01:45 PM</DateTime>
        /// </Created>
        public event GetCachedExecutionValueHandler GetCachedExecutionValue;

        /// <summary>
        ///    Occurs when [get the Condition Table from either some data source or cache] which is handled by "<see cref="OnGetConditionTableFromSource(string, string)"/>".
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>03/07/2020 05:58 PM</DateTime>
        /// </Created>
        public event GetConditionTableFromSourceHandler GetConditionTableFromSource;
        #endregion Events

        #region Properties

        /// <summary>
        ///    Gets the raised errors list as "<see cref="List{T}"/>" of ""<see cref="LogEntry"/>.
        /// </summary>
        /// <value>
        ///    The raised errors.
        /// </value>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>02/11/2018 05:39 PM</DateTime>
        /// </Created>
        List<LogEntry> Errors { get; }

        /// <summary>
        ///    Gets or sets the fail over group. This group will be used to search for a rule matching it if not found a match for the primary one.
        /// </summary>
        /// <value>
        /// The fail over group.
        /// </value>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>06/07/2020 05:53 PM</DateTime>
        /// </Created>
        string FailOverGroup { get; set; }
        #endregion Properties

        #region Methods

        /// <summary>
        ///    Gets the rule key.
        /// </summary>
        /// <param name="ct">The ct.</param>
        /// <returns>
        ///     The rule key.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>13/10/2020 06:43 PM</DateTime>
        /// </Created>
        public static string GetRuleKey(ConditionTable ct)
        {
            return GetRuleKey(ct.Group, ct.Name);
        }

        /// <summary>
        ///    Gets the rule key.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="name">The name.</param>
        /// <returns>
        ///     The rule key.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>13/10/2020 06:48 PM</DateTime>
        /// </Created>
        public static string GetRuleKey(string group, string name)
        {
            return $"{group.ToUpperInvariant()}.{name.ToUpperInvariant()}";
        }

        /// <summary>
        ///    Clears the errors list.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>02/11/2018 09:48 PM</DateTime>
        /// </Created>
        void ClearErrors();

        /// <summary>
        ///    Executes the rule and return the output values as "<see cref="List{T}" />" where "T" is "<see cref="IDictionary{TKey, TValue}" />" (where "TKey" is a "<see cref="string" />" and "TValue" is an "<see cref="object" />").
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="ruleName">The name of the rule to be executed.</param>
        /// <param name="inputs">The inputs data as "<see cref="IDictionary{TKey, TValue}" />" where "TKey" is a "<see cref="string" />" and "TValue" is an "<see cref="string" />". Those inputs names must be covered inside the specified rule in the "Inputs" section.</param>
        /// <returns>
        ///    The validated results as "<see cref="List{T}" />" where "T" is "<see cref="IDictionary{TKey, TValue}" />" (where "TKey" is a "<see cref="string" />" and "TValue" is an "<see cref="object" />").
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>02/07/2020 12:02 PM</DateTime>
        /// </Created>
        List<Dictionary<string, object>> ExecuteRule(string group, string ruleName, IDictionary<string, string> inputs);

        /// <summary>
        /// Executes the rule and return the output values as "<see cref="List{T}" />" where "T" is "<see cref="IDictionary{TKey, TValue}" />" (where "TKey" is a "<see cref="string" />" and "TValue" is an "<see cref="object" />").
        /// </summary>
        /// <param name="conditionTable">The condition table.</param>
        /// <param name="inputs">The inputs.</param>
        /// <returns>
        ///    The validated results as "<see cref="List{T}" />" where "T" is "<see cref="IDictionary{TKey, TValue}" />" (where "TKey" is a "<see cref="string" />" and "TValue" is an "<see cref="object" />").
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>08/10/2020 11:10 PM</DateTime>
        /// </Created>
        List<Dictionary<string, object>> ExecuteRule(ConditionTable conditionTable, IDictionary<string, string> inputs);

        /// <summary>
        ///    Caches parsed command generated from the passed JSON data.
        ///    <para>This method will be triggered only if the "CommandCached" property is marked as <c>true</c> inside the rule's JSON data.</para>
        ///    <para>This method needs to be implemented by the caller/consumer application.</para>
        /// </summary>
        /// <param name="ruleKey">The unique key of the specified rule.</param>
        /// <param name="parsedCmd">The parsed command generated from the passed JSON data.</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 11:38 AM</DateTime>
        /// </Created>
        void OnCacheParsedCommand(string ruleKey, string parsedCmd);

        /// <summary>
        ///    Caches parsed command generated from the passed <c>JSON</c> data.
        /// </summary>
        /// <param name="error">The error details as an instance of <see cref="LogEntry"/>.</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 11:38 AM</DateTime>
        /// </Created>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "The variable is named with camel casing which has no conflict on the preservers class name.")]
        void OnErrorRaised(LogEntry error);

        /// <summary>
        ///    Gets the cached parsed command generated from the passed Condition Table. This method needs to be implemented by the caller/consumer application.
        ///    <para>This method will be triggered only if the "CommandCached" property is marked as <c>true</c> inside the rule's JSON data.</para>
        ///    <para>This method needs to be implemented by the caller/consumer application.</para>
        /// </summary>
        /// <param name="ruleKey">The unique key of the specified rule.</param>
        /// <returns>
        ///    The cached parsed command generated from the passed JSON data.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 11:39 AM</DateTime>
        /// </Created>
        string OnGetCachedParsedCommand(string ruleKey);

        /// <summary>
        ///    Caches the execution value/result after executing a successful command generated from the specified rule.
        ///    <para>This method will be triggered only if the "ValueCached" property is marked as <c>true</c> inside the rule's JSON data.</para>
        ///    <para>The "ValueCached" property should only marked as <c>true</c> if we are pretty sure that this rule can be called over and over by the same inputs.</para>
        ///    <para>This method needs to be implemented by the caller/consumer application.</para>
        /// </summary>
        /// <param name="ruleKey">The unique key of the specified rule.</param>
        /// <param name="inputs">The inputs values to be combined with the rule key in the cache to distinguish the cached values by different inputs for the same rule.</param>
        /// <param name="ruleValue">The rule's execution/output values.</param>
        /// <param name="flushCache">if set to <c>true</c> [flush all the cached execution values for this rule].</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 11:41 AM</DateTime>
        /// </Created>
        void OnCacheExecutionValue(string ruleKey, IDictionary<string, string> inputs, List<Dictionary<string, object>> ruleValue, bool flushCache);

        /// <summary>
        ///    Called when [get the Condition Table from either some data source or cache].
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="name">The rule/condition table's name.</param>
        /// <returns>
        ///    The Condition Table from either some data source or cache.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>03/07/2020 06:09 PM</DateTime>
        /// </Created>
        ConditionTable OnGetConditionTableFromSource(string group, string name);

        /// <summary>
        ///    Gets the cached execution value/result after executing a successful command generated from the specified rule.
        ///    <para>This method will be triggered only if the "ValueCached" property is marked as <c>true</c> inside the rule's JSON data.</para>
        ///    <para>The "ValueCached" property should only marked as <c>true</c> if we are pretty sure that this rule can be called over and over by the same inputs.</para>
        ///    <para>This method needs to be implemented by the caller/consumer application.</para>
        /// </summary>
        /// <param name="ruleKey">The unique key of the specified rule.</param>
        /// <param name="inputs">The inputs values to be combined with the rule key in the cache to distinguish the cached values by different inputs for the same rule.</param>
        /// <returns>
        ///    The cached execution value/result after executing a successful command generated from the specified rule.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 11:45 AM</DateTime>
        /// </Created>
        List<Dictionary<string, object>> OnGetCachedExecutionValue(string ruleKey, IDictionary<string, string> inputs);

        /// <summary>
        ///    Executes the generated/parsed command/code from the specified rule.
        ///    <para>This method can be overridden by a derived class to change the behaviour/implementation of the method using the generated command/code by a new technique or different scripting library.</para>
        /// </summary>
        /// <param name="parsedCommand">The parsed/generated command string.</param>
        /// <returns>
        ///    The validated results as "<see cref="List{T}" />" where "T" is "<see cref="IDictionary{TKey, TValue}" />" (where "TKey" is a "<see cref="string" />" and "TValue" is an "<see cref="object" />").
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 11:49 AM</DateTime>
        /// </Created>
        protected List<Dictionary<string, object>> ExecuteCommand(string parsedCommand);
        #endregion Methods
    }
}
