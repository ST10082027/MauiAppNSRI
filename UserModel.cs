using SQLite;

namespace MauiAppNSRI
{
    /// <summary>
    /// UserModel class represents the user data structure used for storing
    /// login credentials and managing user privileges.
    /// </summary>
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(50)]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(20)]
        public string IDNumber { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string CellphoneNumber { get; set; }

        // Role field for privilege management, e.g., "Instructor", "Admin"
        [MaxLength(50)]
        public string Role { get; set; }  

        // Path to the front image of the ID
        [MaxLength(200)]
        public string FrontIdImagePath { get; set; }

        // Path to the back image of the ID
        [MaxLength(200)]
        public string BackIdImagePath { get; set; }
    }
}