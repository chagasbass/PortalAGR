using Flunt.Notifications;
using MongoDB.Bson;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PortalAGR.Shared.Entities
{
    public abstract class Entity : Notifiable<Notification>, IEquatable<Entity>
    {
        public ObjectId Id { get; private set; }

        protected Entity() { }

        public bool Equals([AllowNull] Entity other)
            => Id == other.Id;
    }
}