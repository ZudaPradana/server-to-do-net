namespace SimpleAppCRUD.DTO.Respon
{
    public class ResponData<T>
    {
        public ResponHeader ResponHeader {  get; set; }
        public T Data { get; set; }
    }
}
