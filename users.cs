using System;

namespace apiTask.models
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string email { get; set; }

        public User(int id, string firstName, string lastName, DateTime dateOfBirth, string email)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.email = email;
        }
    }


}
