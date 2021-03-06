﻿using System;
using LaDanse.Domain.Entities.GameData.Core;
using LaDanse.Domain.Entities.Shared;

namespace LaDanse.Domain.Entities.GameData.Characters
{
    public partial class GameCharacter : IBaseEntity<Guid>, ITimeVersionedEntity
    {
        public Guid Id { get; set; }
        
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        
        public string Name { get; set; }
        
        public Guid GameRealmId { get; set; }
        public virtual GameRealm GameRealm { get; set; }
    }
}
