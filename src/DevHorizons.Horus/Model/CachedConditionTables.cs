// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CachedConditionTables.cs" company="DevHorizons">
// Copyright (c) DevHorizons. All rights reserved.
// </copyright>
//  <summary>
//    Defines the required members for the container of the cached condition tables in the memory.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//    <DateTime>02/07/2020 01:27 PM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Horus.Model
{
    using System.Collections.Generic;

    /// <summary>
    ///    The container of the cached condition tables in the memory.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///    <DateTime>02/07/2020 01:27 PM</DateTime>
    /// </Created>
    public class CachedConditionTables
    {
        /// <summary>
        ///    Gets the list of the rules structures.
        /// </summary>
        /// <value>
        /// The rules.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///    <DateTime>19/02/2020 10:44 AM</DateTime>
        /// </Created>
        public Dictionary<string, List<ConditionTable>> ConditionTables { get; private set; } = new Dictionary<string, List<ConditionTable>>();
    }
}
