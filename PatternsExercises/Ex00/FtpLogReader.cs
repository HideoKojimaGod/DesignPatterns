using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Ex00.ExternalLibs;

namespace Patterns.Ex00
{
    class FtpLogReader : ILogReader
    {
        private string login;
        private string password;

        public FtpLogReader(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        public string ReadLogFile(string identificator)
        {
            return new FtpClient().ReadFile(login,password,identificator);
        }

    }
}
