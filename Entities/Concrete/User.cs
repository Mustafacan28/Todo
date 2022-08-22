

using Entities.Abstract;

namespace Entities.Concrete
{
    public class User:IEntity
    {
        public int UserId { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? Telephone { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }
    }
}
