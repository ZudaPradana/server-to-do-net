namespace SimpleAppCRUD.DTO.Respon
{
    public class ResponAllData<T>
    {
        public ResponHeader ResponHeader { get; set; }
        public List<T> Data { get; set; }
    }
}
