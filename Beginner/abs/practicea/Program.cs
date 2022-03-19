using System;
using static System.Console;

namespace abs_practicea {
  class Program {
    static void Main(string[] args) {
      int a = Int32.Parse(ReadLine());
      int[] line2 = StrToIntegers(ReadLine());
      int b = line2[0];
      int c = line2[1];

      string s = ReadLine();

      Console.WriteLine($"{a + b + c} {s}");
    }
    static int[] StrToIntegers(string inputString) {
      string[] inputs = inputString.Split(' ');
      int[] ints = new int[inputs.Length];
      for (var i = 0; i < inputs.Length; i++) {
        ints[i] = Int32.Parse(inputs[i]);
      }

      return ints;
    }
  }
}
