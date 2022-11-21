namespace CPM
{
    public class Node
    {
        public Node[] next { get; set; }
        public Node[] prev { get; set; }

        public string Z { get; set; } //nazwa zadania
        public int p { get; set; } //dlugość trwania zadania
        public int es { get; set; } //najwcześniejszy start
        public int ls { get; set; } //najpóźniejszy start
        public int ee { get; set; } //najwcześniejszy koniec
        public int le { get; set; } //najpozniejszy koniec

        public Node() { }
        public Node(string Z, int p)
        {
            this.Z = Z;
            this.p = p;
        }
        //wypełnianie tablicy następców
        //dodawanie węzłów na koniec tablicy
        public Node addNextNode(Node arr, Node node)
        {
            if(arr.next != null)
            {
                int n = arr.next.Length;
                Node tmp = new Node();

                tmp.next = new Node[n + 1];
                for(int i = 0; i < n; i++)
                {
                    tmp.next[i] = arr.next[i];
                }
                tmp.next[n] = node;
                arr.next = tmp.next;

                return arr;
            }
            else
            {
                arr.next = new Node[1];
                arr.next[0] = node;
                return arr;
            }
        }
        //funkcja pomocnicza: zwraca index szukanego węzła lub 0, gdy nie istnieje
        public int findI(Node[] arr, int n, Node node)
        {
            for(int i = 0; i < n; i++)
            {
                if(arr[i].Z == node.Z)
                {
                    return i;
                }
            }
            return 0;
        }
        //funkcja pomocnicza: zwraca węzeł lub null, gdy nie istnieje
        public Node findNode(Node[] arr, int n, string Z)
        {
            for(int i = 0; i < n; i++)
            {
                if(arr[i].Z == Z)
                {
                    return arr[i];
                }
            }
            return null;
        }
    }
}
