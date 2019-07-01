/*
 * Copyright © 2018 Michael Taylor
 * https://www.michaeltaylorp3.net
 *
 * All Rights Reserved
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace P3Net.GameRoom
{
    /// <summary>A game and its core data.</summary>
    [DebuggerDisplay("{Name} [{Id}]")]
    public class Game
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public override string ToString () => Name ?? "";
    }
}
