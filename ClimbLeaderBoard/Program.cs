// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Threading.Tasks.Sources;

int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

List<int> result = climbingLeaderboard(ranked, player);

Console.WriteLine(String.Join("\n", result));

Console.ReadLine();
static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
{
    ranked.Sort();
    ranked.Reverse();


    ranked = ranked.Distinct().ToList();
    player.Sort();
    List<int> result = new List<int>();
    foreach (int playScore in player)
    {
        result.Add(BinarySearchRecursive(ranked.ToArray(), playScore, 0, ranked.Count - 1));
    }
    //foreach (int playScore in player)
    //{
    //    int rank = 1;
    //    int lastScore = -1;
    //    for (int i = 0;  i< ranked.Count; i++)
    //    {
    //        if (playScore >= ranked[i])
    //        {
    //            result.Add(rank);
    //            break;
    //        }

    //        else
    //        {
    //            if (lastScore == ranked[i])
    //            {
    //                // keep rank
    //            }
    //            else
    //            {
    //                rank++;
    //                lastScore = ranked[i];
    //            }
    //        }
    //        if (i == ranked.Count - 1)
    //        {
    //            result.Add(rank);
    //        }
    //    }
    //}
    return result;
}



//
static int BinarySearchRecursive(int[] inputArray, int key, int min, int max)
{
    if (min > max)
    {
        if (key > inputArray[0])
            return 1;
        else
            return inputArray.Length + 1;
    }
    else
    {
        int mid = (min + max) / 2;
        if (key == inputArray[mid])
        {
            return ++mid;
        }
        else if (mid < inputArray.Length -1 && key < inputArray[mid] && key > inputArray[mid + 1])
        {
            return mid+2;
        }
        else if (key < inputArray[mid])
        {
            return BinarySearchRecursive(inputArray, key, mid + 1, max);
        }
        else
        {
            return BinarySearchRecursive(inputArray, key, min, mid - 1);
        }
    }
}