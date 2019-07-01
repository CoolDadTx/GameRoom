/*
 * Copyright © 2018 Michael Taylor
 * https://www.michaeltaylorp3.net
 *
 * All Rights Reserved
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using P3Net.GameRoom.SqlServer.Entity;
using P3Net.GameRoom.SqlServer.Entity.Mappings;

using P3Net.Kraken.Diagnostics;
using P3Net.Kraken.Linq;

namespace P3Net.GameRoom.SqlServer
{
    /// <summary>Provides an implementation of <see cref="IGameRepository"/> using SQL Server.</summary>
    public class SqlGameRepository : IGameRepository
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="SqlGameRepository"/> class.</summary>
        /// <param name="connectionString">The connection string to use.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/> is empty.</exception>
        public SqlGameRepository ( Func<DbContextOptions> options )
        {
            Verify.Argument(nameof(options)).WithValue(options).IsNotNull();

            _options = options;
        }
        #endregion

        /// <inherited />
        public async Task<IEnumerable<Game>> GetInCollectionAsync ( CancellationToken cancellationToken )
        {
            using (var context = CreateContext())
            {
                var items = await context.Games.ToListAsync(cancellationToken).ConfigureAwait(false);

                return items.Select(i => i.ToGame());
            };
        }

        #region Private Members

        private GameDbContext CreateContext () => new GameDbContext(_options());

        private readonly Func<DbContextOptions> _options;
        #endregion
    }
}
