namespace Nancy.Serialization.DataContract.Tests.Fakes
{
    using System.Runtime.Serialization;

    [DataContract]
    public class DataContractModel
    {
        [DataMember(Name = "anInt")]
        public int AnInt { get; set; }
    }
}