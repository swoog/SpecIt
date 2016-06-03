namespace SpecIt
{
    using System.Security.Cryptography.X509Certificates;

    public class Scenario
    {
        protected IGiven Given()
        {
            return new GivenSteps(new Resolver());
        }
    }
}