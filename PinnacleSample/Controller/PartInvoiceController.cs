using PinnacleSample.DTO.Customer;
using PinnacleSample.DTO.Repository;

namespace PinnacleSample
{
    public class PartInvoiceController:IPartInvoiceController
    {
        private ICustomerRepositoryDB _ICustomerRepositoryDB;
        private IPartAvailabilityService _IPartAvailabilityService;
        private IPartInvoiceRepositoryDB _IPartInvoiceRepositoryDB;

        public PartInvoiceController()
        {
            //In the constructor defining the necessary objects so that existing client wont be disturbed.
            _ICustomerRepositoryDB = new CustomerRepositoryDB();
            _IPartAvailabilityService = new PartAvailabilityServiceClient();
            _IPartInvoiceRepositoryDB = new PartInvoiceRepositoryDB();
        }

        public PartInvoiceController(ICustomerRepositoryDB _CustomerRepositoryDB, IPartAvailabilityService _PartAvailabilityService, IPartInvoiceRepositoryDB _PartInvoiceRepositoryDB)
        {
            //Dependency injection pattern has been achieved by passing the services at run time using the class constructor

            //Created new constructor for defining the objects for customerrepository, partavailabilityservice and partinvoicerepositoryDB
            //This will give flexibility to unit test and also provision to add additional customer repositories and invoice repositories by just implementing the necessary interfaces.
            //Achieved Open Closed principle by this, where this service is open for extension and closed for modification.

            _ICustomerRepositoryDB = _CustomerRepositoryDB;
            _IPartAvailabilityService = _PartAvailabilityService;
            _IPartInvoiceRepositoryDB = _PartInvoiceRepositoryDB;                       
        }

        public CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName)
        {           

            Customer customer = _ICustomerRepositoryDB.GetByName(customerName);
            int Availability = _IPartAvailabilityService.GetAvailability(stockCode);

            //CreatPartInvoiceResult validation has been moved to single line of validation.

            if (string.IsNullOrEmpty(stockCode) || quantity < 0 || customer == null || customer.ID < 0 || Availability <= 0)
            {
                return new CreatePartInvoiceResult(false);
            }

            PartInvoice partInvoice = new PartInvoice
            {
                StockCode = stockCode,
                Quantity = quantity,
                CustomerID = customer.ID
            };
          
            _IPartInvoiceRepositoryDB.Add(partInvoice);

            return new CreatePartInvoiceResult(true);
        }
    }
}
