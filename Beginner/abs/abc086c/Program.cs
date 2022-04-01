using System;
using System.Collections.Generic;

namespace abs_abc086c {
  class Program {
    static void Main(string[] args) {
      int N = Int32.Parse(Console.ReadLine());
      List<PlanDest> Plan = new List<PlanDest>();

      for (int index = 0; index < N; index++) {
        var arr = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);
        Plan.Add(new PlanDest(arr[1], arr[2], arr[0]));
      }

      Position currentPos;
      currentPos.X = 0;
      currentPos.Y = 0;
      int currentTime = 0;
      bool runnableFlag = true;

      for (int planNum = 0; planNum < N; planNum++) {
        var nextPlan = Plan[planNum];
        var reqTime = getEuclidDist(currentPos, nextPlan.dest);
        var allowTime = nextPlan.time - currentTime;

        //Console.WriteLine($"{reqTime} / {allowTime} -> {((allowTime - reqTime) % 2)}");

        if (!((allowTime >= reqTime) && (((allowTime - reqTime) % 2) == 0))) {
          runnableFlag = false;
          break;
        }

        currentPos = nextPlan.dest;
        currentTime = nextPlan.time;
      }

      Console.WriteLine(runnableFlag ? "Yes" : "No");
    }

    static int getEuclidDist(Position pos1, Position pos2) {
      return Math.Abs(pos2.X - pos1.X) + Math.Abs(pos2.Y - pos1.Y);
    }

    public struct Position {
      public int X;
      public int Y;
    }

    public class PlanDest {
      public Position dest;
      public int time;

      public PlanDest(int destX, int destY, int time) {
        this.dest.X = destX;
        this.dest.Y = destY;
        this.time = time;
      }
    }
  }
}
