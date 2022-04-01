using System;
using System.Collections.Generic;

namespace abc245_c {
  class Program {
    public static void Main() {
      int[] L1 = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);
      int N = L1[0];
      int allowDiff = L1[1];
      List<int> Ary = new List<int>();
      int diffs = 0;
      Ary.AddRange(new List<int>(Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse)));
      Ary.AddRange(new List<int>(Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse)));

      Ary.Sort();

      bool possibility = true;

      for (var i = 0; i < N * 2 - 1; i++) {
        Console.WriteLine($"{Ary[i + 1]} {Ary[i]} > {allowDiff}?");
        if (Ary[i + 1] - Ary[i] > 0) {
          diffs++;
        }
        if (Ary[i + 1] - Ary[i] > allowDiff) {
          possibility = false;
          break;
        }
      }
      Console.WriteLine($"needed {diffs} vs N = {N}");
      if (diffs > N) {
        possibility = false;
      }

      Console.WriteLine(possibility ? "Yes" : "No");

    }
  }
}
