using System;

public class Jobs
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public string Display()
    {
        return $"{_jobTitle} ({_company}) {_startYear}-{_endYear}";
    }
}