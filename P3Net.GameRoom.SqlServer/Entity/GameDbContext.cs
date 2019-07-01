/*
 * Copyright © 2019 Michael Taylor
 * https://www.michaeltaylorp3.net
 *
 * All Rights Reserved
 */
using System;

using Microsoft.EntityFrameworkCore;

using P3Net.GameRoom.SqlServer.Entity.Data;

namespace P3Net.GameRoom.SqlServer.Entity
{
    internal class GameDbContext : DbContext
    {
        public GameDbContext ( DbContextOptions options ) : base(options)
        { }
           
        public DbSet<GameData> Games { get; set; }
    }
}
