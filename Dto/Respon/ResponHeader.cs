namespace SimpleAppCRUD.DTO.Respon
{
    public class ResponHeader
    {
        public string code { get; set; } = string.Empty;
        public bool status {  get; set; }
        public string message { get; set; } = string.Empty ;

        public ResponHeader(string code, bool status, string message)
        {
            this.code = code;
            this.status = status;
            this.message = message;
        }
    }
}
