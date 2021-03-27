namespace PinnacleSample
{
    public interface IPartInvoiceController
    {
        //Defining a interface for PartInvoiceController will help to build loosely coupled system.
        CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName);
    }
}
