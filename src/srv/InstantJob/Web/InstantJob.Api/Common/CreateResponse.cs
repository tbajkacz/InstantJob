namespace InstantJob.Web.Api.Common
{
    public class CreateResponse<T>
    {
        public T Id { get; }

        public CreateResponse(T id)
        {
            Id = id;
        }
    }
}
