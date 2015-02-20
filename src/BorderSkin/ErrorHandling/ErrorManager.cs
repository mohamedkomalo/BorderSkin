using System;
using System.Threading;
using System.Windows.Forms;

namespace BorderSkin.ErrorHandling
{
    internal class ErrorManager
    {

        static readonly string DefaultErrorMessage = "This error was raised due to a programing bug.\n" + Application.ProductName + " will now close, all windows borders will be restored." + "You can help developing the application by reporting the information in" + "\"More Details\" to the developer.";

        public static void Start()
        {
            AppDomain.CurrentDomain.UnhandledException += ErrorManaging;
            Application.ThreadException += ErrorManaging;
        }

        public static void Stop()
        {
            Application.ThreadException -= ErrorManaging;
            AppDomain.CurrentDomain.UnhandledException -= ErrorManaging;
        }

        public static void ErrorManaging(object sender, ThreadExceptionEventArgs e)
        {
            ProccessError(e.Exception);
        }

        public static void ErrorManaging(object sender, UnhandledExceptionEventArgs args)
        {
            ProccessError((Exception)args.ExceptionObject);
        }

        public static void ProccessError(Exception exception)
        {
            ProccessError(exception, DefaultErrorMessage);
        }

        public static void ProccessError(Exception exception, string message)
        {
            try {
                Program.WindowsHook.Stop();
                Program.BorderSkinningManager.Stop();

            } catch (Exception) {
            } finally {
                ErrorDialogue.ShowDialog(message, exception);
                Environment.Exit(0);
            }
        }
    }
}
