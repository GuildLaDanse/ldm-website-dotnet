﻿using System;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.CharacterClaims
{
    public partial class GameCharacterClaimVersion : IBaseEntity<Guid>, ITemporalEntity
    {
        public Guid Id { get; set; }
        
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }

        public string Comment { get; set; }
        public bool IsRaider { get; set; }

        public Guid GameCharacterClaimId { get; set; }
        public virtual GameCharacterClaim GameCharacterClaim { get; set; }
    }
}
