namespace Nancy.Serialization.DataContract
{
    using System.IO;
    using System.Runtime.Serialization.Json;

    using Nancy.ModelBinding;

    public class JsonDataContractBodyDeserializer : IBodyDeserializer
    {
        /// <summary>
        /// Whether the deserializer can deserialize the content type
        /// </summary>
        /// <param name="contentType">Content type to deserialize</param>
        /// <returns>True if supported, false otherwise</returns>
        public bool CanDeserialize(string contentType)
        {
            return Helpers.IsJsonType(contentType);
        }

        public object Deserialize(string contentType, Stream bodyStream, BindingContext context)
        {
            return new DataContractJsonSerializer(context.DestinationType).ReadObject(bodyStream);
        }
    }
}
