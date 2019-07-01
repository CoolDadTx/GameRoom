/*
 * Copyright © 2019 Michael Taylor
 * https://www.michaeltaylorp3.net
 *
 * All Rights Reserved
 */
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3Net.GameRoom.SqlServer.Entity.ComponentModel
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    internal class DbTableAttribute : TableAttribute
    {
        public DbTableAttribute ( string tableName ) : base(tableName)
        {
            Schema = "Game";
        }
    }
}
