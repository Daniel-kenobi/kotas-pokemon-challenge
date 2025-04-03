namespace Domain.Model
{
    public class Response<T> where T : class
    {
        public List<string> Errors { get; set; }
        public T Result { get; set; }
        public bool IsSucessfull { get; set; } = true;

        public Response()
        {
            Errors = [];
        }

        public void AddError(string message)
        {
            Errors.Add(message);
            IsSucessfull = false;
        }
    }
}
