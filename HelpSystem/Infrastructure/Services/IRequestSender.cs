namespace HelpSystem.Infrastructure.Services
{
    public interface IRequestSender
    {
        public TResult Send<T, TResult>(T request) where T : IRequest<TResult>;    
    }
}
