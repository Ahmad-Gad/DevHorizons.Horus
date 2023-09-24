// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogEntry.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the needed members for the logged record.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@devhorizons.com)</author>
//      <datetime>05/03/2018 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Horus
{
    using System;
    using System.Diagnostics;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///    A class defines all the needed members for the logged record.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///    <DateTime>02/11/2018 05:33 PM</DateTime>
    /// </Created>
    public class LogEntry
    {
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="LogEntry"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:34 PM</DateTime>
        /// </Created>
        public LogEntry()
        {
            this.SourceMachine = System.Environment.MachineName;
            this.CreatedOn = DateTime.UtcNow;
            var stackTrace = new StackTrace();
            this.StackTrace = new StackTrace().ToString();
            this.Source = stackTrace.GetFrame(1).GetMethod().Name;
        }
        #endregion Constructors

        #region Properties

        /// <summary>
        ///    Gets or sets the log entry number.
        /// </summary>
        /// <value>
        ///    The log entry number.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:36 PM</DateTime>
        /// </Created>
        public int Number { get; set; }

        /// <summary>
        ///    Gets or sets the log level.
        /// </summary>
        /// <value>
        ///    The log level.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>14/08/2020 04:24 PM</DateTime>
        /// </Created>
        [JsonConverter(typeof(StringEnumConverter))]
        public LogLevel LogLevel { get; set; }

        /// <summary>
        ///    Gets or sets the UTC/GMT date/time of the raised log.
        /// </summary>
        /// <value>
        ///    The UTC/GMT date/time of the raised log.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>12/11/2018 02:24 PM</DateTime>
        /// </Created>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        ///    Gets or sets the action source. E.g. Specific constructor or method.
        /// </summary>
        /// <value>
        ///    The action source.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:38 PM</DateTime>
        /// </Created>
        public string Source { get; set; }

        /// <summary>
        ///    Gets or sets the entry action Description.
        /// </summary>
        /// <value>
        ///    The entry Description.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:36 PM</DateTime>
        /// </Created>
        public string Description { get; set; }

        /// <summary>
        ///    Gets or sets the log entry message.
        /// </summary>
        /// <value>
        ///    The log entry message.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:36 PM</DateTime>
        /// </Created>
        public string Message { get; set; }

        /// <summary>
        ///    Gets or sets the host environment name.
        /// </summary>
        /// <value>
        ///    The host environment name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>14/08/2020 03:11 PM</DateTime>
        /// </Created>
        public string Environment { get; set; }

        /// <summary>
        ///    Gets or sets the current request <c>URL</c> if applicable.
        /// </summary>
        /// <value>
        ///    The request <c>URL</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>13/08/2020 02:00 PM</DateTime>
        /// </Created>
        public string RequestUrl { get; set; }

        /// <summary>
        ///    Gets or sets the source machine/server name.
        /// </summary>
        /// <value>
        ///    The stack trace.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>12/11/2018 02:24 PM</DateTime>
        /// </Created>
        public string SourceMachine { get; set; }

        /// <summary>
        ///    Gets or sets the name of user who created/raised the log.
        /// </summary>
        /// <value>
        ///   The the user name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>13/08/2020 02:39 PM</DateTime>
        /// </Created>
        public string CreatedBy { get; set; }

        /// <summary>
        ///    Gets or sets the raised exception.
        /// </summary>
        /// <value>
        ///    The raised exception.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:37 PM</DateTime>
        /// </Created>
        public Exception Exception { get; set; }

        /// <summary>
        ///    Gets or sets the stack trace.
        /// </summary>
        /// <value>
        ///    The stack trace.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>12/11/2018 02:24 PM</DateTime>
        /// </Created>
        public string StackTrace { get; set; }
        #endregion Properties
    }
}