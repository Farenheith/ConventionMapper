using ConventionMapper.Test.Mirrors;
using ConventionMapper.Test.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var itemCount = 1000000;
            Mapper.Load<MapperResolverTest>();
            var header = new HeaderTest()
            {
                Id = Guid.NewGuid(),
                StringField = "String value"
            };
            var items = new List<ItemTest>();
            for (var i = 0; i < itemCount; i++)
                items.Add(new ItemTest()
                {
                    Id = Guid.NewGuid(),
                    Header = header,
                    StringField = string.Format("Item {0} String value", i)
                });
            header.Items = items;

            //Act
            var moment = Stopwatch.StartNew();
            var headerMirror = Mapper.Map<HeaderTestMirror>(header);
            moment.Stop();
            //Assert
            Assert.Equal(header.Id, headerMirror.Id);
            Assert.Equal(header.StringField, headerMirror.StringField);
            Assert.Equal(itemCount, headerMirror.Items.Count);
            var itemsMirror = headerMirror.Items.ToList();
            for(var i = 0; i < itemCount; i++)
                AssertItem(items[i], headerMirror, itemsMirror[i]);
            //This test is subjective. In my machine I expect that the average elapsed time per converted
            //entity to be less than 15 ticks, but it can fail depending on the host machine or in what
            //is running at the moment
            Assert.True(15 > moment.ElapsedTicks / (itemCount + 1));
        }

        private static void AssertItem(ItemTest item, HeaderTestMirror headerMirror, ItemTestMirror itemMirror)
        {
            Assert.Equal(item.Id, itemMirror.Id);
            Assert.Equal(item.StringField, itemMirror.StringField);
            Assert.Equal(headerMirror, itemMirror.Header);
        }
    }
}
