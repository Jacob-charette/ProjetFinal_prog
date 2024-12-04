using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class ValidationInput
    {
        public static bool isNomValide(string nom)
        {
            if (!string.IsNullOrEmpty(nom.Trim()))
                return true;
            else
                return false;
        }
        public static bool isLienValide(string lien)
        {
            if (Uri.IsWellFormedUriString(lien, UriKind.Absolute))
                return true;
            else
                return false;
        }
        public static bool isPrixValide(string prix)
        {
            int p = 0;
            if (int.TryParse(prix, out p))             
                    return true;
            
            else
                return false;
        }
    }
}
