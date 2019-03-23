using System;

namespace SimplyBooks.Models.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        private string errorMessage;

        public EntityAlreadyExistsException()
        {

        }

        public EntityAlreadyExistsException(string entityName)
        {
            errorMessage = $"{entityName} already exists in the database";
        }

        public override string Message
        {
            get
            {
                return errorMessage;
            }
        }
    }
}
