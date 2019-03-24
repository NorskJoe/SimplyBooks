using System;
using System.Collections.Generic;
using System.Text;

namespace SimplyBooks.Models.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {

        }

        public EntityNotFoundException(string entityName)
            : base($"'{entityName}' could not be found in the database")
        {

        }
    }
}
