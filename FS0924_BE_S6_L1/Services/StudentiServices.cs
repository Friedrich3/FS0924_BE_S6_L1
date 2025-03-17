using FS0924_BE_S6_L1.Data;

namespace FS0924_BE_S6_L1.Services
{
    public class StudentiServices
    {
        private readonly PraticaS6L1 _context;
        public StudentiServices(PraticaS6L1 context)
        {
            _context = context;
        }

    }
}
