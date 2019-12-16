using System.Text;
using Newtonsoft.Json;

namespace Core.Extensions
{
    public static class ObjectExtensions
    {
        public static byte[] ToByte(this object c)
        {
            return Encoding.UTF8.GetBytes( JsonConvert.SerializeObject(c) );
        }
    }
}