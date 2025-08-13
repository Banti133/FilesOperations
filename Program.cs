// See https://aka.ms/new-console-template for more information

using FilesOperations;

Console.WriteLine("Hello, World!");

//serialization and deserialization example
//SerializationExample();
static void SerializationExample()
{
    SmartThings smart = new SmartThings("Smart Light", "Lighting");
    smart.JsonSerializeMethod(smart);
}

//SynchronousGetnumbers();
static void SynchronousGetnumbers()
{
    Console.WriteLine($"Start: {DateTime.Now.ToLongTimeString()}");
    var numbers = AsynchronousFile.GetNumbers(1, 10);
    foreach (var number in numbers)
    {
        Console.WriteLine($"Number: {number}");
    }
    Console.WriteLine($"End: {DateTime.Now.ToLongTimeString()}");
}

AsyncGetNumbers();
static async void AsyncGetNumbers()
{
    Console.WriteLine($"Start: {DateTime.Now.ToLongTimeString()}");
    var numbersAsync = AsynchronousFile.GetNumbersAsync(1, 11);
    await foreach (var number in numbersAsync)
    {
        Console.WriteLine(number);
    }
    Console.WriteLine($"End: {DateTime.Now.ToLongTimeString()}");
}


//ProdLinqOperationsExample();
static void ProdLinqOperationsExample()
{
    ProdLinq prodLinq = new ProdLinq();
    prodLinq.basiclinq();
    prodLinq.wherelinq();
    prodLinq.orderbylinq();
    prodLinq.groupbylinq();
    prodLinq.orderbythenbylinq();
    prodLinq.takeLinq();
    prodLinq.firstorfirstdefault();
    prodLinq.singleorsingledefault();
}

//LinqOperations();
static void LinqOperations()
{
    LinqDemo linqDemo = new LinqDemo();
    linqDemo.TakeLinq();
    linqDemo.linqtypearraylist();
    linqDemo.basiclinq();
    linqDemo.UsingwhereLinq();
    linqDemo.UsingOrderByLinq();
    linqDemo.GroupByLinq();
    linqDemo.OrderByThenByLinq();
    linqDemo.LinqFirstorFirstDefault();
    linqDemo.SingleorSingleDefault();
}

//string filepath = "ProductS.txt";
//ProductclassDemo(filepath);
static void ProductclassDemo(string filepath)
{
    ProductClass product = new ProductClass();
    Console.WriteLine("Enter product ID:");
    product.productId = Console.ReadLine();
    Console.WriteLine("Enter product name:");
    product.productName = Console.ReadLine();
    Console.WriteLine("Enter product price:");
    product.productPrice = Convert.ToDouble(Console.ReadLine());
    product.writeProduct(product, filepath);
    product.readProduct(filepath);
}

//string FileName="ConsultingAssociates.txt";
//ConsultingAssociatesClass(FileName);

static void ConsultingAssociatesClass(string filename)
{
    ConsultingAssociates consultingAssociates = new ConsultingAssociates();

    Console.WriteLine("Enter consulting associate name:");
    consultingAssociates.Name = Console.ReadLine();
    Console.WriteLine("Enter consulting associate ID:");
    consultingAssociates.ConId = Console.ReadLine();
    Console.WriteLine("Enter consulting associate email:");
    consultingAssociates.Email = Console.ReadLine();
    Console.WriteLine("Enter client name:");
    consultingAssociates.ClientName = Console.ReadLine();
    consultingAssociates.AddAssociates(consultingAssociates, filename);
    consultingAssociates.ReadAssociates(filename);

}


//string? filePath = "SmartThings.txt";

//FileClass(filePath);
static object FileClass(string filePath)
{

    while (true)
    {
        Console.WriteLine("\n--- SmartThings Management System ---");
        Console.WriteLine("1. Add New SmartThing");
        Console.WriteLine("2. View All SmartThings");
        Console.WriteLine("3. Search SmartThing by Name");
        Console.WriteLine("4. Delete SmartThing");
        Console.WriteLine("5. Update SmartThing Type");
        Console.WriteLine("6. Count SmartThings by Type");
        Console.WriteLine("7. Exit");
        Console.Write("Choose an option (1-7): ");

        string? choice = Console.ReadLine();
        switch (choice)
        {

            case "1":
                SmartThings.AddSmartThing(filePath);
                break;
            case "2":
                SmartThings.ViewSmartThings(filePath);
                break;
            case "3":
                Console.Write("Enter name to search: ");
                string? searchName = Console.ReadLine();
                SmartThings.SearchSmartThing(filePath, searchName ?? "");
                break;
            case "4":
                Console.Write("Enter name to delete: ");
                string? deleteName = Console.ReadLine();
                SmartThings.DeleteSmartThing(filePath, deleteName ?? "");
                break;

            case "5":
                Console.Write("Enter name to update: ");
                string? updateName = Console.ReadLine();
                SmartThings.UpdateSmartThing(filePath, updateName ?? "");
                break;
            case "6":
                SmartThings.CountSmartThingsByType(filePath);
                break;
            case "7":
                Console.WriteLine("Exiting SmartThings System. Goodbye!");
                continue;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;

        }
    }
}


