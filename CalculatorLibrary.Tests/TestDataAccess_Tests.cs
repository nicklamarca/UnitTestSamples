using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CalculationsLibrary;
using Moq;
using System.IO;

namespace CalculatorLibrary.Tests
{
    public class TestDataAccess_Tests
    {
        [Fact]
        public void SaveText_Normal()
        {
            List<string> lines = new List<string>
            {
                "Test1",
                "Test2",
                "Test3"
            };

            string filePath = @"C:\Temp\Test.txt";
            string fileName = "Test.txt";

            var mock = new Mock<IWriteToText>();
            mock.Setup(x => x.WriteToFile(fileName, 
                                          It.IsAny<List<string>>()
                                          ))
                                         .Verifiable();

            TextDataAccess da = new TextDataAccess();

            da.SaveText(filePath, lines, mock.Object);

            mock.Verify();
        }

        [Fact]
        public void SaveText_InvalidPath_ThrowsException()
        {
            List<string> lines = new List<string>
            {
                "Test1",
                "Test2",
                "Test3"
            };

            string filePath = @"C:\Temp\Test.txlgdfghdghfdhgfdghfdghfdgfhdgfdgfdfghd
                                  hjgkjlghjhkgjhkgjkhgjhkghjgjhhjgjkgjkghjkghjkgjhkgghjt
                              hjgkjlghjhkgjhkgjkhgjhkghjgjhhjgjkgjkghjkghjkgjhkgghjt
                              hjgkjlghjhkgjhkgjkhgjhkghjgjhhjgjkgjkghjkghjkgjhkgghjthjgkjlghjhkgjhkgjkhgjhkghjgjhhjgjkgjkghjkghjkgjhkgghjt";

            string fileName = "Test.txt";

            var mock = new Mock<IWriteToText>();
            mock.Setup(x => x.WriteToFile(fileName,
                                          It.IsAny<List<string>>()
                                          ))
                                         .Verifiable();

            TextDataAccess da = new TextDataAccess();

            Assert.Throws<PathTooLongException>(
                          () => da.SaveText(filePath, lines, mock.Object));

        }
    }
}
