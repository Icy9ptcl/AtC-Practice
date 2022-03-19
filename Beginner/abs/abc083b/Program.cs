using System;

namespace abs_abc083b {
  class Program {
    static void Main(string[] args) {
      // こんなのできるのか？？
      string[] inputs = Console.ReadLine().Split(' ');
      int[] inputNums = Array.ConvertAll<string, int>(inputs, new Converter<string, int>(Int32.Parse));
      int N = inputNums[0];
      int A = inputNums[1];
      int B = inputNums[2];

      int Ans = 0;
      // N が十分に小さいので全部やってもいいっしょ....？
      for (int num = 1; num <= N; num++) {
        int digitSum = getDigitSum(num);
        // Console.WriteLine($"{num} has {digitSum}");
        if ((digitSum >= A) && (digitSum <= B)) {
          Ans += num;
        }
      }

      Console.WriteLine(Ans);
    }

    static int getDigitSum(int num) {
      // Floor returns double?
      int lessDigit = (int)Math.Floor(Math.Log10((double)num)) + 1; // 桁数はこれよりは小さい ceil はムリ

      // 10^k で割る (k: 1 <= k <= 桁数+1, k は昇順)
      // 1で割ってもあまりが0になるのでどうでもよい。でも0桁目って気持ち悪いじゃん
      // 10^k で割れば、10^(k-1) の位の値が出てくることを利用して
      //   - 10^k で割ったあまりを計算する
      //   - あまり / 10^(k-1) が 10^(k-1) の位の値である
      //   - あまり を元の数から引く
      // を各 k について行えばいいだろう
      int sum = 0;
      for (int targetDigit = 1; targetDigit <= lessDigit; targetDigit++) {
        int divider = (int)Math.Pow(10, targetDigit);
        int digit = (num % divider) / (divider/10);
        // Console.WriteLine($"#{targetDigit} = {digit}; {num} % {divider}");
        sum += digit;
        num -= digit * (divider/10);
      }

      return sum;
    }
  }
}
