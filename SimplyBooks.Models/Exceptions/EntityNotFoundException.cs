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
            : base($"'{entityName}' could not be found")
        {

        }

        public EntityNotFoundException(int entityId, string entityTypeName)
            : base($"A {entityTypeName} with an ID of {entityId} could not be found")
        {

        }

        public EntityNotFoundException(DateTime searchDate, string entityTypeName)
            : base($"A {entityTypeName} matching the year {searchDate.Year} could not be found")
        {

        }
    }
}
