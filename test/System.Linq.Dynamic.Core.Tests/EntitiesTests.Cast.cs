﻿using Xunit;

namespace System.Linq.Dynamic.Core.Tests
{
    public partial class EntitiesTests
    {
        // [Fact] https://github.com/StefH/System.Linq.Dynamic.Core/issues/44
        public void Cast_To_nullableint()
        {
            // Arrange
            PopulateTestData(1, 0);

            // Act
            var expectedResult = _context.Blogs.Select(b => (int?)b.BlogId);
            var result = _context.Blogs.AsQueryable().Select("int?(BlogId)");

            // Assert
            Assert.Equal(expectedResult.ToArray(), result.ToDynamicArray<int?>());
        }

        // [Fact] https://github.com/StefH/System.Linq.Dynamic.Core/issues/44
        public void Cast_To_newnullableint()
        {
            // Arrange
            PopulateTestData(1, 0);

            // Act
            var expectedResult = _context.Blogs.Select(x => new { i = (int?)x.BlogId });
            var result = _context.Blogs.AsQueryable().Select("new (int?(BlogId) as i)");
           
            //Assert
            Assert.Equal(expectedResult.Count(), result.Count());
        }
    }
}