namespace MVC.NetCore.Commons
{
    public class ModelResult
    {
        public ModelResult(bool status, string messageCode)
        {
            Status = status;
            MessageCode = messageCode;
        }

        public bool Status { get; set; }

        public string MessageCode { get; set; }
    }
}
