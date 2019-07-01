/*
 * Copyright © 2019 Michael Taylor
 * https://www.michaeltaylorp3.net
 *
 * All Rights Reserved
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using P3Net.GameRoom.SqlServer.Entity.ComponentModel;

namespace P3Net.GameRoom.SqlServer.Entity.Data
{
    [DbTable("Games")]
    [DebuggerDisplay("{Name} [{Id}]")]
    internal class GameData
    {
        [Key]
        [Column("GameId")]
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
