namespace SpecIt
{
    public class Scenario
    {
        public Scenario()
            : this(new Resolver())
        {
            
        }

        protected Scenario(IResolver resolver)
        {
            this.Resolver = resolver;
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