using System;

namespace SimplyBooks.Models.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException()
        {

        }

        public EntityAlreadyExistsException(string entityName)
            : base($"'{entityName}' already exists")
        {

        }
    }
}
