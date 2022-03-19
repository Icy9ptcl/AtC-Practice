using static System.Console;

namespace abs_abc087b {
  class Program {
    static void Main(string[] args) {
      int a = Int32.Parse(ReadLine()!);
      int b = Int32.Parse(ReadLine()!);
      int c = Int32.Parse(ReadLine()!);
      int x = Int32.Parse(ReadLine()!);

      // 大きい方から処理していこう
      int maxA = Math.Min(x / 500, a);
      int maxB = Math.Min(x / 100, b);
      
      int combCount = 0;

      // 複数の変数で再帰的にできる気はするけど
      for (int curA = maxA; curA >= 0; curA--) {
        for (int curB = maxB; curB >= 0; curB--) {
          int acct = x - (curA * 500) - (curB * 100);
          if (acct < 0) { continue; }
          // とりあえずこれで足りる？効率は....
          if ( (acct/50) <= c) {
            combCount++;
          }
        }
      }

      WriteLine(combCount);
    }
  }
}
