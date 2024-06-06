using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.IO;
using Xunit;

namespace MultiplicationMatrixApp.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void TestInvalidInputForX()
        {
            // Arrange
            var input = "abc\n2\n";
            var output = new StringWriter();
            Console.SetIn(new StringReader(input));
            Console.SetOut(output);

            // Act
            Program.Main(new string[] { });

            // Assert
            Assert.Contains("Некорректный ввод. Введите целое число.", output.ToString());
        }

        [Fact]
        public void TestInvalidInputForY()
        {
            // Arrange
            var input = "3\nabc\n";
            var output = new StringWriter();
            Console.SetIn(new StringReader(input));
            Console.SetOut(output);

            // Act
            Program.Main(new string[] { });

            // Assert
            Assert.Contains("Некорректный ввод. Введите целое число.", output.ToString());
        }

        [Fact]
        public void TestValidInput()
        {
            // Arrange
            var input = "3\n4\n";
            var output = new StringWriter();
            Console.SetIn(new StringReader(input));
            Console.SetOut(output);

            // Act
            Program.Main(new string[] { });

            // Assert
            var expectedOutput = "Матрица умножения:\n" +
                                 "1 2 3 \n" +
                                 "2 4 6 \n" +
                                 "3 6 9 \n" +
                                 "4 8 12 \n";
            Assert.Contains(expectedOutput, output.ToString());
        }
    }
}
