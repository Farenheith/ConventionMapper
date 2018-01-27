using ConventionMapper.Test.Mirrors;
using ConventionMapper.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ConventionMapper.Test
{
    public class MapperResolverTest
    {
        [Fact]
        public void Get_Success()
        {
            //Arrange
            Mapper.Load<MapperResolverTest>();
            var header = new HeaderTest()
            {
                Id = Guid.NewGuid(),
                StringField = "String value"
            };
            var items = new List<ItemTest>()
            {
                new ItemTest()
                {
                    Id = Guid.NewGuid(),
                    Header = header,
                    StringField = "Item 1 String value"
                },
                new ItemTest()
                {
                    Id = Guid.NewGuid(),
                    Header = header,
                    StringField = "Item 2 String value"
                }
            };
            header.Items = items;

            //Act
            var headerMirror = Mapper.Map<HeaderTestMirror>(header);

            //Assert
            Assert.Equal(header.Id, headerMirror.Id);
            Assert.Equal(header.StringField, headerMirror.StringField);
            Assert.Equal(header.Items.Count, headerMirror.Items.Count);
            var itemsMirror = headerMirror.Items.ToList();
            AssertItem(items[0], headerMirror, itemsMirror[0]);
            AssertItem(items[1], headerMirror, itemsMirror[1]);
        }

        private static void AssertItem(ItemTest item, HeaderTestMirror headerMirror, ItemTestMirror itemMirror)
        {
            Assert.Equal(item.Id, itemMirror.Id);
            Assert.Equal(item.StringField, itemMirror.StringField);
            Assert.Equal(headerMirror, itemMirror.Header);
        }
    }
}
