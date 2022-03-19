using System;
using static System.Console;

namespace abs_abc081b {
  class Program {
    static void Main(string[] args) {
      int N = Int32.Parse(ReadLine());
      int[] As = Icylib.StrTools.StrToIntegers(ReadLine());

      int cnt = 0;
      while (true) {
        bool isContinuable = true;
        foreach (int num in As) {
          if (num % 2 == 1) {
            isContinuable = false;
          }
        }
        if (!isContinuable) { break; }

        cnt++;
        int[] newAs = new int[N];
        for (int i = 0; i < N; i++) {
          newAs[i] = (As[i] / 2);
        }

        As = newAs;
      }

      Console.WriteLine(cnt);
    }
  }
}

namespace Icylib {
  public class StrTools {
    public static int[] StrToIntegers(string inputString) {
      string[] inputs = inputString.Split(' ');
      int[] ints = new int[inputs.Length];
      for (var i = 0; i < inputs.Length; i++) {
        ints[i] = Int32.Parse(inputs[i]);
      }

      return ints;
    }
  }
}