// See https://aka.ms/new-console-template for more information
string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

int n = Convert.ToInt32(firstMultipleInput[0]);

int k = Convert.ToInt32(firstMultipleInput[1]);

List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

int result = divisibleSumPairs(n, k, ar);
Console.WriteLine(result);

static int divisibleSumPairs(int n, int k, List<int> ar)
{
    int result = 0;
    for (int i = 0; i < ar.Count; i++)
    {
        for (int j = i + 1; j < ar.Count; j++)
        {
            if ((ar[i] + ar[j]) % k == 0)
            {
                result++;
            }
        }
    }
    return result;
}