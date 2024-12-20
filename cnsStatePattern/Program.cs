using ATMStatePattern;

namespace cnsStatePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AtmContext atm = new AtmContext(1, 5000, true, 0.1);
            atm.Notify = Console.WriteLine;

            atm.InsertPin("1234");
            atm.PerformOperation("withdraw", 5000); 
            atm.PerformOperation("exit");           

            atm.ReloadCash(2000);

            atm.InsertPin("1234");
            atm.PerformOperation("withdraw", 500);  

            atm.FixConnection();
        }
    }
}
