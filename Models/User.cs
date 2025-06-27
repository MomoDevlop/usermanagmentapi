using System;

namespace UserManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; }               // Primary key
        public string FirstName { get; set; }     // User's first name
        public string LastName { get; set; }      // User's last name
        public string Email { get; set; }         // User's email address
        public DateTime CreatedAt { get; set; }   // Record creation timestamp
    }
}