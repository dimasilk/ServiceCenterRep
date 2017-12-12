using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.BL.Tests.Common;
using Unity;

namespace ServiceCenter.BL.Tests.CustomersTest
{
    [TestClass]
    public class CustomersTest : BaseTestClass
    {
        private readonly ICustomerService _serviceCustomers;
        private readonly IOrderService _orderService;

        private readonly CustomerDTO _customerDto =
            new CustomerDTO()
            {
                FullName = "Zilka",
                Info = "qwer",
                Phone = "+375295621001"
            };
        public CustomersTest()
        {
           base.InitContainer();
            _serviceCustomers = Container.Resolve<ICustomerService>();
            _orderService = Container.Resolve<IOrderService>();
        }

        [TestMethod]
        public void ShouldAddUpdateAndDeleteCustomer()
        {
            var id = _serviceCustomers.AddCustomer(_customerDto);
            Assert.IsTrue(id != null);
            var customer = _serviceCustomers.GetCustomerById(id);
            Assert.AreEqual(customer.Info, _customerDto.Info);
            Assert.AreEqual(customer.FullName, _customerDto.FullName);
            Assert.AreEqual(customer.Phone, _customerDto.Phone);


            customer.Info = customer.Info + customer.Info;
            customer.FullName = customer.FullName + customer.FullName;
            customer.Phone = customer.Phone + customer.Phone;
            _serviceCustomers.UpdateCustomer(customer);

            var updated = _serviceCustomers.GetCustomerById(id);
            Assert.AreNotEqual(updated.Info, _customerDto.Info);
            Assert.AreNotEqual(updated.FullName, _customerDto.FullName);
            Assert.AreNotEqual(updated.Phone, _customerDto.Phone);

            _serviceCustomers.DeleteCustomer(updated.Id);
            customer = _serviceCustomers.GetCustomerById(id);
            Assert.IsNull(customer);
        }
        [TestMethod]
        public void ShouldGetAllCustomers()
        {
            var a = _serviceCustomers.AddCustomer(_customerDto);
            var b = _serviceCustomers.AddCustomer(_customerDto);
            var c = _serviceCustomers.GetAllCustomers();
            Assert.IsTrue(c.Length > 1);
            _serviceCustomers.DeleteCustomer(a);
            _serviceCustomers.DeleteCustomer(b);
        }
        [Ignore]
        public void TryDeleteCustomerWithOrder()
        {
            var a = _serviceCustomers.AddCustomer(_customerDto);
            var b = _orderService.GetOrderById(new Guid("CA7597A8-E6DD-E711-9BD6-1C1B0DF74675"));
            b.Customer = _serviceCustomers.GetCustomerById(a);
            _orderService.UpdateOrder(b);

            _serviceCustomers.DeleteCustomer(a);
        }



    }
}

