using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace HelpSystem.Infrastructure.Services
{
    public class RequestSender : IRequestSender
    {
        static IWindsorContainer _container = new WindsorContainer();
        ApplicationDbContext _context;

        static RequestSender() 
        {
            new WindsorInstaller().Install(_container, null);
        }

        public RequestSender(ApplicationDbContext context) => _context = context;


        public TResult Send<T, TResult>(T request) where T : IRequest<TResult>
        {
            var arguments = new Castle.MicroKernel.Arguments();
            arguments.AddNamed("context", _context);

            var handler = _container.Resolve<IRequestHandler<T, TResult>>(
                 arguments
            );
            return handler.Handle(request);
        }
    }

    class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("HelpSystem")
                                .BasedOn(typeof(IRequestHandler<,>))
                                .WithService.FirstInterface()
                                .LifestyleTransient());
                                
        }
    }

}
