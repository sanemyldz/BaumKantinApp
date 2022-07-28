using Microsoft.AspNetCore.Http;

namespace BaumKantin.Core
{
    public static class TypeConverter
    {
        public static byte[] ImageConvert(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                 formFile.CopyTo(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    return memoryStream.ToArray();
                }
                else
                {
                    /*TODO
                     * Configure error message if more than 2 MB 
                     * Try-Catch will be implemented
                     */
                    throw new NotImplementedException();
                }
            }
        }
    }
}
