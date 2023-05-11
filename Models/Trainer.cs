using System.ComponentModel.DataAnnotations;

namespace Models {
    public class Trainer {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Skill>? Skills { get; set; }

    }
}