using System;

namespace abs_abc085c {
  class Program {
    public static readonly int IMPOSSIBLE = -1;
    public static readonly int NOT_CALCULATED = -2;
    public static readonly int[] cashWorth = { 10, 5, 1 };

    static void Main() {
      string[] args = Console.ReadLine().Split(' ');
      int paperNum = Int32.Parse(args[0]);
      int balance = Int32.Parse(args[1]) / 1000;

      // n千円があるよ / 大きい順にどうぞ
      int[] cashNums = new int[cashWorth.Length];
      Array.Fill(cashNums, NOT_CALCULATED);

      Console.WriteLine(string.Join<int>(' ', makeCombination(cashNums, paperNum, balance)));
    }

    public static bool isAble(int[] cashNums) {
      bool flag = true;
      for (int j = 0; j < cashNums.Length; j++) {
        if (cashNums[j] == IMPOSSIBLE || cashNums[j] == NOT_CALCULATED) {
          flag = false;
          break;
        }
      }
      return flag;
    }

    public static int[] makeCombination(int[] cashNums, int paperNum, int balance) {
      if (paperNum < 0) {
        throw new Exception("impossible combination");
      }

      // Console.WriteLine($"got {string.Join<int>(',', cashNums)}, in {paperNum} sum {balance}");
      int index = -1;
      for (int i = 0; i < cashNums.Length; i++) {
        if (cashNums[i] == NOT_CALCULATED) {
          index = i;
          break;
        }
      }

      if (index == cashNums.Length-1) {
        // Console.WriteLine($"final with {string.Join<int>(',', cashNums)}, {balance} is {paperNum} * {cashWorth[index]} ?");
        if (balance == paperNum * cashWorth[index]) {
          cashNums[index] = paperNum;
          return cashNums;
        } else {
          cashNums[index] = IMPOSSIBLE;
          return cashNums;
        }
      } else if (index == -1) {
        return cashNums;
      } else {
        int targetCashNum = Math.Min(balance / cashWorth[index], paperNum);

        for (int i = targetCashNum; i >= 0; i--) {
          cashNums[index] = i;
          int[] v = makeCombination((int[])cashNums.Clone(), paperNum - i, balance - (i * cashWorth[index]));
          if (isAble(v)) {
            return v;
//            break;
          }
        }

        cashNums[index] = IMPOSSIBLE;
      }

      // Console.WriteLine($"passing {string.Join<int>(',', cashNums)}");
      if (cashNums[0] == IMPOSSIBLE) {
        Array.Fill<int>(cashNums, IMPOSSIBLE);
      }

      return cashNums;
    }
  }
}
