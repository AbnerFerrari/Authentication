using Authentication.Domain.Enums;
using Bogus;

namespace Authentication.Test.Factories
{
    internal static class UserFactory
    {
        internal static User New()
        {
            return new Faker<User>()
                .RuleFor(x => x.Username, f => f.Person.FullName)
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Role, f => f.PickRandom<Role>())
                .RuleFor(x => x.Password, f=> f.Random.String2(15))
                .Generate();
        }
    }
}
