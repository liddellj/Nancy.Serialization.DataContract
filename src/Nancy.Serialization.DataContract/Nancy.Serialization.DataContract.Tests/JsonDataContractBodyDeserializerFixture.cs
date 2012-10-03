namespace Nancy.Serialization.DataContract.Tests
{
    using System.IO;
    using System.Text;

    using Nancy.ModelBinding;
    using Nancy.Serialization.DataContract.Tests.Fakes;

    using Xunit;

    public class JsonDataContractBodyDeserializerFixture
    {
        private readonly JsonDataContractBodyDeserializer deserializer;

        public JsonDataContractBodyDeserializerFixture()
        {
            this.deserializer = new JsonDataContractBodyDeserializer();
        }

        [Fact]
        public void Should_recognise_data_member_attributes()
        {
            // Given
            var stream = new MemoryStream();
            var body = new StringBuilder("{\"anInt\":45}");
            stream.Write(Encoding.ASCII.GetBytes(body.ToString()), 0, body.Length);
            stream.Position = 0; // reset stream position

            // When
            var result = (DataContractModel)this.deserializer.Deserialize("application/json", stream, new BindingContext { DestinationType = typeof(DataContractModel) });

            // Then
            Assert.Equal(45, result.AnInt);
        }
    }
}