using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Where(c => c.Orders.Sum(o => o.Total) > limit);
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Select(c => (c, suppliers.Where(s => s.Country == c.Country && s.City == c.City)));
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null && suppliers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Select(c => (c, suppliers.GroupBy(s => s.Country == c.Country && s.City == c.City)
                                                            .Where(k => k.Key)
                                                            .SelectMany(group => group)));
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Where(c => c.Orders.Length > 0 && c.Orders.Sum(o => o.Total) > limit);
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Select(c => new ValueTuple<Customer, DateTime>(c, c.Orders.Select(d => d.OrderDate)
                                                                                                .OrderBy(d => d.Date)
                                                                                                .FirstOrDefault()))
                            .Where(c => c.Item1.Orders.Length > 0);
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Select(c => new ValueTuple<Customer, DateTime>(c, c.Orders.Select(d => d.OrderDate)
                                                                                                .OrderBy(d => d.Date)
                                                                                                .FirstOrDefault()))
                .Where(c => c.Item1.Orders.Length > 0)
                .OrderBy(d => d.Item2.Date);
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Where(c => c.PostalCode.Any(l => !char.IsDigit(l) || c.Region == null ||
                                                                        !c.Phone.Contains('(') || !c.Phone.Contains(')')));
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            return products.GroupBy(category => category.Category)
                .Select(categoryGroup => new Linq7CategoryGroup()
                {
                    Category = categoryGroup.Key,
                    UnitsInStockGroup = products.Where(item => item.Category == categoryGroup.Key)
                        .GroupBy(unit => unit.UnitsInStock)
                        .Select(unit => new Linq7UnitsInStockGroup()
                        {
                            UnitsInStock = unit.Key,
                            Prices = products.Where(price => price.Category == categoryGroup.Key && price.UnitsInStock == unit.Key)
                                                .Select(z => z.UnitPrice)
                        })
                });
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            return products.GroupBy(product => product.UnitPrice <= cheap ? cheap :
                                (product.UnitPrice > cheap && product.UnitPrice <= middle ? middle : expensive))
                            .Select(group => (group.Key, group.AsEnumerable()))
                            .OrderBy(x => x.Item1).ToList();

        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Select(item => new ValueTuple<string, int, int>(item.City,
                    Convert.ToInt32(customers.Where(x => x.City == item.City)
                            .Select(x => x.Orders.Sum(order => order.Total)).Average()),
                    Convert.ToInt32(customers.Where(x => x.City == item.City).Average(x => x.Orders.Length))))
                .Distinct()
                .ToList();

        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            if (suppliers == null)
            {
                throw new ArgumentNullException();
            }

            return suppliers.Select(s => s.Country)
                            .Distinct()
                            .OrderBy(s => s.Length)
                            .ThenBy(c => c)
                            .Aggregate((current, next) => current + next);
        }
    }
}