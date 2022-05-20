using System.IO;

namespace Sat.Recruitment.Api.DAO.DataFile
{
    public class UserDataFile
    {
        const string myDataFile = "/Files/Users.txt";
        private string myDatafilePath = Directory.GetCurrentDirectory() + myDataFile;
        private StreamReader myReaderDataFile = null;

        public UserDataFile()
        {            
        }

        private void OpenDataFile()
        {
            myReaderDataFile = new StreamReader(new FileStream(myDatafilePath, FileMode.Open));
        }

        public UserDataRecord ReadNext()
        {
            UserDataRecord nextUserDataRecord = null;

            if (myReaderDataFile == null) OpenDataFile();

            if (myReaderDataFile.Peek() >= 0)
            {                
                nextUserDataRecord = UserDataRecord.GetUserDataRecordFromLine(myReaderDataFile.ReadLine());                
            }

            return nextUserDataRecord;
        }

        public UserDataRecord FindUserDataRecord(string name, string email, string address, string phone)
        {            
            UserDataRecord userRecordFound = null;

            UserDataRecord currentUserDataRecord = this.ReadNext();

            while (currentUserDataRecord != null && userRecordFound == null)
            {
                if ((currentUserDataRecord.Email == email || currentUserDataRecord.Phone == phone)
                    || (currentUserDataRecord.Name == name && currentUserDataRecord.Address == address))
                {
                    userRecordFound = currentUserDataRecord;
                }
                else
                {
                    currentUserDataRecord = this.ReadNext();
                }
            }

            this.CloseDataFile();

            return userRecordFound;
        }

        private void CloseDataFile()
        {
            myReaderDataFile.Close();
            myReaderDataFile = null;
        }
    }
}
