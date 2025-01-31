using DatabaseInterfaceDemo.Model;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
namespace DatabaseInterfaceDemo.Controller
{
    public static class ObjectFactory
    {
        public static List<object> createEmpleadoList()
        {
            List<object> empleadoList = new List<object>();

            string[] firstNames = new string[]
{
            "James", "John", "Robert", "Michael", "William", "David", "Joseph", "Charles", "Thomas", "Christopher",
            "Daniel", "Paul", "Mark", "Donald", "George", "Kenneth", "Steven", "Edward", "Brian", "Ronald",
            "Anthony", "Kevin", "Jason", "Matthew", "Gary", "Timothy", "Jose", "Andrew", "Joshua", "Nathan",
            "Larry", "Justin", "Frank", "Scott", "Eric", "Stephen", "Andrew", "Raymond", "Gregory", "Samuel",
            "Patrick", "Jack", "Dennis", "Jerry", "Tyler", "Aaron", "Henry", "Douglas", "Peter", "Adam",
            "Zachary", "Walter", "Kyle", "Harold", "Carl", "Arthur", "Ryan", "Roger", "Joe", "Juan",
            "Eugene", "Carlos", "Wayne", "Albert", "Gerald", "Keith", "Ralph", "Roy", "Louis", "Billy",
            "Bruce", "Willie", "Jordan", "Dylan", "Bobby", "Johnny", "Billy", "Albert", "Gene", "Carl",
            "Mason", "Chad", "Micheal", "Brandon", "Philip", "Elliot", "Francis", "Marvin", "Charlie", "Clifford",
            "Ernest", "Max", "Dean", "Lawrence", "Oliver", "Calvin", "Eddie", "Terry", "Melvin", "Vernon",
            "Todd", "Wesley", "Vincent", "Isaac", "Martin", "Leonard", "Leroy", "Dale", "Stanley", "Maurice",
            "Clyde", "Norman", "Jack", "Roy", "Leslie", "Edwin", "Victor", "Clinton", "Hugh", "Arnold",
            "Manuel", "Willard", "Lloyd", "Jeremiah", "Jack", "Barry", "Chester", "Simon", "Lyle", "Sam"
};

            // Array of 150 random middle names
            string[] middleNames = new string[]
            {
            "Lee", "Ray", "James", "William", "Allen", "John", "Joe", "Lynn", "David", "Eugene",
            "Brett", "Renee", "Scott", "Gordon", "Francis", "Patrick", "Marvin", "David", "Joseph", "Thomas",
            "Martin", "Roy", "Peter", "Robert", "Richard", "Steven", "Francis", "Douglas", "Keith", "James",
            "Paul", "Edward", "Michael", "Gregory", "Charles", "Ronald", "Dennis", "Brian", "Mark", "Wayne",
            "Terry", "Gene", "Walter", "Samuel", "Bradley", "Ryan", "Shane", "George", "Cameron", "Bobby",
            "Aaron", "Victor", "Ralph", "Eric", "Lloyd", "Greg", "Gary", "Carl", "Troy", "Max",
            "Zachary", "Lee", "Jason", "Joe", "David", "Glen", "John", "Paul", "Daniel", "Earl",
            "Randall", "Barry", "Marvin", "Stanley", "Phillip", "Vernon", "Roger", "Dale", "John",
            "Christopher", "Bobby", "Bryan", "Randy", "Keith", "Roy", "Bert", "Lee", "Robert",
            "Glen", "Rick", "Martin", "Louis", "Jeffrey", "Harold", "Dustin", "Lawrence", "Ted",
            "Adrian", "Carlton", "Vern", "Fred", "Shane", "Leo", "Alvin", "Russell", "Russell",
            "Jesse", "Jack", "Jon", "Chester", "Ernest", "Calvin", "Frank", "Timothy", "Mark",
            "Dustin", "Earl", "Gordon", "Lee", "Julian", "Maurice", "Freddie", "Ramon", "Grant"
            };

            // Array of 150 random last names
            string[] lastNames = new string[]
            {
            "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson",
            "Martinez", "Hernandez", "Lopez", "Gonzalez", "Perez", "Taylor", "Anderson", "Thomas", "Jackson", "White",
            "Harris", "Martin", "Thompson", "Moore", "Garcia", "Martinez", "Roberts", "Miller", "Clark", "Lewis",
            "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Adams",
            "Baker", "Nelson", "Carter", "Mitchell", "Perez", "Roberts", "Evans", "Green", "Hall", "Rivera",
            "Campbell", "Young", "Bennett", "Gomez", "Gray", "James", "Watson", "Brooks", "Kelly", "Sanders",
            "Price", "Baker", "Cooper", "Murphy", "Bailey", "Bell", "Gonzales", "Reed", "Cook", "Morgan",
            "Bell", "Lee", "Graham", "Perry", "Woods", "Russell", "Jennings", "Patterson", "Long", "Foster",
            "Sanders", "Butler", "Barnes", "Hughes", "Russell", "Simmons", "Fisher", "Williamson", "Ryan", "West",
            "Jordan", "Griffin", "Harrison", "Cunningham", "Henry", "Douglas", "Ford", "Gibson", "Graham",
            "Hunt", "Dunn", "Mason", "Munoz", "Burns", "Rogers", "Williamson", "Chavez", "Kim", "Cameron",
            "Vasquez", "Patel", "Martinez", "Chavez", "Jordan", "Bryant", "Hughes", "Dean", "Henderson", "Warren",
            "Cole", "Schmidt", "Barrett", "Craig", "Hayes", "Gibson", "Frazier", "Freeman", "Stewart", "Harrison"
            };

            decimal[] monthlySalaries = new decimal[]
{
            1500.75m, 2300.50m, 1800.25m, 2500.60m, 3200.40m,
            2700.95m, 1900.30m, 2400.70m, 3500.20m, 2000.85m,
            2200.60m, 2900.50m, 2600.00m, 2800.90m, 3000.00m,
            3300.55m, 3100.75m, 2400.00m, 3200.20m, 3500.30m,
            2900.40m, 2500.25m, 2800.60m, 3300.50m, 2200.80m,
            2700.15m, 3500.95m, 3000.40m, 2600.85m, 3000.75m,
            3300.60m, 3100.90m, 2000.50m, 2800.70m, 2200.35m,
            3500.85m, 3300.30m, 3100.50m, 2700.00m, 2900.75m,
            2500.80m, 3000.90m, 3300.15m, 3100.75m, 2400.30m,
            3200.75m, 2800.90m, 3500.60m, 2900.50m, 2600.70m,
            2400.55m, 3000.30m, 3500.90m, 2200.15m, 2900.85m,
            2700.40m, 3100.60m, 3200.20m, 2500.50m, 2200.80m,
            2800.60m, 3300.90m, 3500.75m, 2000.80m, 3100.15m,
            2700.70m, 2900.60m, 2600.30m, 2800.95m, 3200.10m,
            3500.40m, 2200.20m, 3000.10m, 3100.80m, 2900.95m,
            2500.60m, 2200.60m, 3300.50m, 2000.25m, 2700.30m,
            3000.75m, 3500.25m, 2900.80m, 2700.85m, 3100.90m,
            3200.60m, 2200.30m, 2400.70m, 2900.15m, 2500.40m,
            3500.20m, 3300.60m, 3100.25m, 2000.50m, 2700.60m,
            2500.80m, 2900.30m, 3300.40m, 2000.15m, 3200.80m,
            2200.70m, 2400.80m, 3500.60m, 3100.75m, 3000.30m,
            2700.95m, 2500.20m, 3200.50m, 2900.60m, 3300.15m,
            3500.80m, 2500.30m, 2800.95m, 2000.20m, 2700.10m,
            2900.50m, 2400.90m, 3500.30m, 3100.20m, 3200.10m,
            2500.60m, 3300.75m, 2000.40m, 2900.95m, 2700.40m,
            2800.15m, 3200.25m, 3500.95m, 3000.70m, 2200.50m,
            3300.30m, 2500.80m, 2700.80m, 3100.60m, 2000.30m
};


            DateTime currentDate = DateTime.Now;

            // Array of 150 random DateTime entries (over 18 years ago)
            DateTime[] birthDates = new DateTime[150];
            Random random = new Random();

            for (int i = 0; i < 150; i++)
            {
                // Generate a random number of years between 18 and 30 years ago
                int yearsAgo = random.Next(18, 31);

                // Subtract the random number of years from the current date to ensure it's over 18 years ago
                DateTime baseDate = currentDate.AddYears(-yearsAgo);

                // Generate a random month (1 to 12)
                int randomMonth = random.Next(1, 13);

                // Get the number of days in the random month of the base year
                int daysInMonth = DateTime.DaysInMonth(baseDate.Year, randomMonth);

                // Generate a random day (1 to the number of days in the random month)
                int randomDay = random.Next(1, daysInMonth + 1);

                // Create a random birth date with the random year, month, and day
                DateTime randomBirthDate = new DateTime(baseDate.Year, randomMonth, randomDay);

                // Store the random birth date in the array
                birthDates[i] = randomBirthDate;
            }

            int[] eightDigitNumbers = new int[150];
            int[] daysWorked = new int[150];
            
            for (int i = 0; i < 150; i++)
            {
                int randomNumber = random.Next(10000000, 100000000);
                eightDigitNumbers[i] = randomNumber;
                randomNumber = random.Next(0, 1001);
                daysWorked[i] = randomNumber;
            }
            for (int i = 0; i < 124; i++)
            {
                empleadoList.Add(
                   new Empleado(
                    false,
                    firstNames[i],
                    middleNames[i],
                    lastNames[i],
                    monthlySalaries[i],
                    daysWorked[i],
                    birthDates[i],
                    eightDigitNumbers[i]));
            }

            return empleadoList;
        }

        public static List<object> createProductList()
        {

            Random rand = new Random();
            List<object> productList = new List<object>();

            string[] shoppingItems = new string[]
{
            // Food
            "Apple", "Banana", "Orange", "Bread", "Milk", "Cheese", "Yogurt", "Eggs", "Chicken Breast", "Pasta",
            "Rice", "Tomato", "Lettuce", "Cucumber", "Carrot", "Cabbage", "Potato", "Onion", "Garlic", "Salt",
            "Pepper", "Olive Oil", "Honey", "Chocolate Bar", "Cereal", "Peanut Butter", "Jam", "Cookies",
            "Frozen Pizza", "Frozen Vegetables", "Mushrooms", "Spinach", "Apple Juice", "Orange Juice", "Water",
            "Soda", "Energy Drink", "Coffee", "Tea", "Lemonade", "Fruit Salad", "Sandwich", "Granola Bar",
            "Pineapple", "Strawberry", "Blueberry", "Chicken Nuggets", "Burger", "Hot Dog", "Ketchup", "Mustard",
            "Vinegar",

            // Drink
            "Coke", "Pepsi", "Beer", "Wine", "Whiskey", "Vodka", "Gin", "Tequila", "Rum", "Cocktail Mix",
            "Iced Tea", "Fruit Smoothie", "Sparkling Water", "Mineral Water", "Milkshake", "Hot Chocolate",
            "Sports Drink", "Fruit Punch", "Green Tea", "Black Tea", "Cappuccino", "Latte", "Espresso", "Macchiato",

            // Furniture
            "Sofa", "Coffee Table", "Dining Table", "Chair", "Armchair", "Bookshelf", "Bed", "Dresser", "Wardrobe",
            "TV Stand", "Desk", "Office Chair", "Nightstand", "Recliner", "Lampshade", "Chest of Drawers", "Mirror",
            "Cabinet", "Bookshelf", "TV Unit", "Cushion", "Curtains", "Dining Chairs", "Storage Bench", "Side Table",
            "Patio Chair", "Filing Cabinet", "Coffee Mug Holder", "Bean Bag", "Laundry Basket",

            // Clothing
            "T-shirt", "Jeans", "Sweater", "Jacket", "Coat", "Dress", "Skirt", "Shorts", "Blouse", "Shirt",
            "Sweatpants", "Leggings", "Hoodie", "Jumpsuit", "Belt", "Socks", "Gloves", "Hat", "Scarf", "Pajamas",
            "Shoes", "Sneakers", "Boots", "Flip Flops", "Sandals", "Dress Shoes", "Slippers", "Tie", "Tank Top",
            "Cardigan", "Robe", "Raincoat", "Underwear", "Bra", "Bikini", "Swimwear", "Vest", "Tracksuit", "Overcoat",
            "Blazer", "Suit", "Tights", "Denim Jacket"
};

            Category[] categoryList = new Category[149];
            Unit_Type[] unitList = new Unit_Type[149];

            for (int i = 0; i <= 75; i++)
            {
                categoryList[i] = Category.FOOD_DRINK;
            }
            for (int i = 0; i <= 48; i++)
            {
                unitList[i] = Unit_Type.Per_100g;
            }
            for (int i = 49; i <= 75; i++)
            {
                unitList[i] = Unit_Type.Per_100ml;
            }
            for (int i = 76; i <= 105; i++)
            {
                categoryList[i] = Category.FURNITURE;
            }

            for (int i = 76; i < 149; i++ )
            {
                unitList[i] = Unit_Type.Per_Unit;
            }
            for (int i = 106; i < 149; i++)
            {
                categoryList[i] = Category.CLOTHING;
            }
            decimal[] itemPrices = new decimal[shoppingItems.Length];
            int[] stockList = new int[shoppingItems.Length];
            // Assign prices to each item in the array
            for (int i = 0; i < shoppingItems.Length; i++)
            {
                if (i < 50) // Food items
                {
                    itemPrices[i] = Math.Round((decimal)(rand.NextDouble() * (1.00 - 0.50) + 0.50), 2); // Price between $0.50 and $10.00
                    stockList[i] = rand.Next(0, 100);
                }
                else if (i < 74) // Drink items (24 items)
                {
                    itemPrices[i] = Math.Round((decimal)(rand.NextDouble() * (1.00 - 0.50) + 0.50), 2); // Price between $0.50 and $5.00
                    stockList[i] = rand.Next(0, 100);
                }
                else if (i < 104) // Furniture items (30 items)
                {
                    itemPrices[i] = Math.Round((decimal)(rand.NextDouble() * (300.00 - 20.00) + 20.00), 2); // Price between $20.00 and $300.00
                    stockList[i] = rand.Next(0, 10);
                }
                else // Clothing items (40 items)
                {
                    itemPrices[i] = Math.Round((decimal)(rand.NextDouble() * (100.00 - 10.00) + 10.00), 2); // Price between $10.00 and $100.00
                    stockList[i] = rand.Next(0, 50);
                }
            }

            for (int i = 0; i < shoppingItems.Length; i++)
            {
                productList.Add(
                   new Producto(
                    false,
                    shoppingItems[i],
                    categoryList[i],
                    itemPrices[i],
                    unitList[i],
                    stockList[i],
                    i));
            }

            return productList;
        }

    }

}
