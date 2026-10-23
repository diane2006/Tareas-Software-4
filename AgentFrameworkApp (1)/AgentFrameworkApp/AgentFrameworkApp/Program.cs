using System;
using System.Windows.Forms;
using AgentFrameworkApp.Forms;

namespace AgentFrameworkApp;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
