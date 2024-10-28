
public class Display
{
    public int Width { get; set; }
    public int Height { get; set; }
    public float Ppi { get; set; }
    public string Model { get; set; }

    public Display(int width, int height, float ppi, string model)
    {
        Width = width;
        Height = height;
        Ppi = ppi;
        Model = model;
    }

    // Method to compare size based on area
    public void CompareSize(Display other)
    {
        int thisArea = Width * Height;
        int otherArea = other.Width * other.Height;

        Console.WriteLine($"\nComparing size between {Model} and {other.Model}:");
        if (thisArea > otherArea)
        {
            Console.WriteLine($"{Model} is larger than {other.Model}.");
        }
        else if (thisArea < otherArea)
        {
            Console.WriteLine($"{other.Model} is larger than {Model}.");
        }
        else
        {
            Console.WriteLine($"{Model} and {other.Model} have the same screen area.");
        }
    }

    // Method to compare sharpness based on PPI
    public void CompareSharpness(Display other)
    {
        Console.WriteLine($"\nComparing sharpness between {Model} and {other.Model}:");
        if (Ppi > other.Ppi)
        {
            Console.WriteLine($"{Model} is sharper than {other.Model}.");
        }
        else if (Ppi < other.Ppi)
        {
            Console.WriteLine($"{other.Model} is sharper than {Model}.");
        }
        else
        {
            Console.WriteLine($"{Model} and {other.Model} have the same sharpness.");
        }
    }

    // Method to compare both size and sharpness
    public void CompareWithMonitor(Display other)
    {
        Console.WriteLine($"\n> Comparing {Model} and {other.Model}:");
        CompareSize(other);
        CompareSharpness(other);
    }
}

public class Program
{
    public static void Main()
    {
        // Creating 3 Display objects
        Display display1 = new Display(1920, 1080, 300, "Display 1");
        Display display2 = new Display(2560, 1440, 300, "Display 2");
        Display display3 = new Display(3840, 2160, 400, "Display 3");

        // Comparing displays
        display1.CompareWithMonitor(display2);
        display2.CompareWithMonitor(display3);
        display1.CompareWithMonitor(display3);
    }
}
