// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
// </copyright>
//  <summary>
//     This file is used by Code Analysis to maintain SuppressMessage attributes that are applied to this project.
//     Project-level suppressions either have no target or are given a specific target and scoped to a namespace, type, member, etc.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@devhorizons.com)</author>
//      <datetime>03/07/2019 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "The specific exception has been already handeled.", Scope = "type", Target = "~T:DevHorizons.Horus.Engine.Invoker")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "There is no need for localization as this is designed for error logging only.", Scope = "type", Target = "~T:DevHorizons.Horus.Engine.Invoker")]
[assembly: SuppressMessage("StyleCop.Engine.ReadabilityRules", "SA1124:Do not use regions", Justification = "There is no wrong from using regions!", Scope = "type", Target = "~T:DevHorizons.Horus.Engine.Invoker")]
[assembly: SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "I need it to be lowercase!", Scope = "member", Target = "~M:DevHorizons.Horus.Engine.Invoker.GetDefaultValue(System.String,System.Object)~System.Object")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "The validation would be already handled with the caller method", Scope = "member", Target = "~M:DevHorizons.Horus.Abstract.Invoker.GetRuleKey(DevHorizons.Horus.Model.ConditionTable)~System.String")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "The validation would be already handled with the caller method", Scope = "member", Target = "~M:DevHorizons.Horus.Abstract.Invoker.GetRuleKey(System.String,System.String)~System.String")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "The validation would be already handled with the caller method", Scope = "member", Target = "~M:DevHorizons.Horus.Interfaces.IInvoker.GetRuleKey(DevHorizons.Horus.Model.ConditionTable)~System.String")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "The validation would be already handled with the caller method", Scope = "member", Target = "~M:DevHorizons.Horus.Interfaces.IInvoker.GetRuleKey(System.String,System.String)~System.String")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "This file will be injected as plugin in the runtime and not meant to be shared in public with other libraries.", Scope = "type", Target = "~T:DevHorizons.Horus.Engine.Plugins.ExtensionMethods")]
