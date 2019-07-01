/*
 * Copyright © 2019 Michael Taylor
 * https://www.michaeltaylorp3.net
 *
 * All Rights Reserved
 */
using System;

using P3Net.GameRoom.SqlServer.Entity.Data;

namespace P3Net.GameRoom.SqlServer.Entity.Mappings
{
    internal static class GameMappings
    {
        public static Game ToGame ( this GameData source )
        {
            if (source == null)
                return null;

            return new Game()
            {
                Id = source.Id,
                Name = source.Name
            };
        }
    }
}
