using Patterns.Ex05.ExternalLibs;

namespace Patterns.Ex05.SubEx_01
{
    public class DatabaseSaverClient
    {
        public delegate void SaveEventHandler();

        public event SaveEventHandler onSave;
        public void Main(bool b)
        {
            string email = "email";
            var databaseSaver = new DatabaseSaver();
            onSave += () => new MailSender().Send(email);
            onSave += () => new CacheUpdater().UpdateCache();
            Save(databaseSaver);
        }
        public void Save(DatabaseSaver databaseSaver)
        {
            DoSmth(databaseSaver);
            onSave();
        }
        private void DoSmth(IDatabaseSaver saver)
        {
            saver.SaveData(null);
        }
    }
}