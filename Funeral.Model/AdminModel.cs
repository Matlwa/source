using System;

namespace Funeral.Model
{
    public class AdminModel
    {
        public int PkiUserID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ApplicationName { get; set; }
        public Guid parlourid { get; set; }
        public string Currency { get; set; }
    }
}
