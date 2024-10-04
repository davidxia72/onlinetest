// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int n = Convert.ToInt32(Console.ReadLine().Trim());
List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();
s.ForEach(n => Console.WriteLine(n));

string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

int d = Convert.ToInt32(firstMultipleInput[0]);

int m = Convert.ToInt32(firstMultipleInput[1]);

int result = Birthday(s, d, m);

Console.WriteLine("this is answer:" + result);


Console.ReadLine();

static int Birthday(List<int> s, int d, int m)
{
    if (s.Count < m)
        return 0;
    else if (s.Count == m && m == 1)
    {
        if (s[0] == m)
            return 1;
        else
            return 0;
    }
    int result = 0;
    for (int i = 0; i < s.Count; i++)
    {
        if (i + m > s.Count)
            break;
        int total = 0;
        for (int j = 0; j < m; j++)
        {
            total = total + s[i + j];
        }
        if (d == total)
        {
            result++;
        }
    }
    return result;
}