namespace PinnacleSample.DTO.Repository
{
    //Defining a interface for CustomerRepositoryDB will help to build mock service in unit test and also in loosely coupled system.
    public interface IPartInvoiceRepositoryDB
    {
        void Add(PartInvoice invoice);
    }
}
