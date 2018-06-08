using Patterns.Ex00.ExternalLibs;

namespace Patterns.Ex00
{
    public class LogImporterClient
    {
        /// <summary>
        /// TODO: Изменения нужно вносить в этом методе
        /// </summary>
        public void DoMethod()
        {
            var ftpClient = new FtpClient();
            LogImporter importer = new LogImporter(new FtpLogReader("login", "password"));
            importer.ImportLogs("ftp://log.txt");
        }

    }
}