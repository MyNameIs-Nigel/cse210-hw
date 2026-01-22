using System;

class Program
{
    static void Main(string[] args)
    {
        Jobs job1 = new Jobs();

        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Jobs job2 = new Jobs();

        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume resume1 = new Resume();

        resume1._name = "Alisson Rose";

        resume1._jobs.Add(job1.Display());
        resume1._jobs.Add(job2.Display());

        resume1.Display();

    }
}