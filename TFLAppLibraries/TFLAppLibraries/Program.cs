using System.Data;
using Microsoft.VisualStudio.OLE.Interop;
using System.Diagnostics;
using QuickGraph;
using System.IO;
using Microsoft.Msagl.GraphmapsWithMesh;
using System;

namespace TFLAppLibraries;

class Program
{
    static void Main(string[] args)
    {
        Menu networkMenu = new Menu();

        networkMenu.StartJourney();
    }
}
