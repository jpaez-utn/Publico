
using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Api.DAO.DataFile;

namespace Sat.Recruitment.Api.DAO
{
    public class UserDAO
    {
        
        public UserDAO()
        {            
        }


        public bool UserAlreadyExists(User user)
        {
            return (this.GetUser(user.Name, user.Email, user.Address, user.Phone) != null);
        }

        public User GetUser(string name, string email, string address, string phone)
        {
            User userFound = null;

            UserDataRecord userRecordFound = new UserDataFile().FindUserDataRecord(name, email, address, phone);

            if (userRecordFound != null)
                userFound = User.GetUserBasedOnInput(
                                userRecordFound.Name, 
                                userRecordFound.Email, 
                                userRecordFound.Address, 
                                userRecordFound.Phone, 
                                userRecordFound.UserType, 
                                userRecordFound.Money
                                );

            return userFound;
        }
       

    }
}
