using Topshelf;

namespace SAMA.XSolution.Endpoint
{
    public class Program
    {

        public static int Main()
        {
            var t = (int)HostFactory.Run(cfg => cfg.Service(x => new SampleBoundedContextService()));


            return t;
        }
    }
}
