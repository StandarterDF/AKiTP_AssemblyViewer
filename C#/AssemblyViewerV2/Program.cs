using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyViewerV2
{
    internal static class Program
    {

        public static Settings AppSettings { get; private set; }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppSettings = Settings.LoadOrCreate();

            Application.Run(new ProgramMainForm());
        }
    }
}
