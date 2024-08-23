using cinema.Models;

namespace cinema.Services
{
    public interface AccountService
    {
        public bool checkLogin(string email, string password);

        public bool register(Account account);

        public bool update(Account account);

        public dynamic findById(int id);
        public dynamic findAll();

        public dynamic findByEmail(string email);

        bool VerifyAccountAsync(string email);
    }
}
