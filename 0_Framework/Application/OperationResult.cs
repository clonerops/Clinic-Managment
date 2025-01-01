namespace _0_Framework.Application
{
    public class OperationResult<T>
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public OperationResult()
        {
            IsSuccedded = false;
        }

        public OperationResult<T> Succedded(T data, string message = "عملیات با موفقیت انجام شد.")
        {
            IsSuccedded = true;
            Message = message;
            Data = data;
            return this;
        }

        public OperationResult<T> Failed(string message)
        {
            IsSuccedded = false;
            Data = default(T);
            Message = message;
            return this;
        }

    }
}
