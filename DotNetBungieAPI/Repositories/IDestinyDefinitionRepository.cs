﻿using DotNetBungieAPI.Models;

namespace DotNetBungieAPI.Repositories;

/// <summary>
///     An interface for accessing <see cref="DestinyDefinitionTypeRepository" />
/// </summary>
public interface IDestinyDefinitionRepository
{
    /// <summary>
    ///     Type of items stored inside of repository
    /// </summary>
    Type DefinitionType { get; init; }

    /// <summary>
    ///     Adds new item into the repository
    /// </summary>
    /// <param name="definition">Definition to add</param>
    /// <returns>True, if successful, False, otherwise</returns>
    bool Add(IDestinyDefinition definition);

    /// <summary>
    ///     Removes item from repository
    /// </summary>
    /// <param name="hash">Hash ID of the item</param>
    /// <returns>True, if successfull, False, otherwise</returns>
    bool Remove(uint hash);

    /// <summary>
    ///     Gets definition with given hash ID
    /// </summary>
    /// <param name="hash">Hash ID of the item</param>
    /// <param name="definition">Found item</param>
    /// <returns>True, if successfull, False, otherwise</returns>
    bool TryGetDefinition(uint hash, out IDestinyDefinition definition);

    /// <summary>
    ///     Fetches all items from repository as <see cref="IEnumerable{IDestinyDefinition}" />
    /// </summary>
    /// <returns>
    ///     <see cref="IEnumerable{IDestinyDefinition}" />
    /// </returns>
    IEnumerable<IDestinyDefinition> GetAll();

    /// <summary>
    ///     Searches through all items with give predicate
    /// </summary>
    /// <param name="predicate">Search condition</param>
    /// <returns>
    ///     <see cref="IEnumerable{IDestinyDefinition}" />
    /// </returns>
    IEnumerable<IDestinyDefinition> Where(Func<IDestinyDefinition, bool> predicate);

    void SortByIndex();
}
