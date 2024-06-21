namespace LaptopDiscount.nUnitTests
{
    public class DiscountTests
    {
        private EmployeeDiscount _employeeDiscount;
        private EmployeeType _employeeType;
        [SetUp]
        public void Setup()
        {
            _employeeDiscount = new EmployeeDiscount { EmployeeType = EmployeeType.PartTime, Price = 1000.00m};

        }

            // Test 1
            [Test]
            public void PartTimeEmployee()
            {
                // Assign
                var discountCalculator = new EmployeeDiscount
                {
                    EmployeeType = EmployeeType.PartTime,
                    Price = 1000.00m
                };

                // Act
                var result = discountCalculator.CalculateDiscountedPrice();

                // Assert
                Assert.AreEqual(1000m, result, "Part-time employees should not receive any discount.");
            }

            // Test 2
            [Test]
            public void PartialLoadEmployee()
            {
                // Assign
                var discountCalculator = new EmployeeDiscount
                {
                    EmployeeType = EmployeeType.PartialLoad,
                    Price = 1000m
                };

                // Act
                var result = discountCalculator.CalculateDiscountedPrice();

                // Assert
                Assert.AreEqual(950m, result, "Partial load employees should receive a 5% discount.");
            }

            // Test Case 3: Verifying 10% discount for FullTime employees
            [Test]
            public void FullTimeEmployee()
            {
                // Assign
                var discountCalculator = new EmployeeDiscount
                {
                    EmployeeType = EmployeeType.FullTime,
                    Price = 1000m
                };

                // Act
                var result = discountCalculator.CalculateDiscountedPrice();

                // Assert
                Assert.AreEqual(900m, result, "Full-time employees should receive a 10% discount.");
            }

            // Test Case 4: Verifying 20% discount for CompanyPurchasing employees
            [Test]
            public void CompanyPurchasingEmployee()
            {
                // Assign
                var discountCalculator = new EmployeeDiscount
                {
                    EmployeeType = EmployeeType.CompanyPurchasing,
                    Price = 1000m
                };

                // Act
                var result = discountCalculator.CalculateDiscountedPrice();

                // Assert
                Assert.AreEqual(800m, result, "Company purchasing should receive a 20% discount.");
            }

            // Test Case 5
            [Test]
            public void AnyEmployeeWithZeroPrice()
            {
                // Assign
                var discountCalculator = new EmployeeDiscount
                {
                    EmployeeType = EmployeeType.FullTime,
                    Price = 0m
                };

                // Act
                var result = discountCalculator.CalculateDiscountedPrice();

                // Assert
                Assert.AreEqual(0m, result, "Any employee with a zero price should return zero after discount.");
            }

            // Test Case 6: Verifying behavior with high price
            [Test]
            public void CompanyPurchasingEmployeee()
            {
                // Assign
                var discountCalculator = new EmployeeDiscount
                {
                    EmployeeType = EmployeeType.CompanyPurchasing,
                    Price = 100000m
                };

                // Act
                var result = discountCalculator.CalculateDiscountedPrice();

                // Assert
                Assert.AreEqual(80000m, result, "Company purchasing with high price should return correctly discounted price.");
            }
}
}
