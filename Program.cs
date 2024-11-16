using System;

class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class ListaCircular
{
    private Node tail;

    public ListaCircular()
    {
        tail = null;
    }

    // Agregar al final de la lista
    public void Add(int data)
    {
        Node newNode = new Node(data);
        if (tail == null)
        {
            tail = newNode;
            tail.Next = tail;
        }
        else
        {
            newNode.Next = tail.Next;
            tail.Next = newNode;
            tail = newNode;
        }
    }

    // Eliminar un nodo por valor
    public void Eliminar(int data)
    {
        if (tail == null) return;

        Node actual = tail.Next;
        Node anterior = tail;

        do
        {
            if (actual.Data == data)
            {
                if (actual == tail && actual.Next == tail)
                {
                    tail = null;
                }
                else
                {
                    if (actual == tail) 
                    {
                        tail = anterior;
                    }
                    anterior.Next = actual.Next;
                }
                return;
            }
            anterior = actual;
            actual = actual.Next;
        } while (actual != tail.Next);
    }

    // Buscar un nodo por valor
    public Node Buscar(int data)
    {
        if (tail == null) return null;

        Node Actual = tail.Next;

        do
        {
            if (Actual.Data == data)
            {
                return Actual;
            }
            Actual = Actual.Next;
        } while (Actual != tail.Next);

        return null;
    }

    // Modificar un nodo por valor
    public void Modificar(int AnteriorDato, int NuevoDato)
    {
        Node NodoAModificar = Buscar(AnteriorDato);
        if (NodoAModificar != null)
        {
            NodoAModificar.Data = NuevoDato;
        }
    }

    // Imprimir lista
    public void Imprimir()
    {
        if (tail == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Node actual = tail.Next;
        do
        {
            Console.Write(actual.Data + " ");
            actual = actual.Next;
        } while (actual != tail.Next);

        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaCircular list = new ListaCircular();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Menú de Lista Circular ---");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Eliminar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("4. Modificar");
            Console.WriteLine("5. Imprimir");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingresa el valor a agregar: ");
                    int AgregarValor = int.Parse(Console.ReadLine());
                    list.Add(AgregarValor);
                    Console.WriteLine($"Agregado: {AgregarValor}");
                    break;

                case "2":
                    Console.Write("Ingresa el valor a eliminar: ");
                    int EliminarValor = int.Parse(Console.ReadLine());
                    list.Eliminar(EliminarValor);
                    Console.WriteLine($"Eliminado: {EliminarValor}");
                    break;

                case "3":
                    Console.Write("Ingresa el valor a buscar: ");
                    int BuscarValor = int.Parse(Console.ReadLine());
                    Node NodoEncontrado = list.Buscar(BuscarValor);
                    Console.WriteLine(NodoEncontrado != null ? $"Encontrado: {NodoEncontrado.Data}" : "No encontrado");
                    break;

                case "4":
                    Console.Write("Ingresa el valor actual a modificar: ");
                    int ValorAnterior = int.Parse(Console.ReadLine());
                    Console.Write("Ingresa el nuevo valor: ");
                    int Nuevo = int.Parse(Console.ReadLine());
                    list.Modificar(ValorAnterior, Nuevo);
                    Console.WriteLine($"Modificado: {ValorAnterior} -> {Nuevo}");
                    break;

                case "5":
                    Console.WriteLine("Contenido de la lista:");
                    list.Imprimir();
                    break;

                case "6":
                    exit = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
        }
    }
}
