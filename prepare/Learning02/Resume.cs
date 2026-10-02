using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    public string _name;
    
    // Initialize the list when declaring it
    public List<Job> _jobs = new List<Job>();

    // Display method to output the name and iterate through all jobs
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs)
        {
            // Call the Display method on each Job object
            job.Display();
        }
    }
}