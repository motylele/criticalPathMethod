using System;
using System.Collections.Generic;
using System.Text;

namespace CPM
{
    class Program
    {
        public static void Main(string[] args)
        {
            CPM cpm = new CPM();
            Node[] arr = null;

            arr = cpm.readNodes(arr);
            arr = cpm.earliestTime(arr);
            arr = cpm.latestTime(arr);

            cpm.criticalPath(arr);
            cpm.show(arr);
            cpm.Gannt(arr);
        }
    }
}
