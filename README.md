# LINQDemo

Welcome to the LINQDemo repository! This project demonstrates the use of Language Integrated Query (LINQ) in C# with examples and explanations.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Examples](#examples)
- [Contributing](#contributing)
- [License](#license)

## Introduction

LINQ (Language Integrated Query) is a powerful feature in C# that allows developers to write queries directly in the code using a syntax similar to SQL. This repository contains various examples demonstrating how to use LINQ to query collections and databases.

## Features

- Demonstrates basic to advanced LINQ queries.
- Includes examples for working with different data sources.
- Showcases the use of various LINQ operators.
- Provides explanations and comments for better understanding.

## Installation

To get started with this project, follow these steps:

1. Clone the repository:
    ```bash
    git clone https://github.com/OneSAHDEVSINH/LINQDemo.git
    ```

2. Open the project in your favorite IDE (e.g., Visual Studio, Rider).

3. Restore the NuGet packages:
    ```bash
    dotnet restore
    ```

## Usage

To run the examples provided in this project, follow these steps:

1. Build the project:
    ```bash
    dotnet build
    ```

2. Run the project:
    ```bash
    dotnet run
    ```

## Examples

### Example 1: Basic LINQ Query

This example demonstrates a simple LINQ query to filter a list of integers.

```csharp
using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNumbers = from number in numbers
                              where number % 2 == 0
                              select number;

            Console.WriteLine("Even numbers:");
            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
```

### Example 2: LINQ to SQL

This example demonstrates how to use LINQ to query a SQL database.

```csharp
using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Linq;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "your_connection_string_here";
            using (var connection = new SqlConnection(connectionString))
            {
                DataContext db = new DataContext(connection);

                var query = from customer in db.GetTable<Customer>()
                            where customer.City == "Seattle"
                            select customer;

                Console.WriteLine("Customers from Seattle:");
                foreach (var customer in query)
                {
                    Console.WriteLine(customer.Name);
                }
            }
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
}
```

## Contributing

Contributions are welcome! If you would like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Commit your changes.
4. Push your branch to your fork.
5. Create a pull request to the main repository.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
