using System;

namespace abs_abc081a {
  class Program {
    static void Main(string[] args) {
      string input = Console.ReadLine();
      char[] chars = input.ToCharArray();
      int ans = 0;

      foreach (char pos in chars) {
        switch (pos) {
          case '0': {
            break;
          }

          case '1': {
            ans++;
            break;
          }
        }
      }

      Console.WriteLine(ans.ToString());
    }
  }
}
