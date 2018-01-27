using ConventionMapper.Generator;
using ConventionMapper.Test.Models.Base;
using ConventionMapper.Test.Mirrors.Base;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using System.IO;

namespace ConventionMapper.Test
{
    public class MappingGeneratorTest
    {
        [Fact]
        public void Get_Success()
        {
            //Arrange
            var modelToMirror = MappingGenerator.Create<BaseTest, BaseTestMirror>("Mirror", AcessibilityLevelEnum.@internal);
            var mirrorToModel = modelToMirror.GetReverse("Model");
            var mirrorToModelPublic = modelToMirror.GetReverse("ModelPublic", AcessibilityLevelEnum.@public);
            var dir1 = Path.Combine(Directory.GetCurrentDirectory(), "output\\MirrorMappings\\");
            var dir2 = Path.Combine(Directory.GetCurrentDirectory(), "output\\ModelMappings\\");
            var dir3 = Path.Combine(Directory.GetCurrentDirectory(), "output\\ModelPublicMappings\\");
            if (Directory.Exists(dir1)) Directory.Delete(dir1, true);
            if (Directory.Exists(dir2)) Directory.Delete(dir2, true);
            if (Directory.Exists(dir3)) Directory.Delete(dir3, true);

            //Act
            var result1 = modelToMirror.Generate();
            var result2 = mirrorToModel.Generate();
            var result3 = mirrorToModelPublic.Generate();

            //Assert
            AssertDirectory(result1);
            AssertDirectory(result2);
            AssertDirectory(result3);

        }

        private static void AssertDirectory(string directory)
        {
            Assert.NotNull(directory);
            Assert.True(Directory.Exists(directory));
            Assert.True(Directory.EnumerateFiles(directory).Count() > 0);
        }
    }
}
