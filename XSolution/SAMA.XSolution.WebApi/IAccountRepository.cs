namespace SAMA.XSolution.WebApi
{
    interface IAccountRepository
    {
        string GetHashedPassword(string userName);
    }

    class  AccountRepository : IAccountRepository
    {
        public string GetHashedPassword(string userName)
        {
            return "Foo Bar";
        }
    }
}