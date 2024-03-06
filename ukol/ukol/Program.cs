﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class Program
{
    static void Main()
    {
        string connectionString = "server=localhost;user=root;database=projekt;port=3306;password=;";

        MySqlConnection connection = new MySqlConnection(connectionString);

        try
        {

            connection.Open();
            Console.WriteLine("Spojení bylo úspěšně navázáno!");
            bool exit = false;


        while (!exit)
        {
            Console.WriteLine("Vyberte akci: ");
            Console.WriteLine("1)Vlozit");
            Console.WriteLine("2)Smazat");
            Console.WriteLine("3)Vlozit pomoci CSV");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Vyberte akci:");
                    Console.WriteLine("1. Vložit záznam do tabulky 'products'");
                    Console.WriteLine("2. Vložit záznam do tabulky 'suppliers'");
                    Console.WriteLine("3. Vložit záznam do tabulky 'customers'");
                    Console.WriteLine("4. Vložit záznam do tabulky 'orders'");
                    Console.WriteLine("5. Konec");

                    int Insertchoice = Convert.ToInt32(Console.ReadLine());

                    switch (Insertchoice)
                    {
                        case 1:
                            InsertProduct();
                            break;
                        case 2:
                            InsertSupplier();
                            break;
                        case 3:
                            InsertCustomer();
                            break;
                        case 4:
                            InsertOrder();
                            break;
                        case 5:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Neplatná volba.");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Vyberte akci:");
                    Console.WriteLine("1. Smazat záznam z tabulky 'products'");
                    Console.WriteLine("2. Smazat záznam z tabulky 'suppliers'");
                    Console.WriteLine("3. Smazat záznam z tabulky 'customers'");
                    Console.WriteLine("4. Smazat záznam z tabulky 'orders'");
                    Console.WriteLine("5. Konec");

                    int DeleteChoice = Convert.ToInt32(Console.ReadLine());

                    switch (DeleteChoice)
                    {
                        case 1:
                            DeleteProduct();
                            break;
                        case 2:
                            DeleteSupplier();
                            break;
                        case 3:
                            DeleteCustomer();
                            break;
                        case 4:
                            DeleteOrder();
                            break;
                        case 5:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Neplatná volba.");
                            break;
                    }
                    break;
                
                case 3:
                    Console.WriteLine("Vyberte akci");
                    Console.WriteLine("1)Vlozit zaznam do tabulky products");
                    Console.WriteLine("2)Vlozit zaznam do tabulky supplier");
                    int InsertCSVChoice = Convert.ToInt32(Console.ReadLine());
                    switch (InsertCSVChoice)
                    {
                        case 1:
                            InsertProductFromCSV();
                            break;
                        case 2:
                            InsertSupplierFromCSV();
                            break;
                    }
                    break;
            }
           
        }
    

    // Metody pro manipulaci s daty

    static  void InsertProduct()
    {
        
        string name = "";
        string category = "";
        float price = 0;
        int stock_quantity = 0;
        bool low_stock_alert = false;
        Console.WriteLine("Name: ");
        name = Console.ReadLine();
        Console.WriteLine("Category: ");
        category = Console.ReadLine();
        Console.WriteLine("Price: ");
        price = float.Parse(Console.ReadLine());
        Console.WriteLine("Stock Quantity: ");
        stock_quantity = int.Parse(Console.ReadLine());
        Console.WriteLine("Low Stock Alert (true/false): ");
        low_stock_alert = bool.Parse(Console.ReadLine());
        
        string connectionString = "server=localhost;user=root;database=projekt;port=3306;password=;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO products (name, category, price, stock_quantity, low_stock_alert) VALUES (@Name, @Category, @Price, @StockQuantity, @LowStockAlert)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Category", category);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@StockQuantity", stock_quantity);
                command.Parameters.AddWithValue("@LowStockAlert", low_stock_alert);
                command.ExecuteNonQuery();
                Console.WriteLine("Záznam byl úspěšně vložen do tabulky 'products'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při vkládání záznamu do tabulky 'products': " + ex.Message);
            }
        }
    }

    static void InsertSupplier()
    {
        string name = "";
        string contactInfo = "";
        decimal rating = 0;

        Console.WriteLine("Zadat informace o dodavateli:");

        Console.WriteLine("Name: ");
        name = Console.ReadLine();

        Console.WriteLine("Contact Info: ");
        contactInfo = Console.ReadLine();

        Console.WriteLine("Rating (0.0 - 5.0): ");
        rating = decimal.Parse(Console.ReadLine());

        string connectionString = "server=localhost;user=root;database=projekt;port=3306;password=;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO suppliers (name, contact_info, rating) VALUES (@Name, @ContactInfo, @Rating)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@ContactInfo", contactInfo);
                command.Parameters.AddWithValue("@Rating", rating);
                command.ExecuteNonQuery();
                Console.WriteLine("Záznam byl úspěšně vložen do tabulky 'suppliers'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při vkládání záznamu do tabulky 'suppliers': " + ex.Message);
            }
        }
    }


    static void InsertCustomer()
    {
        string name = "";
        string contactInfo = "";
        int loyaltyPoints = 0;

        Console.WriteLine("Zadat informace o zákazníkovi:");

        Console.WriteLine("Name: ");
        name = Console.ReadLine();

        Console.WriteLine("Contact Info: ");
        contactInfo = Console.ReadLine();

        Console.WriteLine("Loyalty Points: ");
        loyaltyPoints = int.Parse(Console.ReadLine());

        string connectionString = "server=localhost;user=root;database=projekt;port=3306;password=;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO customers (name, contact_info, loyalty_points) VALUES (@Name, @ContactInfo, @LoyaltyPoints)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@ContactInfo", contactInfo);
                command.Parameters.AddWithValue("@LoyaltyPoints", loyaltyPoints);
                command.ExecuteNonQuery();
                Console.WriteLine("Záznam byl úspěšně vložen do tabulky 'customers'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při vkládání záznamu do tabulky 'customers': " + ex.Message);
            }
        }
    }


    static void InsertOrder()
    {
        int customerId = 0;
        DateTime orderDate;
        DateTime shipmentDate;
        decimal totalPrice = 0;

        Console.WriteLine("Zadat informace o objednávce:");

        Console.WriteLine("Customer ID: ");
        customerId = int.Parse(Console.ReadLine());

        Console.WriteLine("Order Date (YYYY-MM-DD HH:MM:SS): ");
        orderDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Shipment Date (YYYY-MM-DD HH:MM:SS): ");
        string shipmentDateInput = Console.ReadLine();
        shipmentDate = string.IsNullOrWhiteSpace(shipmentDateInput) ? DateTime.MinValue : DateTime.Parse(shipmentDateInput);

        Console.WriteLine("Total Price: ");
        totalPrice = decimal.Parse(Console.ReadLine());

        string connectionString = "server=localhost;user=root;database=projekt;port=3306;password=;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO orders (customer_id, order_date, shipment_date, total_price) VALUES (@CustomerId, @OrderDate, @ShipmentDate, @TotalPrice)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.Parameters.AddWithValue("@OrderDate", orderDate);
                command.Parameters.AddWithValue("@ShipmentDate", shipmentDate == DateTime.MinValue ? DBNull.Value : (object)shipmentDate);
                command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                command.ExecuteNonQuery();
                Console.WriteLine("Záznam byl úspěšně vložen do tabulky 'orders'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při vkládání záznamu do tabulky 'orders': " + ex.Message);
            }
        }
    }

    
    
    static void InsertProductFromCSV()
    {
        string filePath = "";
        Console.WriteLine("Cesta k souboru CSV");
        filePath = Console.ReadLine();
        try
        {
            string connectionString = "server=localhost;user=root;database=projekt;port=3306;password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');

                        string name = values[0];
                        string category = values[1];
                        float price = float.Parse(values[2]);
                        int stock_quantity = int.Parse(values[3]);
                        bool low_stock_alert = bool.Parse(values[4]);

                        string query = "INSERT INTO products (name, category, price, stock_quantity, low_stock_alert) VALUES (@Name, @Category, @Price, @StockQuantity, @LowStockAlert)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@StockQuantity", stock_quantity);
                        command.Parameters.AddWithValue("@LowStockAlert", low_stock_alert);
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Data from CSV file inserted successfully into 'products' table.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error inserting data from CSV into 'products' table: " + ex.Message);
        }
    }
    
    static void InsertSupplierFromCSV()
    {
        string filePath = "";
        Console.WriteLine("Cesta k CSV:");
        filePath = Console.WriteLine();
        try
        {
            string connectionString = "server=localhost;user=root;database=projekt;port=3306;password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');

                        string name = values[0];
                        string contactInfo = values[1];
                        decimal rating = decimal.Parse(values[2]);

                        string query = "INSERT INTO suppliers (name, contact_info, rating) VALUES (@Name, @ContactInfo, @Rating)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@ContactInfo", contactInfo);
                        command.Parameters.AddWithValue("@Rating", rating);
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Data from CSV file inserted successfully into 'suppliers' table.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error inserting data from CSV into 'suppliers' table: " + ex.Message);
        }
    }
    static void DeleteProduct()
    {
        string name = "";
        Console.WriteLine("Name: ");
        name = Console.ReadLine();
        string connectionString = "server=localhost;user=root;database=projekt;port=3306;password=;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {  
                connection.Open();
                string query = "DELETE FROM products WHERE name = @Name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
                Console.WriteLine("Úspěšně smazáno");
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba při smazani záznamu z tabulky 'products': " + ex.Message);
                throw;
            }
        }
        
    }

    static void DeleteSupplier()
    {
        string name = "";
        Console.WriteLine("Name: ");
        name = Console.ReadLine();
        string connectionString = "server=localhost;user=root;database=projekt;port=3306;password=;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {  
                connection.Open();
                string query = "DELETE FROM suppliers WHERE name = @Name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
                Console.WriteLine("Úspěšně smazáno");
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba při smazani záznamu z tabulky 'suppliers': " + ex.Message);
                throw;
            }
        }
    }

    static void DeleteCustomer()
    {
        string name = "";
        Console.WriteLine("Name: ");
        name = Console.ReadLine();
        string connectionString = "server=localhost;user=root;database=projekt;port=3306;password=;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {  
                connection.Open();
                string query = "DELETE FROM customers WHERE name = @Name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
                Console.WriteLine("Úspěšně smazáno");
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba při smazani záznamu z tabulky 'customers': " + ex.Message);
                throw;
            }
        }
    }

    static void DeleteOrder()
    {
        string order_id = "";
        Console.WriteLine("order_id: ");
        name = Console.ReadLine();
        string connectionString = "server=localhost;user=root;database=projekt;port=3306;password=;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {  
                connection.Open();
                string query = "DELETE FROM orders WHERE order_id = @ID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", order_id);
                command.ExecuteNonQuery();
                Console.WriteLine("Úspěšně smazáno");
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba při smazani záznamu z tabulky 'orders': " + ex.Message);
                throw;
            }
        }
    }

            connection.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Chyba: " + ex.Message);
        }
        
    }



}

