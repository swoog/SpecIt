namespace SpecIt
{
    using System.Security.Cryptography.X509Certificates;

    public class Scenario
    {
        public Scenario()
        {
            this.Resolver = new Resolver();
            this.Resolver.BindTo<Scenario>(this);
        }

        public IResolver Resolver { get; }

        protected IGiven Given()
        {
            return this.Resolver.Resolve<GivenSteps>();
        }

        public object ReturnValue { get; set; }
    }
}