namespace HelpSystem.Infrastructure.Services
{
    public interface IRequestHandler<T, TResult> where T : IRequest<TResult>
    {
        public TResult Handle(T request);
    }
}
