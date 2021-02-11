namespace DotNetCenter.Beyond.Mapping.UnitTest
{
    using DotNetCenter.Beyond.Mapping.DependencyResolution;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;
    using Xunit;
    public class BaseProfileTests
    {
        private readonly ServiceCollection services;
        public BaseProfileTests() => services = new ServiceCollection();
        [Fact]
        public void Should_Apply_Mappings_From_Assembly_For_IMapTo_With_Mapping_Method_Impelementation()
        {
            var human = new Human("Bob", 23);
            var person = GetMapper().Map<Human, Person>(human);
            Assert.Equal(human.Name, person.Name);
            Assert.Equal(human.Age, person.Age);
        }
        [Fact]
        public void Should_Apply_Mappings_From_Assembly_For_IMapTo_With_Mapping_Interface_Default_Method_Impelementation()
        {
            var device = new Device("Android");
            var audioDevice = GetMapper().Map<Device, AudioDevice>(device);
            Assert.Equal(device.Name, audioDevice.Name);
        }

        [Fact]
        public void Should_Apply_Mappings_From_Assembly_For_IMapFrom_With_Mapping_Method_Impelementation()
        {
            var person = new Person("Alice", 23, "123");
            var emploee = GetMapper().Map<Person, Emploee>(person);
            Assert.Equal(person.Name, emploee.Name);
            Assert.Equal(person.Age, emploee.Age);
            Assert.Equal(person.NationalCode, emploee.NationalCode);
        }
        [Fact]
        public void Should_Apply_Mappings_From_Assembly_For_IMapFrom_With_Mapping_Interface_Default_Method_Impelementation()
        {
            var audioDevice = new AudioDevice("Android", 26);
            var mediaDevice = GetMapper().Map<AudioDevice, MediaDevice>(audioDevice);
            Assert.Equal(mediaDevice.Name, audioDevice.Name);
            Assert.Equal(mediaDevice.AudioRange, audioDevice.AudioRange);
        }
        private IMapper GetMapper()
        {
            services.AddDefaultAutoMapperServices(Assembly.GetAssembly(typeof(BaseProfileTests)));
            var serviceProvider = services.BuildServiceProvider();
            var mapper = serviceProvider.GetRequiredService<IMapper>();
            return mapper;
        }
    }

    internal class AudioDevice : Device
    {
        public AudioDevice()
        { }
        public AudioDevice(string name, int audioRange) : base(name)
        {
            AudioRange = audioRange;
        }
        public int AudioRange { get; set; }
    }

    internal class Device : IMapTo<AudioDevice>
    {
        public Device()
        { }
        public Device(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

    }
    internal class MediaDevice : AudioDevice, IMapFrom<AudioDevice>
    {
        public MediaDevice()
        { }
        public MediaDevice(string name, int audioRange) : base(name, audioRange)
        { }
    }

    internal class MappingTestProfile : BaseProfile
    {
        public MappingTestProfile() 
            : base(Assembly.GetExecutingAssembly())
        { }
    }

    internal class Person : Human
    {
        public Person(string name, int? age, string nationalCode)
            :base (name, age)
        {
            Name = name;
            Age = age;
            NationalCode = nationalCode;
        }
        public string NationalCode { get; set; }
    }

    internal class Human : IMapTo<Person>
    {
        public Human(string name, int? age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int? Age { get; set; }
    }

    internal class Emploee : Person, IMapFrom<Person>
    {
        public Emploee(string name, int? age, string nationalCode, string emploeeId) 
            : base(name, age, nationalCode)
        {
            NationalCode = nationalCode;
            EmploeeId = emploeeId;
        }
        public string EmploeeId { get; set; }
        public void Mapping(Profile profile) => profile.CreateMap<Person, Emploee>();

    }
}
