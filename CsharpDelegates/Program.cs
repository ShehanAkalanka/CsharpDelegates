using CsharpDelegates.Data;
using System.Diagnostics.CodeAnalysis;

class Program
{
    //static bool GetSalaryMoreThan( decimal AvailableBalance)
    //{
    //    return AvailableBalance > 1000;
    //}
    static void Main(string[] args)
    {
        //var accounts = getBalancesMoreThanFiveHundred();
        //var accounts = getBalancesMoreThanProvidedAmount(2000);
        //var accounts = getBalancesMoreThanProvidedAmountWithDelegates(2000,new GetSalaryMoreThanDelegate(GetSalaryMoreThan)); even in here when we wanted to change the expression we have to again create more than one methods
        // to solve that we can use lamda expressions
        //var accounts = getBalancesMoreThanProvidedAmountWithDelegates(2000, new GetSalaryMoreThanDelegate(AvailableBalance => AvailableBalance>2000)); also here we can just remove the delegate call and also we can remove the pointer method=> GetSalaryMoreThan
        //var accounts = getBalancesMoreThanProvidedAmountWithDelegates(2000, AvailableBalance => AvailableBalance > 2000);
        var accounts = getBalancesMoreThanProvidedAmountWithDelegates1hundredPresent(x => x.AvailableBalance > 2000);
        foreach (var account in accounts)
        {
            Console.WriteLine(account);
        }
    }

    //first method - when we use this it does not support at all for reusability/ and also extensibility
    private static List<Account> getBalancesMoreThanFiveHundred()
    {
        List<Account> accounts = [];
        using var dbcontext = new DataContext();
        var dbAccounts = dbcontext.Accounts.ToList();
        foreach (var account in dbAccounts)
        {
            if (account.AvailableBalance > 1000)
            {
                accounts.Add(account);
            }
        }
        return accounts;
    }

    //second method - supports slidely to reusability and extinsability (as a presentage - 20%)
    //why because we can just call it with the amount from anyware
    private static List<Account> getBalancesMoreThanProvidedAmount(decimal amount)
    {
        List<Account> accounts = [];
        using var dbcontext = new DataContext();
        var dbAccounts = dbcontext.Accounts.ToList();
        foreach (var account in dbAccounts)
        {
            if (account.AvailableBalance > amount)
            {
                accounts.Add(account);
            }
        }
        return accounts;
    }

    //what more we can do to increase the reusability and extinsabilty?
    //in the above method, yes we have encapsulated the amount but what if we can isolate the if condition
    //so what if it allows us to put this if expression as an argument 
    // that is where delegates come to help

    private static List<Account> getBalancesMoreThanProvidedAmountWithDelegates(decimal amount, GetSalaryMoreThanDelegate getSalaryMoreThanDelegate)
    {
        List<Account> accounts = [];
        using var dbcontext = new DataContext();
        var dbAccounts = dbcontext.Accounts.ToList();
        foreach (var account in dbAccounts)
        {
            if (getSalaryMoreThanDelegate(account.AvailableBalance)) // here I'm delegating my condition with my delegate
            {
                accounts.Add(account);
            }
        }
        return accounts;
    }

    //up to this stage we could improve our  reusability and extinsabilty upto more that 80% but it's not 100% so let's make it 100%
    // by doing this we what we expect is, allow us to access and check any condition for any varible in account data
    //lets create another delegate for that 
    //private static List<Account> getBalancesMoreThanProvidedAmountWithDelegates1hundredPresent(GetAccountDelegate getAccountDelegate)
    //{
    //private static List<Account> getBalancesMoreThanProvidedAmountWithDelegates1hundredPresent(Func<Account,bool> getAccountFuncDelegate)
    //{

    private static List<Account> getBalancesMoreThanProvidedAmountWithDelegates1hundredPresent(Predicate<Account> getAccountPredicateDelegate)
    {

        List<Account> accounts = [];
        using var dbcontext = new DataContext();
        var dbAccounts = dbcontext.Accounts.ToList();
        foreach (var account in dbAccounts)
        {
            if (getAccountPredicateDelegate(account)) // here I'm delegating my condition with my delegate
            {
                accounts.Add(account);
            }
        }
        return accounts;
    }

}

// here we generate the delegate 
// return type of the delegate depends on what is our business logic returns 
//So here the business logic is "If" condiation, so it will always retun a boolean
public delegate bool GetSalaryMoreThanDelegate(decimal AvailableBalance);
public delegate bool GetAccountDelegate(Account account);


// normally we just do not create this kind of delegates 90% of the time 
//microsoft provides us predifined delegates 
//most used them are 
// Func, Action, Predicate

// if your delegate return any information we use Func Delegate
// if you have a nun-returnable signature you can use Action Delegate
//If you are exactly returning ang if you have exact generic type you use predicate
