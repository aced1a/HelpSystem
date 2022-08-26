namespace HelpSystem.Infrastructure.Services
{
    public interface IRequestHandler<T, TResult> where T : IRequest<TResult>
    {
        public TResult Handle(T request);

        public Task<TResult> HandleAsync(T request);
    }
}
