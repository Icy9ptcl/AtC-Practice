using System;
using System.Collections.Generic;

namespace abs_abc085b {
  class Program {
    public static void Main(string[] args) {
      int N = Int32.Parse(Console.ReadLine() ?? "");
      List<int> ds = new List<int>();
      for (int i = 0; i < N; i++) {
        ds.Add(Int32.Parse(Console.ReadLine() ?? ""));
      }

      ds.Sort();
      ds.Reverse();

      int ln = 0;
      int prev = 999; // 101 でいいんだけど
      do {
        if (ds[0] < prev) {
          ln++;
          prev = ds[0];
        } else {
        }
        ds.RemoveAt(0);
      } while (ds.Count > 0);

      Console.WriteLine(ln);
    }
  }
}
