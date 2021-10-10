using Moq;
using MVC.NetCore.Business;
using MVC.NetCore.Commons;
using MVC.NetCore.IDataServices;
using MVC.NetCore.Models;
using Xunit;

namespace MVC.NetCore.UnitTest
{
    public class PersonalContactUnitTest
    {
        #region Fields

        /// <summary>
        /// Mock up the personal contact Data Service to handle data access for personal contact.
        /// </summary>
        private readonly Mock<IPersonalContactDataService> _mockPersonalContactDataService;

        /// <summary>
        /// The personal contact business handle business for profile.
        /// </summary>
        private readonly PersonalContactBusiness _personalContactBusiness;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalContactUnitTest"/> class.
        /// </summary>
        public PersonalContactUnitTest()
        {
            _mockPersonalContactDataService = new Mock<IPersonalContactDataService>();
            _personalContactBusiness = new PersonalContactBusiness(_mockPersonalContactDataService.Object);
        }

        #endregion

        [Fact]
        public void Test_Insert_Invalid_First_Name()
        {
            PersonalContactModel personalContact = new PersonalContactModel()
            {
                LastName = "Nguyen",
                Title = "Developer"
            };

            // Mockup new personal contact method and return false.
            _mockPersonalContactDataService.Setup(m => m.InsertAsync(personalContact).Result).Returns(false);

            /// Call the CreatePersonalContactAsync method in PersonalContactBusiness.
            ModelResult result = _personalContactBusiness.CreatePersonalContactAsync(personalContact).Result;

            // Compare the result with the expected result.
            Assert.True(result.Status);
        }

        [Fact]
        public void Test_Insert_Invalid_Title_With_Max_Length()
        {
            PersonalContactModel personalContact = new PersonalContactModel()
            {
                FirstName = "Phuoc",
                LastName = "Nguyen",
                Title = "The Amazon CloudFront distribution is configured to block access from your country. " +
                "We can't connect to the server for this app or website at this time. " +
                "There might be too much traffic or a configuration error. " +
                "Try again later, or contact the app or website owner. " +
                "If you provide content to customers through CloudFront, " +
                "you can find steps to troubleshoot and help prevent this error by reviewing the CloudFront " +
                "documentation."  // Title Length = 426 (Valid Length: 150)
            };

            // Mockup new personal contact method and return false.
            _mockPersonalContactDataService.Setup(m => m.InsertAsync(personalContact).Result).Returns(false);

            /// Call the CreatePersonalContactAsync method in PersonalContactBusiness.
            ModelResult result = _personalContactBusiness.CreatePersonalContactAsync(personalContact).Result;

            // Compare the result with the expected result.
            Assert.True(result.Status);
        }

        [Fact]
        public void Test_Insert_Valid()
        {
            PersonalContactModel personalContact = new PersonalContactModel()
            {
                FirstName = "Phuoc",
                LastName = "Nguyen",
                Title = "Developer"
            };

            // Mockup new personal contact method and return true.
            _mockPersonalContactDataService.Setup(m => m.InsertAsync(personalContact).Result).Returns(true);

            /// Call the CreatePersonalContactAsync method in PersonalContactBusiness.
            ModelResult result = _personalContactBusiness.CreatePersonalContactAsync(personalContact).Result;

            // Compare the result with the expected result.
            Assert.True(result.Status);
        }
    }
}