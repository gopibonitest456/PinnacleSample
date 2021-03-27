
#1 Organised the project into controller, model and DTO objects based on the functionality of code. This will give a good understanding on the application 
# and promotes readability of the project.

#2 PartInvoiceController.CreatePartInvoice has been simplified where removed redundant code of doing validation and calling same function every time.
# All the validation has been pushed to single if condition.

#3 PartInvoiceController was very much tightly coupled with the repository db and availability service classes.
# To make it loosely coupled, Interfaces were defined for the individual classes.

#4 Used dependnecy injection pattern, to remove the tight coupling in the PartInvoiceController.
# Dependency injection pattern has been achieved by passing the services at run time using the class constructor

#5 In future, if additional customer repositorie db and invoice repositories comes then they can be easily integrated by just implementing the necessary interfaces
# without disturbing the PartInvoiceController. Achieved Open Closed principle by this, where this service is open for extension and closed for modification.

#5 Interfaces of CustomerRepositoryDB, PartInvoiceRepositoryDB classes helped to create mock services in unit testing. 

