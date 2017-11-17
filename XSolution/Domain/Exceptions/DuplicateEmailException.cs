using System;

namespace SAMA.XSolution.Domain.Exceptions
{
    public class DuplicateEmailException:Exception
    {
        public string Email { get; private set; }

        public DuplicateEmailException(string email)
        {
            Email = email;
        }
    }
}
