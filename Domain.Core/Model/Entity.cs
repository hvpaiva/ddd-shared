using System;
using FluentValidation.Results;

namespace Domain.Core.Model
{
    public abstract class Entity
    {
        public Guid Id { get; }
        public ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            Id = new Guid();
            ValidationResult = new ValidationResult();
        }

        public void AdicionarErroValicacao(string erro, string descricao)
        {
            ValidationResult.Errors.Add(new ValidationFailure(erro, descricao));
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            return !ReferenceEquals(null, compareTo) && Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 232) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id = {Id}]";
        }
    }
}