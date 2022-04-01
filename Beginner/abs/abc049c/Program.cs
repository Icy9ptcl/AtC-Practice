using System;
using System.Collections.Generic;

namespace abs_abc049c {
  class Program {
    static void Main(string[] args) {
      // 再帰的に検索するとかやらんでええんかった
      // dream と erase の順番は入れ替えてはいけない

      string S = Console.ReadLine();
      S = S.Replace("eraser", "");
      S = S.Replace("erase", "");
      S = S.Replace("dreamer", "");
      S = S.Replace("dream", "");

      if (S.Length == 0) {
        Console.WriteLine("YES");
      } else {
        Console.WriteLine("NO");
      }

    }
  }
}
