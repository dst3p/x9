using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Xml.Serialization;
using X9.Models.FileStructure;

namespace X9.Common.Extensions
{
    public static class SerializationExtensions
    {
        public static string ToJson<T>(this T objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }

        public static string ToXml<T>(this T objectToSerialize)
        {
            using (var stringWriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(stringWriter, objectToSerialize);

                return stringWriter.ToString();
            }
        }
    }
}
