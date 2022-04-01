using System;
using System.Collections.Generic;

namespace abc245_b {
  class Program {
    static void Main() {
      int N = Int32.Parse(Console.ReadLine());
      int[] argsAry = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);
      List<int> args = new List<int>(argsAry);
      for (int countUp = 0; countUp <= 2001; countUp++) {
        if (!args.Contains(countUp)) {
          Console.WriteLine(countUp);
          break;
        }
      }
    }
  }
}
