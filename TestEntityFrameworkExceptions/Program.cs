using TestEntityFrameworkExceptions.Models;

namespace TestEntityFrameworkExceptions;

class Program {
    static void Main(string[] args) {
        var context = new TestContext();

        var transport = new Transport();
        context.Add(transport);
        context.SaveChanges();
    }
}