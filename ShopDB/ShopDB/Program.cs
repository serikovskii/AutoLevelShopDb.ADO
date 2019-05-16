using System;
using System.Data;

namespace ShopDB
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet shopDb = new DataSet("ShopDB");

            #region orders columns
            var orders = new DataTable("Orders");

            orders.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            orders.Columns.Add("CustomerId", typeof(int));
            orders.Columns.Add("EmployeeId", typeof(int));
            orders.Columns.Add("ProductId", typeof(int));

            shopDb.Tables.Add(orders);
            #endregion

            #region customers columns
            var customers = new DataTable("Customers");

            customers.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            customers.Columns.Add("FullName", typeof(string));
            customers.Columns.Add("BirthDate", typeof(DateTime));
            customers.Columns.Add("City", typeof(string));

            shopDb.Tables.Add(customers);
            #endregion

            #region employees columns
            var employees = new DataTable("Employees");

            employees.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            employees.Columns.Add("FullName", typeof(string));
            employees.Columns.Add("BirthDate", typeof(DateTime));
            employees.Columns.Add("City", typeof(string));

            shopDb.Tables.Add(employees);
            #endregion

            #region products columns
            var products = new DataTable("Products");

            products.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            products.Columns.Add("Name", typeof(string));
            products.Columns.Add("Manufacturer", typeof(string));

            shopDb.Tables.Add(products);
            #endregion

            #region orderdetails columns
            var orderDetails = new DataTable("OrderDetails");

            orderDetails.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            orderDetails.Columns.Add("OrderId", typeof(int));
            orderDetails.Columns.Add("OrderDate", typeof(DateTime));

            shopDb.Tables.Add(orderDetails);
            #endregion

            #region relations
            shopDb.Relations.Add("Customers_Orders_fk",
                shopDb.Tables["Customers"].Columns["Id"],
                shopDb.Tables["Orders"].Columns["CustomerId"]);

            shopDb.Relations.Add("Products_Orders_fk",
                shopDb.Tables["Products"].Columns["Id"],
                shopDb.Tables["Orders"].Columns["ProductId"]);

            shopDb.Relations.Add("Employees_Orders_fk",
                shopDb.Tables["Employees"].Columns["Id"],
                shopDb.Tables["Orders"].Columns["EmployeeId"]);

            shopDb.Relations.Add("OrdersDetails_fk",
                shopDb.Tables["Orders"].Columns["Id"],
                shopDb.Tables["OrderDetails"].Columns["OrderId"]);
            #endregion
        }
    }
}
