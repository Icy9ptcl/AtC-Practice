using System;

namespace <Project_Name> {
  class Program {
    static void Main(string[] args) {
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

  public class StdinTools {
    // literally for reading purpose
    public static T[] ReadAndSplitInputLine<T>() {
      string[] args = Console.ReadLine().Split(' ');
      switch (T) {
        case int: {
          return Array.ConvertAll<T, int>(args, new Converter<T, int>(Convert.ToInt32));
          break;
        }

        case string: {
          return args;
          break;
        }

        default: {
          throw new NotImplementedException();
        }
      }

      throw new Exception("switch expression did not catch?");
    }

    // こんなの打ちたくないよ
    public static int[] ParseAllToInt32<T>(T[] values) {
      int[] inputNums = Array.ConvertAll<T, int>(inputs, new Converter<T, int>(Convert.ToInt32));
    }

  }
}