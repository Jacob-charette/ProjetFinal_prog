using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class SessionManager
    {
        private static SessionManager _instance;
        public static SessionManager Instance => _instance ??= new SessionManager();

        private SessionManager() { }

        // Variable de session : adminCon
        public bool AdminCon { get; set; } = false;
        // Variable de session : adherentCon
        public bool AdherentCon { get; set; } = false;
    }
}
