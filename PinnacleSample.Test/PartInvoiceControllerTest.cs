using NUnit.Framework;
using Moq;
using PinnacleSample.DTO.Repository;
using PinnacleSample.DTO.Customer;

namespace PinnacleSample.Test
{
    [TestFixture]
    public class PartInvoiceControllerTest
    {
        [TestCase]
        public void PartInvoiceControllerTest_CustomerIDZeroCheck()
        {
            Customer customer = new Customer
            {
                ID = 0,
                Name = "TestCustomer",
                Address = "London"
            };
            var CustomerRepositoryDBservice = new Mock<ICustomerRepositoryDB>();
            CustomerRepositoryDBservice.Setup(i => i.GetByName(It.IsAny<string>())).Returns(customer);
            var PartInvoiceRepositoryDBService = new Mock<IPartInvoiceRepositoryDB>();
            var PartAvailabilityService = new Mock<IPartAvailabilityService>();

            var partInvoiceController = new PartInvoiceController(CustomerRepositoryDBservice.Object, PartAvailabilityService.Object, PartInvoiceRepositoryDBService.Object);
            var stockCode = "PW";
            var quantity = 1;
            var customerName = "TestCustomer";

            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == false);
        }


        [TestCase]
        public void PartInvoiceControllerTest_CustomerIDNotZeroCheck()
        {
            Customer customer = new Customer
            {
                ID = 1,
                Name = "TestCustomer",
                Address = "London"
            };
            var CustomerRepositoryDBservice = new Mock<ICustomerRepositoryDB>();
            CustomerRepositoryDBservice.Setup(i => i.GetByName(It.IsAny<string>())).Returns(customer);
            var PartInvoiceRepositoryDBService = new Mock<IPartInvoiceRepositoryDB>();
            var PartAvailabilityService = new Mock<IPartAvailabilityService>();

            var partInvoiceController = new PartInvoiceController(CustomerRepositoryDBservice.Object, PartAvailabilityService.Object, PartInvoiceRepositoryDBService.Object);
            var stockCode = "SC";
            var quantity = 1;
            var customerName = "TestCustomer";

            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == false);
        }

        [TestCase]
        public void PartInvoiceControllerTest_EmptyStockCode()
        {
            var CustomerRepositoryDBservice = new Mock<ICustomerRepositoryDB>();
            var PartInvoiceRepositoryDBService = new Mock<IPartInvoiceRepositoryDB>();
            var PartAvailabilityService = new Mock<IPartAvailabilityService>();

            var partInvoiceController = new PartInvoiceController(CustomerRepositoryDBservice.Object, PartAvailabilityService.Object, PartInvoiceRepositoryDBService.Object);
            var stockCode = string.Empty;
            var quantity = 100;
            var customerName = "TestCustomer";
            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == false);
        }

        [TestCase]
        public void PartInvoiceControllerTest_ZeroQuantity()
        {
            var CustomerRepositoryDBservice = new Mock<ICustomerRepositoryDB>();
            var PartInvoiceRepositoryDBService = new Mock<IPartInvoiceRepositoryDB>();
            var PartAvailabilityService = new Mock<IPartAvailabilityService>();

            var partInvoiceController = new PartInvoiceController(CustomerRepositoryDBservice.Object, PartAvailabilityService.Object, PartInvoiceRepositoryDBService.Object);
            var stockCode = "SC";
            var quantity = 0;
            var customerName = "TestCustomer";
            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == false);
        }        

        [TestCase]
        public void PartInvoiceControllerTest_NoCustomer()
        {
            var CustomerRepositoryDBservice = new Mock<ICustomerRepositoryDB>();
            Customer customer = null;
            CustomerRepositoryDBservice.Setup(r => r.GetByName(It.IsAny<string>())).Returns(customer);
            var PartInvoiceRepositoryDBService = new Mock<IPartInvoiceRepositoryDB>();
            var PartAvailabilityService = new Mock<IPartAvailabilityService>();

            var partInvoiceController = new PartInvoiceController(CustomerRepositoryDBservice.Object, PartAvailabilityService.Object, PartInvoiceRepositoryDBService.Object);
            var stockCode = "SC";
            var quantity = 1;
            var customerName = "TestCustomer";

            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == false);
        }       


        [TestCase]
        public void PartInvoiceControllerTest_SuccessInvoice()
        {
            Customer customer = new Customer
            {
                ID = 1,
                Name = "TestCustomer",
                Address = "London"
            };
            var CustomerRepositoryDBservice = new Mock<ICustomerRepositoryDB>();
            CustomerRepositoryDBservice.Setup(i => i.GetByName(It.IsAny<string>())).Returns(customer);
            var PartInvoiceRepositoryDBService = new Mock<IPartInvoiceRepositoryDB>();
            var PartAvailabilityService = new Mock<IPartAvailabilityService>();
            var availability = 1;
            PartAvailabilityService.Setup(s => s.GetAvailability(It.IsAny<string>())).Returns(availability);

            var partInvoiceController = new PartInvoiceController(CustomerRepositoryDBservice.Object, PartAvailabilityService.Object, PartInvoiceRepositoryDBService.Object);
            var stockCode = "SC";
            var quantity = 1;
            var customerName = "TestCustomer";

            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == true);
        }

        [TestCase]
        public void PartInvoiceControllerTest_NullCustomerName()
        {
            var CustomerRepositoryDBservice = new Mock<ICustomerRepositoryDB>();
            var PartInvoiceRepositoryDBService = new Mock<IPartInvoiceRepositoryDB>();
            var PartAvailabilityService = new Mock<IPartAvailabilityService>();

            var partInvoiceController = new PartInvoiceController(CustomerRepositoryDBservice.Object, PartAvailabilityService.Object, PartInvoiceRepositoryDBService.Object);
            var stockCode = "SC";
            var quantity = 0;
            string customerName = null;
            var result = partInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);

            Assert.IsTrue(result.Success == false);
        }
    }
}
