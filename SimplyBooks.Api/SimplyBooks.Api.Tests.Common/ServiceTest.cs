using Moq;
using SimplyBooks.Repository.Commands.Authors;
using SimplyBooks.Repository.Queries.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplyBooks.Api.Tests.Common
{
    public class ServiceTest<T>
    {
        public T Service { get; set; }
        public Mock<IAddAuthorCommand> AddAuthorCommandMock { get; protected set; }
        public Mock<IUpdateAuthorCommand> UpdateAuthorCommandMock { get; protected set; }
        public Mock<IListAuthorsQuery> ListAuthorsQueryMock { get; protected set; }
        public Mock<IAuthorSelectListQuery> AuthorSelectListQueryMock { get; protected set; }

        public ServiceTest()
        {
            AddAuthorCommandMock = new Mock<IAddAuthorCommand>();
            UpdateAuthorCommandMock = new Mock<IUpdateAuthorCommand>();
            ListAuthorsQueryMock = new Mock<IListAuthorsQuery>();
            AuthorSelectListQueryMock = new Mock<IAuthorSelectListQuery>();
        }
    }
}
