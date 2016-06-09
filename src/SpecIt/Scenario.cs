namespace SpecIt
{
    using System.Security.Cryptography.X509Certificates;

    public class Scenario
    {
        public static IResolver Resolver { get; set; } = new Resolver();

        protected IGiven Given()
        {
            return Resolver.Resolve<GivenSteps>();
        }
    }
}