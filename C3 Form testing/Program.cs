using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C3_Form_testing
{
    internal static class Program
    {
        public static Boolean chk = false;
        public static Boolean chkWindowSize = true;
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Form5());
        }
    }
}
