using System;
using static System.Console;
using Icylib;

namespace abs_abc086a {
  class Program {
    static void Main(string[] args) {
      int[] inputs = Icylib.StrTools.StrToIntegers(ReadLine());
      int a = inputs[0];
      int b = inputs[1];

      // どっちかが偶数ならばよいわけで
      if (a % 2 == 0 || b % 2 == 0) {
        WriteLine("Even");
      } else {
        WriteLine("Odd");
      }
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