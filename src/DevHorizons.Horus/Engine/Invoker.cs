// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Invoker.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
// </copyright>
//  <summary>
//    Defines the required members for the invoker class.
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
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Internal;
    using Model;
    using Newtonsoft.Json;
    using Plugins;

    /// <summary>
    ///    The dynamic rules generator and invoker class.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///    <DateTime>18/02/2020 12:45 PM</DateTime>
    /// </Created>
    /// <seealso cref="DevHorizons.Horus.Abstract.Invoker" />
    public class Invoker : Abstract.Invoker
    {
        #region Constant Fields

        /// <summary>
        ///    The delimiter character to terminate/separate the script command lines.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 01:58 PM</DateTime>
        /// </Created>
        private const char Delimiter = ';';
        #endregion Constant Fields

        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="Invoker"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>02/07/2020 11:41 AM</DateTime>
        /// </Created>
        public Invoker()
        {
        }
        #endregion Constructors

        #region Properties
        #endregion Properties

        #region Public Methods

        /// <summary>
        ///    Executes the rule and return the validated results as "<see cref="List{T}" />" where "T" is "<see cref="IDictionary{TKey, TValue}" />" (where "TKey" is a "<see cref="string" />" and "TValue" is an "<see cref="object" />").
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="name">The name of the rule to be executed.</param>
        /// <param name="inputs">The inputs data as "<see cref="IDictionary{TKey, TValue}" />" where "TKey" is a "<see cref="string" />" and "TValue" is an "<see cref="string" />". Those inputs names must be covered inside the specified rule in the "Inputs" section.</param>
        /// <returns>
        ///    The validated results as "<see cref="IDictionary{TKey, TValue}" />" where "TKey" is a "<see cref="string" />" and "TValue" is an "<see cref="string" />".
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 11:30 AM</DateTime>
        /// </Created>
        public override List<Dictionary<string, object>> ExecuteRule(string group, string name, IDictionary<string, string> inputs)
        {
            if (string.IsNullOrWhiteSpace(group) || string.IsNullOrWhiteSpace(name))
            {
                var serializedInputs = JsonConvert.SerializeObject(inputs);
                var error = new LogEntry
                {
                    Description = "ExecuteRule | Properties Values Missing",
                    Message = $"The following properties cannot be null or empty: group, name: {group} | Rule Name: {name} | User Inputs: {serializedInputs}",
                    Number = 3
                };

                this.HandleError(error);
                return null;
            }

            var ruleKey = GetRuleKey(group, name);

            var cachedValue = this.InvokeGetCachedExecutionValue(ruleKey, inputs);
            if (cachedValue != null && cachedValue.Count > 0)
            {
                return cachedValue;
            }

            var ct = this.InvokeGetConditionTableFromSource(group, name);

            if (ct == null)
            {
                var error = new LogEntry
                {
                    Description = "Could not find the specified rule name",
                    Message = $"The rule [{name}] not found!",
                    Number = 3
                };

                this.HandleError(error);
                return null;
            }

            ct.Group = group.ToUpperInvariant();
            return this.ExecuteRule(ct, inputs);
        }

        /// <summary>
        /// Executes the rule and return the output values as "<see cref="List{T}" />" where "T" is "<see cref="IDictionary{TKey, TValue}" />" (where "TKey" is a "<see cref="string" />" and "TValue" is an "<see cref="object" />").
        /// </summary>
        /// <param name="conditionTable">The condition table.</param>
        /// <param name="inputs">The inputs.</param>
        /// <returns>
        /// The validated results as "<see cref="IDictionary{TKey, TValue}" />" where "TKey" is a "<see cref="string" />" and "TValue" is an "<see cref="object" />".
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>08/10/2020 11:10 PM</DateTime>
        /// </Created>
        public override List<Dictionary<string, object>> ExecuteRule(ConditionTable conditionTable, IDictionary<string, string> inputs)
        {
            if (conditionTable == null)
            {
                var error = new LogEntry
                {
                    Description = $"{nameof(this.ExecuteRule)} | conditionTable is null",
                    Message = $"The conditionTable cannot be null.",
                    Number = 3
                };

                this.HandleError(error);
                return null;
            }

            if (string.IsNullOrWhiteSpace(conditionTable.Group) || string.IsNullOrWhiteSpace(conditionTable.Name))
            {
                var serializedInputs = inputs == null ? null : JsonConvert.SerializeObject(inputs);
                var error = new LogEntry
                {
                    Description = "ExecuteRule | Properties Values Missing",
                    Message = $"The following properties cannot be null or empty: group, name: {conditionTable.Group} | Rule Name: {conditionTable.Name} | User Inputs: {serializedInputs}",
                    Number = 3
                };

                this.HandleError(error);
                return null;
            }

            var ruleKey = GetRuleKey(conditionTable);

            var parsedCommand = this.GetFinalParsedCommand(conditionTable, inputs, ruleKey);

            if (string.IsNullOrEmpty(parsedCommand))
            {
                return new List<Dictionary<string, object>>();
            }

            var returnValue = this.ExecuteCommand(parsedCommand);
            if (conditionTable.ValueCached)
            {
                this.InvokeCacheExecutionValue(ruleKey, inputs, returnValue, conditionTable.ResetCache);
            }

            conditionTable.ResetCache = false;
            return returnValue;
        }
        #endregion Public Methods

        #region Virtual Methods

        /// <summary>
        ///    Executes the generated/parsed command/code from the specified rule.
        ///    <para>This method can be overridden by a derived class to change the behaviour/implementation of the method using the generated command/code by a new technique or different scripting library.</para>
        /// </summary>
        /// <param name="parsedCommand">The parsed/generated command string.</param>
        /// <returns>
        ///    The validated results as "<see cref="IDictionary{TKey, TValue}"/>" where "TKey" is a "<see cref="string"/>" and "TValue" is an "<see cref="object"/>".
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 11:49 AM</DateTime>
        /// </Created>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "There is no specific typed exception class to handle rather than the general one.")]
        protected virtual List<Dictionary<string, object>> ExecuteCommand(string parsedCommand)
        {
            LogEntry error = null;
            try
            {
                var cmd = new Command();
                var result = cmd.InvokeCommand(parsedCommand);

                if (result == null)
                {
                    error = new LogEntry
                    {
                        Description = "The command has been executed without exception but the result is null.",
                        Message = $"Failed to fetch the results from the executed command: [{parsedCommand}].",
                        Number = 3
                    };

                    return null;
                }

                var dicList = (List<Dictionary<string, object>>)result;
                return dicList;
            }
            catch (Exception ex)
            {
                error = new LogEntry
                {
                    Description = $"An exception has been raised while attempting to execute the parsed command: [{parsedCommand}].",
                    Message = ex.Message,
                    Exception = ex,
                    StackTrace = ex.StackTrace,
                    Number = 3
                };

                return null;
            }
            finally
            {
                this.HandleError(error);
            }
        }
        #endregion Virtual Methods

        #region Private Methods
        #region Static Methods

        /// <summary>
        ///    Gets the result/outputs of the executed command as a dictionary.
        /// </summary>
        /// <param name="outputs">The outputs.</param>
        /// <returns>The result/outputs of the executed command.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 01:39 PM</DateTime>
        /// </Created>
        private static string GetOutputsDictionary(List<Variable> outputs)
        {
            if (outputs == null || outputs.Count == 0)
            {
                return string.Empty;
            }

            var str = new StringBuilder();
            str.Append("var dic = new System.Collections.Generic.Dictionary<string,object>();");
            foreach (var variable in outputs)
            {
                str.Append($"dic[\"{variable.Name}\"] = {variable.Name};");
            }

            str.Append("var lstDic = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> { dic };");
            str.Append("return lstDic;");
            return str.ToString();
        }

        /// <summary>
        ///    Gets the parsed inputs command/script to be injected to the final command text.
        /// </summary>
        /// <param name="inputsValues">The inputs values.</param>
        /// <param name="ct">The rule.</param>
        /// <param name="assignDefault">if set to <c>true</c> don't validate for the input values and assign the default values.</param>
        /// <returns>The parsed inputs command/script to be injected to the final command text.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 01:40 PM</DateTime>
        /// </Created>
        private static string GetInputsAssignCommand(IDictionary<string, string> inputsValues, ConditionTable ct, bool assignDefault = false)
        {
            if (ct == null || ct.Inputs == null)
            {
                return string.Empty;
            }

            if (!assignDefault && (inputsValues == null || inputsValues.Count == 0))
            {
                return string.Empty;
            }

            AssignDefaultValues(inputsValues, ct);
            return GetVariablesDeclarations(ct.Inputs);
        }

        /// <summary>
        ///    Assigns the default values from the specified inputs Values.
        /// </summary>
        /// <param name="inputsValues">The inputs values.</param>
        /// <param name="ct">The condition table.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>28/01/2021 03:35 PM</DateTime>
        /// </Created>
        private static void AssignDefaultValues(IDictionary<string, string> inputsValues, ConditionTable ct)
        {
            foreach (var input in ct.Inputs)
            {
                input.Name = input.Name.ToUpperInvariant();
                input.DefaultValue = GetAssignedInputValue(input, inputsValues);
            }
        }

        /// <summary>
        ///    Gets the assigned input value from the specified inputs Value. If not specified or the mapped variable not found, it will return the default value or null if allows null.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="inputsValues">The inputs values.</param>
        /// <returns>
        ///    The assigned input value from the specified inputs Value, default value or null.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>28/01/2021 03:19 PM</DateTime>
        /// </Created>
        private static string GetAssignedInputValue(Variable input, IDictionary<string, string> inputsValues)
        {
            var varName = inputsValues == null || inputsValues.Count == 0 ? null : inputsValues.Keys.FirstOrDefault(k => k.Equals(input.Name, StringComparison.OrdinalIgnoreCase));

            if (varName.IsNull())
            {
                if (input.DefaultValue.IsNullOrEmpty())
                {
                    return input.AllowNull ? "$null" : "$default";
                }
                else
                {
                    return input.DefaultValue;
                }
            }
            else
            {
                return inputsValues[varName];
            }
        }

        /// <summary>
        ///    Gets the condition table operations as generated command script text to be injected to the final generated script.
        /// </summary>
        /// <param name="ct">The condition table.</param>
        /// <returns>The condition table operations as generated command script text.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>17/06/2020 01:56 PM</DateTime>
        /// </Created>
        private static string GetConditionTableParsedCommand(ConditionTable ct)
        {
            return ct.TwoDimResults ? GetConditionTableParsedCommandTwoDim(ct) : GetConditionTableParsedCommandOneDim(ct);
        }

        /// <summary>
        ///    Gets the condition table operations as generated command script text with one/mono result only to be injected to the final generated script.
        /// </summary>
        /// <param name="ct">The condition table.</param>
        /// <returns>The condition table operations as generated command script text.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>17/06/2020 01:56 PM</DateTime>
        /// </Created>
        private static string GetConditionTableParsedCommandOneDim(ConditionTable ct)
        {
            if (ct == null)
            {
                return string.Empty;
            }

            var str = new StringBuilder();
            ct.Inputs.ForEach(i => i.Name = i.Name.ToUpperInvariant());

            var outputs = GetVariablesDeclarations(ct.Outputs);
            str.Append(outputs);

            var conditionString = new StringBuilder();
            var dicString = new StringBuilder("var dic = new Dictionary<string, object>();");
            conditionString.Append(" if (");
            for (var i = 0; i < ct.Decisions.Count; i++)
            {
                if (i != 0)
                {
                    conditionString.Append(" else if (");
                }

                var decision = ct.Decisions[i];

                var outputVariableString = new StringBuilder();
                var joinConditions = true;
                for (var j = 0; j < decision.Conditions.Count; j++)
                {
                    if (string.IsNullOrWhiteSpace(decision.Conditions[j]))
                    {
                        joinConditions = false;
                        continue;
                    }

                    var inputVariable = ct.Inputs[j].Name;
                    var validatedValue = decision.Conditions[j].ToString().Trim();
                    if (ct.Inputs[j].Type.Equals(nameof(DateTime), StringComparison.OrdinalIgnoreCase) && validatedValue.Contains('#', StringComparison.InvariantCulture))
                    {
                        validatedValue = validatedValue.ReplaceMaskedDateTime();
                    }

                    if (j == 0)
                    {
                        conditionString.Append($"{inputVariable}{validatedValue}");
                    }
                    else
                    {
                        var andOp = joinConditions ? " && " : string.Empty;
                        conditionString.Append($"{andOp}{inputVariable}{validatedValue}");
                    }

                    joinConditions = true;
                }

                for (var j = 0; j < ct.Outputs.Count; j++)
                {
                    var outputVariable = ct.Outputs[j].Name;
                    var returnValue = GetDefaultValue(ct.Outputs[j].Type, decision.Return[j]);
                    outputVariableString.Append($"{outputVariable} = {returnValue};");
                    dicString.Append($"dic[\"{outputVariable}\"] = {outputVariable};");
                }

                conditionString.Append($"){{{outputVariableString}}}");
            }

            str.Append(conditionString);
            str.Append(dicString);
            str.Append("var lstDic = new List<Dictionary<string, object>> { dic };");
            str.Append("return lstDic;");
            return str.ToString();
        }

        /// <summary>
        ///    Gets the condition table operations as generated command script text as mutiple (two dimensional) results to be injected to the final generated script.
        /// </summary>
        /// <param name="ct">The condition table.</param>
        /// <returns>The condition table operations as generated command script text.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>17/06/2020 01:56 PM</DateTime>
        /// </Created>
        private static string GetConditionTableParsedCommandTwoDim(ConditionTable ct)
        {
            if (ct == null)
            {
                return string.Empty;
            }

            var str = new StringBuilder();
            str.Append("var lstDic = new List<Dictionary<string, object>>();");
            ct.Inputs.ForEach(i => i.Name = i.Name.ToUpperInvariant());

            var outputs = GetVariablesDeclarations(ct.Outputs);
            str.Append(outputs);

            for (var i = 0; i < ct.Decisions.Count; i++)
            {
                var conditionString = new StringBuilder();
                var outputVariableString = new StringBuilder();
                conditionString.Append(" if (");
                var decision = ct.Decisions[i];

                var joinConditions = true;
                for (var j = 0; j < decision.Conditions.Count; j++)
                {
                    if (string.IsNullOrWhiteSpace(decision.Conditions[j]))
                    {
                        joinConditions = false;
                        continue;
                    }

                    var inputVariable = ct.Inputs[j].Name;
                    var validatedValue = decision.Conditions[j].ToString().Trim();
                    if (ct.Inputs[j].Type.Equals(nameof(DateTime), StringComparison.OrdinalIgnoreCase) && validatedValue.Contains('#', StringComparison.InvariantCulture))
                    {
                        validatedValue = validatedValue.ReplaceMaskedDateTime();
                    }

                    if (j == 0)
                    {
                        conditionString.Append($"{inputVariable}{validatedValue}");
                    }
                    else
                    {
                        var andOp = joinConditions ? " && " : string.Empty;
                        conditionString.Append($"{andOp}{inputVariable}{validatedValue}");
                    }

                    joinConditions = true;
                }

                for (var j = 0; j < ct.Outputs.Count; j++)
                {
                    var outputVariable = ct.Outputs[j].Name;
                    var returnValue = GetDefaultValue(ct.Outputs[j].Type, decision.Return[j]);
                    outputVariableString.Append($"{outputVariable} = {returnValue};");
                    outputVariableString.Append($"dic[\"{outputVariable}\"] = {outputVariable};");
                }

                conditionString.Append($"){{var dic = new Dictionary<string, object>();{outputVariableString}lstDic.Add(dic);}}");
                str.Append(conditionString);
            }

            str.Append("return lstDic;");
            return str.ToString();
        }

        /// <summary>
        ///    Gets the parsed variables command/script to be injected to the final command text.
        /// </summary>
        /// <param name="variables">The variables.</param>
        /// <returns>
        /// The parsed variables command/script to be injected to the final command text.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>18/02/2020 01:41 PM</DateTime>
        /// </Created>
        private static string GetVariablesDeclarations(List<Variable> variables)
        {
            if (variables == null || variables.Count == 0)
            {
                return string.Empty;
            }

            var str = new StringBuilder();

            foreach (var v in variables)
            {
                var varType = v.Type.Trim();
                if (v.AllowNull)
                {
                    varType += '?';
                }

                str.Append($"{varType} {v.Name}");
                if (v.DefaultValue == null)
                {
                    str.Append(Delimiter);
                }
                else
                {
                    var defaultValue = GetDefaultValue(v.Type, v.DefaultValue);
                    str.Append($"={defaultValue}{Delimiter}");
                }
            }

            return str.ToString();
        }

        /// <summary>
        ///    Gets the default value.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        ///    The default parsed value.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///   <DateTime>02/07/2020 09:56 PM</DateTime>
        /// </Created>
        private static object GetDefaultValue(string type, object value)
        {
            var defaultValue = value;
            if (value.ToString().Trim() == "$null")
            {
                defaultValue = "null";
            }
            else if (value.ToString().Trim().StartsWith('$'))
            {
                defaultValue = value.ToString().Trim().TrimStart('$');
            }
            else if (type.Equals(nameof(DateTime), StringComparison.OrdinalIgnoreCase))
            {
                defaultValue = $"Convert.ToDateTime(\"{value}\")";
            }
            else if (type.Equals(nameof(Boolean), StringComparison.OrdinalIgnoreCase) || type.Equals("bool", StringComparison.OrdinalIgnoreCase))
            {
                defaultValue = value.ToString().ToLower(CultureInfo.InvariantCulture);
            }
            else if (type.Equals(nameof(String), StringComparison.OrdinalIgnoreCase))
            {
                defaultValue = $"\"{value}\"";
            }
            else if (type.Equals(nameof(Char), StringComparison.OrdinalIgnoreCase))
            {
                defaultValue = $"'{value}'";
            }
            else if (type.Equals(nameof(Decimal), StringComparison.OrdinalIgnoreCase))
            {
                defaultValue = value.ToString().Trim().EndsWith("M", StringComparison.OrdinalIgnoreCase) ? value : $"{value.ToString().Trim()}M";
            }
            else if (type.Equals("float", StringComparison.OrdinalIgnoreCase) || type.Equals(nameof(Single), StringComparison.OrdinalIgnoreCase))
            {
                defaultValue = value.ToString().Trim().EndsWith("F", StringComparison.OrdinalIgnoreCase) ? value : $"{value.ToString().Trim()}F";
            }

            return defaultValue;
        }
        #endregion Static Methods

        /// <summary>
        ///    Gets the final parsed/generated command script.
        /// </summary>
        /// <param name="ct">The rule.</param>
        /// <param name="inputs">The inputs.</param>
        /// <param name="ruleKey">The rule key.</param>
        /// <returns>
        ///    The final parsed/generated command script.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 01:39 PM</DateTime>
        /// </Created>
        private string GetFinalParsedCommand(ConditionTable ct, IDictionary<string, string> inputs, string ruleKey)
        {
            var inputsOps = GetInputsAssignCommand(inputs, ct, true);

            if (ct.CommandCached && !ct.ResetCache)
            {
                var parsedCommand = this.InvokeGetCachedParsedCommand(ruleKey);

                if (!string.IsNullOrEmpty(parsedCommand))
                {
                    return inputsOps + parsedCommand;
                }
            }

            var operations = GetConditionTableParsedCommand(ct);

            if (ct.CommandCached)
            {
                this.InvokeCacheParsedCommand(ruleKey, operations);
            }

            var allOperations = inputsOps + operations;

            return allOperations;
        }
        #endregion Private Methods
    }
}
