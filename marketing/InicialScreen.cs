using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace marketing
{
    public static class InicialScreen
    {
        static InicialForm sf = null;

        /// <summary>
        /// Displays the splashscreen
        /// </summary>
        public static void ShowInicialScreen()
        {
            if (sf == null)
            {
                sf = new InicialForm();
                sf.ShowInicialScreen();
            }
        }

        /// <summary>
        /// Closes the SplashScreen
        /// </summary>
        public static void CloseInicialScreen()
        {
            if (sf != null)
            {
                sf.CloseInicialScreen();
                sf = null;
            }
        }

        public static void UdpateStatusText(string Text)
        {
            if (sf != null)
                sf.UdpateStatusText(Text);

        }

    }
}
