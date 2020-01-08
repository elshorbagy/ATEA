using Atea.Framework.Model;
using Atea.Framework.Util;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Atea.Framework
{
    public class FileRepository : IRepository
    {
        public event EventHandler<ResultArgs> ReadResult;

        private const string FileExtenstion = ".txt";
        private readonly string _workingDirectory;
        private readonly ILogger _log;
        private string _filePath;

        public FileRepository(string workingDirectory)
        {
            _workingDirectory = workingDirectory;
            _log = LogFactory.Create();
        }

        private string Write(string filePath, string message)
        {
            _log.LogInformation("Writing to file: " + filePath);

            File.AppendAllText(_filePath, message);

            return _filePath;
        }

        public void Create(int id, string textToAdd)
        {
            try
            {
                _filePath = $"{_workingDirectory}{id}{FileExtenstion}";

                var ev = new ResultArgs(Write(_filePath, textToAdd) + " was created");

                _log.LogInformation("file " + _filePath + " was updated");

                ReadResult?.Invoke(this, ev);
            }
            catch (Exception exception)
            {
                _log.LogInformation(exception.Message);
                ReadResult?.Invoke(this, new ResultArgs(exception.Message));
            }
        }

        public void Read(int id)
        {
            try
            {
                _filePath = $"{_workingDirectory}{id}{FileExtenstion}";

                _log.LogInformation("Reading from file: " + _filePath);

                if (File.Exists(_filePath) == false)
                    throw new FileNotFoundException();

                var textFromFile = File.ReadAllText(_filePath);

                ReadResult?.Invoke(this, new ResultArgs(textFromFile));
            }
            catch (Exception exception)
            {
                _log.LogInformation(exception.Message);
                ReadResult?.Invoke(this, new ResultArgs(exception.Message));
            }
        }

        public bool Delete(int id)
        {
            _filePath = $"{_workingDirectory}{id}{FileExtenstion}";
            try
            {
                var message = "file " + _filePath + " was deleted";

                _log.LogInformation("Deleting file: " + _filePath);

                if (File.Exists(_filePath) == false)
                    throw new FileNotFoundException();

                File.Delete(_filePath);

                _log.LogInformation(message);

                ReadResult?.Invoke(this, new ResultArgs(message));
            }
            catch (Exception exception)
            {
                _log.LogInformation(exception.Message);
                ReadResult?.Invoke(this, new ResultArgs(exception.Message));
                return false;
            }
            return true;
        }

        public void Update(int id, string textToUpdate)
        {
            try
            {
                _filePath = $"{_workingDirectory}{id}{FileExtenstion}";

                if (File.Exists(_filePath) == false)
                    throw new FileNotFoundException();

                var ev = new ResultArgs(Write(_filePath, textToUpdate) + " was updated");

                _log.LogInformation("file " + _filePath + " was updated");

                ReadResult?.Invoke(this, ev);
            }
            catch (Exception exception)
            {
                _log.LogInformation(exception.Message);
                ReadResult?.Invoke(this, new ResultArgs(exception.Message));
            }
        }
    }
}