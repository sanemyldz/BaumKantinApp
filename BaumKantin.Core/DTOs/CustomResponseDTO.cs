using System.Text.Json.Serialization;

namespace BaumKantin.Core.DTOs
{
    //STATIC FACTORY METHOD

    public class CustomResponseDTO<T>:BaseDTO
    {
        public T Data { get; set; }

        [JsonIgnore]//StatusCode will not return with request.
        public int StatusCode { get; set; }

        public List<String>? Errors { get; set; }

        public static CustomResponseDTO<T> Success(int status,T data)
        {
            return new CustomResponseDTO<T> { Data = data, StatusCode=status, Errors=null };    
        }

        public static CustomResponseDTO<T> Success(int status)
        {
            return new CustomResponseDTO<T> { StatusCode = status };
        }

        public static CustomResponseDTO<T> Fail(int status, string error)
        {
            return new CustomResponseDTO<T> { StatusCode = status, Errors = new List<string> { error } };
        }
    }
    public class NoContentResponseDTO
    {

        [JsonIgnore]//StatusCode doesn't returning on Client requests.
        public int StatusCode { get; set; }

        public List<String> Errors { get; set; }

        public static NoContentResponseDTO Success(int status)
        {
            return new NoContentResponseDTO { StatusCode = status, Errors = null };
        }

        public static NoContentResponseDTO Fail(int status, string error)
        {
            return new NoContentResponseDTO { StatusCode = status, Errors = new List<string> { error } };
        }
    }
}
