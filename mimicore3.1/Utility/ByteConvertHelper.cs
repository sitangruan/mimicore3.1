using Newtonsoft.Json;
using System.Text;

namespace mimicore3._1.Utility
{
    /// The codes are coming from this link
    /// https://www.jianshu.com/p/aaa5895c88ea

    public class ByteConvertHelper
    {
        public static byte[] Object2Bytes(object obj)
        {
            byte[] serializedResult = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
            return serializedResult;
        }

        public static object Bytes2Object(byte[] buff)
        {
            return JsonConvert.DeserializeObject<object>(Encoding.UTF8.GetString(buff));
        }

        public static T Bytes2Object<T>(byte[] buff)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(buff));
        }
    }
}
