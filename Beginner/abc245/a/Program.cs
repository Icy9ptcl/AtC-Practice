using System;
using static System.Console;

namespace abc245_a {
  class Program {
    static void Main() {
      int[] args = Array.ConvertAll<string, int>(ReadLine().Split(' '), Int32.Parse);
      if (args[0] > args[2]) {
        WriteLine("Aoki");
      } else if (args[0] < args[2]) {
        WriteLine("Takahashi");
      } else {
        if (args[1] > args[3]) {
          WriteLine("Aoki");
        } else {
          WriteLine("Takahashi");
        }
      }
    }
  }
}