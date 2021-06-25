using System;

namespace Api.Db.Entities
{
    //[Table("Users")]
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}