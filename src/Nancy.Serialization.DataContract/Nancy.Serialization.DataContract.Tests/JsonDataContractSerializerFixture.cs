namespace Nancy.Serialization.DataContract.Tests
{
    using System.IO;
    using System.Text;

    using Nancy.Serialization.DataContract.Tests.Fakes;

    using Xunit;

    public class JsonDataContractSerializerFixture
    {
        private readonly JsonDataContractSerializer serializer;

        public JsonDataContractSerializerFixture()
        {
            this.serializer = new JsonDataContractSerializer();
        }

        [Fact]
        public void Should_recognise_data_member_attributes()
        {
            // Given
            var model = new DataContractModel { AnInt = 45 };
            var stream = new MemoryStream();

            // When
            this.serializer.Serialize("application/json", model, stream);

            // Then
            Assert.Equal("{\"anInt\":45}", Encoding.ASCII.GetString(stream.ToArray()));
        }
    }
}