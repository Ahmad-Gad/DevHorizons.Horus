// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommand.cs" company="DevHorizons">
// Copyright (c) DevHorizons. All rights reserved.
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
    /// <summary>
    ///    An interface holds the required members for the command template.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///    <DateTime>19/02/2020 09:59 AM</DateTime>
    /// </Created>
    internal interface ICommand
    {
        /// <summary>
        ///    Invokes the generated/parses command string and return the result as object value.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns>The result of the invoked command.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>19/02/2020 09:58 AM</DateTime>
        /// </Created>
        object InvokeCommand(string cmd);
    }
}
