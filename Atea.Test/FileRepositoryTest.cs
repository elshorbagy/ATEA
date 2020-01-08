using Atea.Framework;
using Atea.Framework.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Atea.Test
{
    [TestClass]
    public class FileRepositoryTest
    {
        private readonly IRepository _fileRepository;
        private readonly string _workingDirectory = "D:\\work\\";
        private static string _result;

        public FileRepositoryTest()
        {
            _fileRepository = new FileRepository(_workingDirectory);
            _fileRepository.ReadResult += ReadResult;
        }

        [TestMethod]
        public void WriteTestMethod()
        {
            _fileRepository.Create(2, "Test message");
            Assert.AreEqual(true, File.Exists(_workingDirectory + "2.txt"));
        }

        [TestMethod]
        public void ReadTestMethod()
        {
            _fileRepository.Read(2);
            Assert.AreEqual("Test message", _result);
        }

        [TestMethod]
        public void UpdateTestMethod()
        {
            _fileRepository.Update(2, " update message");
            Assert.AreEqual(@"D:\work\2.txt was updated", _result);
        }

        [TestMethod]
        public void DeleteTestMethod()
        {
            _fileRepository.Delete(2);
            Assert.AreEqual(false, File.Exists(_workingDirectory + "2.txt"));
        }

        private static void ReadResult(object sender, ResultArgs eventArgs)
        {
            _result = eventArgs.Result;
        }
    }
}