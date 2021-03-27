namespace PinnacleSample.DTO.Repository
{
    using PinnacleSample.DTO.Customer;
    public interface ICustomerRepositoryDB
    {
        //Defining a interface for CustomerRepositoryDB will help to build mock service in unit test and also in loosely coupled system.
        Customer GetByName(string name);
    }
}
