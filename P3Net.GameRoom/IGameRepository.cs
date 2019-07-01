/*
 * Copyright © 2018 Michael Taylor
 * https://www.michaeltaylorp3.net
 *
 * All Rights Reserved
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace P3Net.GameRoom
{
    /// <summary>Provides access to the games.</summary>
    public interface IGameRepository
    {
        /// <summary>Gets the games in the collection.</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The available games.</returns>
        Task<IEnumerable<Game>> GetInCollectionAsync ( CancellationToken cancellationToken );
    }
}
