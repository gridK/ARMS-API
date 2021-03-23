using System;

namespace AUroomAPI.Models.DataModels
{
    public abstract class Entity
    {
        public virtual void OnBeforeInsert(string by) { }
        public virtual void OnBeforeUpdate(string by) { }
    }
}
