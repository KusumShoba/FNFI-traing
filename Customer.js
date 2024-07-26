class Customer{
    constructor(id, name, address){
        this.CustomerId = id;
        this.CustomerName = name;
        this.CustomerAddress = address
    }
}

class CustomerRepo{
    customerData =[];
    constructor(){
        this.customerData.push(new Customer(11, "Phaniraj", "Bangalore"))
        this.customerData.push(new Customer(12, "Kusum", "Bangalore"))
        this.customerData.push(new Customer(13, "Chaitra", "Gokarna"))
        this.customerData.push(new Customer(14, "Deesha", "Belgav"))
    }
    addCustomer = (cst) => this.customerData.push(cst);
    
    getAll = () => this.customerData;

    findCustomer = (id) => this.customerData.find((c)=>c.CustomerId == id);

    findAllCustomers = (name) => this.customerData.filter(c => c.CustomerName.inclues(name))

    updateCustomer = function(cst)
    {
        console.log(cst)
        const index=this.customerData.findIndex((c) => c.CustomerId == cst.CustomerId)
        if(index<0)
        {
            alert("No records found to update")
            return
        }
        this.customerData.splice(index,1,cst);
        alert("Customer updated successfully");

    }
    deleteCustomer = function(id)
    {
        const index=this.customerData.findIndex((c) => c.CustomerId == id)
        if(index<0)
        {
            alert("No records found to update")
            return
        }
        this.customerData.splice(index,1);
        alert("Customer deleted successfully");

    }
}