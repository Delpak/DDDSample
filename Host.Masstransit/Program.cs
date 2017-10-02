using Topshelf;

namespace Host.Masstransit
{
    public partial class Program
    {

        public static int Main()
        {
            var t = (int)HostFactory.Run(cfg => cfg.Service(x => new SampleBoundedContextService()));


            return t;
        }
    }
}
