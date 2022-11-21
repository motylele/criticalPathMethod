using System;
using System.Collections.Generic;

namespace CPM
{
    class CPM
    {
        public CPM() { }
        public int n { get; set; } //liczba zadań
        public int Cmax { get; set; }
        List<Node> criticalList { get; set; } //sciezka krytyczna

        public Node[] readNodes(Node[] arr)
        {
            Console.Write("Podaj liczbę zadań: ");

            n = Convert.ToInt32(Console.ReadLine());
            arr = new Node[n];
            
            for(int i = 0; i < n; i++)
            {
                Console.Write("Zadanie {0}: ", i + 1);
                string Z = Console.ReadLine();

                Node check = new Node();
                check = check.findNode(arr, i, Z);
                if (check == null)
                {

                    Console.Write("Długość trwania: ");
                    int p = Convert.ToInt32(Console.ReadLine());
                    Node node = new Node(Z, p);

                    if (i > 0)
                    {
                        Console.Write("Liczba bezpośrednich przodków: ");
                        int m = Convert.ToInt32(Console.ReadLine());
                        if (m != 0)
                        {
                            node.prev = new Node[m];
                            for (int j = 0; j < m; j++)
                            {
                                Console.Write("Podaj nazwe przodka {0}: ", j + 1);
                                string Zp = Console.ReadLine();

                                Node tmp = new Node();
                                tmp = tmp.findNode(arr, i, Zp);

                                if (tmp != null)
                                {
                                    node.prev[j] = tmp;
                                    arr[tmp.findI(arr, i, tmp)] = tmp.addNextNode(tmp, node);
                                }
                                else
                                {
                                    Console.WriteLine("Przodek o podanej nazwie nie istnieje!");
                                    j -= 1;
                                }
                            }
                        }
                    }
                    arr[i] = node;
                }
                else
                {
                    Console.WriteLine("Zadanie o tej nazwie już!");
                    i -= 1;
                }
            }
            return arr;
        }
        public Node[] earliestTime(Node[] arr)
        {
            arr[0].ee = arr[0].es + arr[0].p;
            for(int i = 1; i < n; i++)
            {
                foreach (Node node in arr[i].prev)
                {
                    if(arr[i].es < node.ee)
                    {
                        arr[i].es = node.ee;
                    }
                }
                arr[i].ee = arr[i].es + arr[i].p;
            }
            return arr;
        }
        public Node[] latestTime(Node[] arr)
        {
            arr[n - 1].le = arr[n - 1].ee;
            arr[n - 1].ls = arr[n - 1].le - arr[n - 1].p;

            for(int i = n - 2; i >= 0; i--)
            {
                foreach(Node node in arr[i].next)
                {
                    if(arr[i].le == 0)
                    {
                        arr[i].le = node.ls;
                    }
                    else if(arr[i].le > node.ls)
                    {
                        arr[i].le = node.ls;
                    }
                }
                arr[i].ls = arr[i].le - arr[i].p;
            }
            return arr;
        }
        public void criticalPath(Node[] arr)
        {
            criticalList = new List<Node>();
            Node tmp = new Node();
            int i = 0;

            foreach (Node node in arr)
            {
                if ((node.es - node.ls == 0) || (node.ee - node.le == 0))
                {
                    if ((node.es != tmp.es && node.ls != tmp.ls && tmp.ee == node.es) || i == 0)
                    {
                        criticalList.Add(node);
                        Console.Write("{0} ", node.Z);
                        i++;
                        tmp = node;
                    }
                }
            }
            Cmax = arr[arr.Length - 1].ee;
            Console.WriteLine("\nC max = {0}", Cmax);
        }

        public void show(Node[] arr)
        {
            foreach(Node node in arr)
            {
                Console.WriteLine("{0}: es={1}, ls={2}, ee={3}, le={4}",node.Z, node.es, node.ls, node.ee, node.le);
            }
        }
        public void Gannt(Node[] arr)
        {
            List<Node> list = new List<Node>();
            string machine1 = "M1: ";
            string machine2 = "M2: ";
            string machine3 = "M3: ";
            string machine4 = "M4: ";
            string machine5 = "M5: ";
            int[] counter = { 0, 0, 0, 0};
            Console.WriteLine("Harmonogram Gannta");

            foreach(Node node in arr)
            {
                if (node.In(criticalList))
                {
                    machine1 += "|" + node.es + ":" + node.ee + "|" + node.Z + "   ";
                }
                else
                {
                    if(counter[0] <= node.ee && counter[0] + node.p <= Cmax)
                    {
                        machine2 += "|" + node.es + ":" + node.ee + "|" + node.Z + "   ";
                        counter[0] = node.ee;
                    }
                    else if(counter[1] <= node.ee && counter[1] + node.p <= Cmax)
                    {
                        machine3 += "|" + node.es + ":" + node.ee + "|" + node.Z + "   ";
                        counter[1] = node.ee;
                    }
                    else if(counter[2] <= node.ee && counter[2] + node.p <= Cmax)
                    {
                        machine4 += "|" + node.es + ":" + node.ee + "|" + node.Z + "   ";
                        counter[2] = node.ee;
                    }
                    else if(counter[3] <= node.ee && counter[3] +node.p <= Cmax)
                    {
                        machine5 += "|" + node.es + ":" + node.ee + "|" + node.Z + "   ";
                        counter[3] = node.ee;
                    }

                }
            }

            Console.WriteLine(machine1); 
            if(machine2 != "M2: ")
            {
                Console.WriteLine(machine2);
            }
            if (machine3 != "M3: ")
            {
                Console.WriteLine(machine3);
            }
            if (machine4 != "M4: ")
            {
                Console.WriteLine(machine4);
            }
            if (machine5 != "M5: ")
            {
                Console.WriteLine(machine5);
            }
        }
    }
}
