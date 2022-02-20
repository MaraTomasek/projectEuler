namespace ConsoleApp1;

public class Problem19 : Problem {
    private new static string Headline = @"Counting Sundays";

    private new static string Description = @"
    You are given the following information, but you may prefer to do some research for yourself.

        1 Jan 1900 was a Monday.
        Thirty days has September,
        April, June and November.
        All the rest have thirty-one,
        Saving February alone,
        Which has twenty-eight, rain or shine.
        And on leap years, twenty-nine.
        A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

    How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?";

    private new static string Solution = @"
    Simply use the DateTime library to check each first of the month.";

    public Problem19() : base(Headline, Description, Solution) {
    }


    public override string Main() {
        const int startYear      = 1901;
        const int endYear        = 2000;
        const int monthsPerYear  = 12;
        int       sundaysOnFirst = 0;

        for (int year = startYear; year <= endYear; year++) {
            for (int month = 1; month <= monthsPerYear; month++) {
                var date = new DateTime(year, month, 1);
                if (date.DayOfWeek == DayOfWeek.Sunday) sundaysOnFirst++;
            }
        }

        return sundaysOnFirst.ToString();
    }
}