using System;
using AutoMapping.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMappingTests
{
    [TestClass]
    public class AutoMappingTests
    {
        [TestMethod]
        public void Object_Mapping_Test()
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Thanh",
                LastName = "Vu"
            };

            ReducedAutoMapper.Instance.CreateMap<User, UserModel>();
            var model = ReducedAutoMapper.Instance.Map<User, UserModel>(user);

            Assert.AreEqual(user.LastName, model.LastName);

            Console.WriteLine($"Model full name = {model.FirstName} {model.LastName}");
        }
    }

    public class UserModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string NationalInsuranceNumber { get; set; }

        public string UserName { get; set; }

        public string MemorableQuestion { get; set; }

        public DateTime JoinedDate { get; set; }

        public DateTime LastAccessDate { get; set; }

        public string EmailAddress { get; set; }

        public Address Address { get; set; }

        public UserModel()
        {
            Address = new Address();
        }
    }


    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string NationalInsuranceNumber { get; set; }

        public string UserName { get; set; }

        public string MemorableQuestion { get; set; }

        public DateTime JoinedDate { get; set; }

        public DateTime LastAccessDate { get; set; }

        public string EmailAddress { get; set; }

        public Address Address { get; set; }

        public User()
        {
            Address = new Address();
        }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public PostCode PostCode { get; set; }

        public Address()
        {
            PostCode = new PostCode();
        }
    }

    public class PostCode
    {
        public string InwardCode { get; set; }
        public string OutwardCode { get; set; }

        public string Code
        {
            get { return Parse(this); }
            set
            {
                OriginalCode = value;
                var parts = value.Split(' ');
                if (parts.Length == 2)
                {
                    InwardCode = parts[0].Trim().ToUpper();
                    OutwardCode = parts[1].Trim().ToUpper();
                }
                else
                {
                    InwardCode = OutwardCode = string.Empty;
                }
            }
        }

        public string OriginalCode { get; private set; }

        public static string Parse(PostCode postCode)
        {
            if (string.IsNullOrEmpty(postCode.InwardCode) || string.IsNullOrEmpty(postCode.OutwardCode))
                return string.Empty;
            return string.Format("{0} {1}", postCode.InwardCode.Trim().ToUpper(), postCode.OutwardCode.Trim().ToUpper());
        }
    }
}
