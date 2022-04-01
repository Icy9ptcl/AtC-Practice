using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace typical90_001 {
  class Program {
    static void Main(string[] args) {
      int[] L1 = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);
      int cuts = L1[0];
      int length = L1[1];
      int selectCuts = Int32.Parse(Console.ReadLine());
      int[] selectablePositions = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);
      selectablePositions.Append(length);

      int minScore = getScore(selectablePositions);
      int maxScore = length;
      int curMin = minScore;
      int curMax = maxScore;

      //Console.WriteLine($"Score range {curMax} - {curMin}");

      // JavaScriptのやり方がぬぐえない
      Func<int, bool> isScorePossible = (int attemptScore) => {
        //Console.WriteLine($"Attempting {attemptScore}");
        int cutCount = 0;
        int lastCutPosition = 0;
        //Console.Write($"Pos: ");
        int sc = 0;
        for (var cutIndex = 0; cutIndex < cuts; cutIndex++) {
          sc = selectablePositions[cutIndex] - lastCutPosition;
          if (sc >= attemptScore) {
            lastCutPosition = selectablePositions[cutIndex];
            //Console.Write($"{lastCutPosition} ,");
            cutCount++;
          }
        };

        if (cutCount < selectCuts) {
          //Console.WriteLine(" :(");
          return false;
        } else {
          if (cutCount == selectCuts) {
            //Console.Write($"{length - lastCutPosition}");
            if ((length - lastCutPosition) >= attemptScore) {
              //Console.WriteLine(" :)");
              return true;
            } else {
              //Console.WriteLine(" :(");
              return false;
            }
          } else {
            //Console.WriteLine(" :)");
            return true;
          }
        }
      };

      int bestScore;

      // Let's 二分法
      while ((curMax - curMin) >= 2) {
        int attemptScore = (int)Math.Floor((curMin + curMax) / 2.0);
        if ((curMax - curMin) == 1) { attemptScore = curMax; }
        // Console.WriteLine($"Target score {attemptScore}");
        if (isScorePossible(attemptScore)) {
          curMin = attemptScore;
        } else {
          curMax = attemptScore;
        }
      }

      if ((curMax - curMin) == 1) {
        if (isScorePossible(curMax)) {
          bestScore = curMax;
        } else {
          bestScore = curMin;
        }
      } else {
        bestScore = curMax;
      }

      Console.WriteLine(bestScore);
    }

    static int getScore(int[] cutPositions) {
      return getPartslength(cutPositions).Min();
    }

    static int[] getPartslength(int[] cutPositions) {
      int cuts = cutPositions.Length;
      int cur = 0;
      int[] lengthes = new int[cuts + 1];
      for (var i = 0; i < cuts;i++) {
          lengthes[i] = cutPositions[i] - cur;
          cur = cutPositions[i];
      }

      return lengthes;
    }

  }
}