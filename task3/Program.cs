public class Assistant
{
    public string AssistantName { get; set; }
    private List<Display> assignedDisplays;
    public Assistant(string assistantName)
    {
        AssistantName = assistantName;
        assignedDisplays = new List<Display>();
    }
    public void AssignDisplay(Display d)
    {
        assignedDisplays.Add(d);
        Console.WriteLine($"{d.Model} has been assigned to {AssistantName}.");
    }

    public void Assist()
    {
        Console.WriteLine($"\n{AssistantName} is assisting with the following displays:");
        for (int i = 0; i < assignedDisplays.Count - 1; i++)
        {
            Console.WriteLine($"Comparing {assignedDisplays[i].Model} with {assignedDisplays[i + 1].Model}:");
            assignedDisplays[i].CompareWithMonitor(assignedDisplays[i + 1]);
        }
    }

    public Display BuyDisplay(Display d)
    {
        if (assignedDisplays.Contains(d))
        {
            assignedDisplays.Remove(d);
            Console.WriteLine($"{d.Model} has been purchased.");
            return d;
        }
        else
        {
            Console.WriteLine($"{d.Model} is not assigned to {AssistantName}, purchase failed.");
            return null;
        }
    }
}

public class Program
{
    public static void Main()
    {

        Display dis1 = new Display(1920, 1080, 300, "VP3881");
        Display dis2 = new Display(2560, 1440, 300, "LG 34WK95U-W");
        Display dis3 = new Display(3840, 2160, 400, "Dell U4919DW");

        Assistant assistant = new Assistant("Kindred");

        assistant.AssignDisplay(dis1);
        assistant.AssignDisplay(dis2);
        assistant.AssignDisplay(dis3);

        assistant.Assist();

        assistant.BuyDisplay(dis2);

        assistant.BuyDisplay(dis2);
    }
}
