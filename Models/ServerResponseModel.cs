namespace ArtSofte_Test.Models
{
    public class ServerResponseModel<T>
    {
      public T ResponseData { get; set; }
      public string Error { get; set; }
    }
}
