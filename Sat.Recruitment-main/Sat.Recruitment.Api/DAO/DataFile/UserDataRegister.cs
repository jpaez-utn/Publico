namespace Sat.Recruitment.Api.DAO.DataFile
{
    public class UserDataRecord
    {
        private const char fieldSeparator = ',';
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public string Money { get; set; }

        public static UserDataRecord GetUserDataRecordFromLine(string line)
        {
            string[] splittedRecord = line.Split(fieldSeparator);

            return new UserDataRecord
            {
                Name = GetField(splittedRecord, UserDataRecordField.Name),
                Email = GetField(splittedRecord, UserDataRecordField.Email),
                Phone = GetField(splittedRecord, UserDataRecordField.Phone),
                Address = GetField(splittedRecord, UserDataRecordField.Address),
                UserType = GetField(splittedRecord, UserDataRecordField.UserType),
                Money = GetField(splittedRecord, UserDataRecordField.Money),
            };
        }

        private static string GetField(string[] splittedRecord, UserDataRecordField field)
        {
            return splittedRecord[(int)field].ToString();
        }
    }
}
