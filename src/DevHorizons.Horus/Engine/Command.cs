// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Command.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
// </copyright>
//  <summary>
//    Defines the required members for the <c>CSharp</c> command class.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//    <DateTime>14/02/2020 11:00 AM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Horus.Engine
{
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Internal;
    using Microsoft.CodeAnalysis.CSharp.Scripting;
    using Microsoft.CodeAnalysis.Scripting;

    /// <summary>
    ///    A class the holds all the required members for the <c>CSharp</c> command class.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///    <DateTime>18/02/2020 05:29 PM</DateTime>
    /// </Created>
    /// <seealso cref="DevHorizons.Horus.Internal.ICommand" />
    internal class Command : ICommand
    {
        /// <summary>
        ///    The options with the required Namespaces references for the Rosylyn script creation.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>14/02/2020 11:00 AM</DateTime>
        /// </Created>
        private readonly ScriptOptions scriptOptions;

        /// <summary>
        ///    The plugins extracted code string.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>17/06/2020 04:40 PM</DateTime>
        /// </Created>
        private readonly string plugins;

        /// <summary>
        ///    Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 05:29 PM</DateTime>
        /// </Created>
        internal Command()
        {
            this.plugins = GetPluginsCodeString();
            this.scriptOptions = ScriptOptions.Default.WithReferences(Assembly.GetExecutingAssembly())
                .AddReferences("System", "System.Collections", "System.Collections.Generic", "System.Linq")
                .AddImports("System", "System.Collections", "System.Collections.Generic", "System.Linq", "DevHorizons.Horus.Engine.Plugins");
        }

        /// <summary>
        ///    Invokes the specified <c>C#</c> command/script text in the runtime.
        /// </summary>
        /// <param name="cmd">The command/script text to be executed in the runtime.</param>
        /// <returns>The return object as the result of the command execution in the runtime.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>18/02/2020 05:30 PM</DateTime>
        /// </Created>
        public object InvokeCommand(string cmd)
        {
            var script = CSharpScript.Create(code: this.plugins, options: this.scriptOptions).ContinueWith(cmd);
            var result = script.RunAsync().Result;
            return result?.ReturnValue;
        }

        /// <summary>
        ///    Gets the plugins code string.
        /// </summary>
        /// <returns>The plugins code string.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>17/06/2020 03:55 PM</DateTime>
        /// </Created>
        private static string GetPluginsCodeString()
        {
            var str = new StringBuilder();
            var appPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Engine\\Plugins";
            if (!Directory.Exists(appPath))
            {
                return str.ToString();
            }

            var fileEntries = Directory.GetFiles(appPath);
            foreach (var file in fileEntries)
            {
                var fc = File.ReadAllText(file);
                fc = fc.Replace("\r\n", string.Empty, System.StringComparison.Ordinal).Replace("\t", string.Empty, System.StringComparison.Ordinal).Replace("    ", " ", System.StringComparison.Ordinal);
                str.Append(fc);
            }

            return str.ToString();
        }
    }
}
