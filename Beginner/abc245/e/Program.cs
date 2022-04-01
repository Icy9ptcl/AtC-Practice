using System;
using System.Collections;
using System.Collections.Generic;

namespace abc245_e {
  class Program {
    public static void Main(string[] args) {
      int[] l1 = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);
      int ChocoLen = l1[0];
      int BoxeLen = l1[1];
      int[] lA = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);
      int[] lB = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);
      int[] lC = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);
      int[] lD = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);

      List<Choco> Chocos = new List<Choco>();
      List<Box> Boxes = new List<Box>();
      for (int ch = 0; ch < ChocoLen; ch++) {
        Choco AddChoco;
        AddChoco.X = lA[ch];
        AddChoco.Y = lB[ch];
        Chocos.Add(AddChoco);
      }
      Chocos.Sort(new ChocoComparer());

      for (int bo = 0; bo < BoxeLen; bo++) {
        Box AddBox;
        AddBox.Width = lC[bo];
        AddBox.Height = lD[bo];
        Boxes.Add(AddBox);
      }
      Boxes.Sort(new BoxComparer());

      bool[] BoxUsed = new bool[BoxeLen];
      Array.Fill(BoxUsed, false);

      bool result = true;
      for (var i = 0; i < ChocoLen; i++) {
        var targetChoco = Chocos[i];
        bool contains = false;
        for (var b = 0; b < BoxeLen; b++) {
          var targetBox = Boxes[b];
          if (BoxUsed[b]) { continue; }

          //Console.WriteLine($"Choco {i}, {targetChoco.X}/{targetChoco.Y} vs Box {b} {targetBox.Width}/{targetBox.Height}");

          if ((targetChoco.X <= targetBox.Width) && (targetChoco.Y <= targetBox.Height)) {
            //Console.WriteLine($"Box {b} contains choco {i}");
            BoxUsed[b] = true;
            contains = true;
            break;
          }
        }
        if (!contains) {
          result = false;
          break;
        }
      }

      Console.WriteLine(result ? "Yes" : "No");
    }

    public struct Choco {
      public int X;
      public int Y;
    }

    public struct Box {
      public int Width;
      public int Height;
    }

    public class ChocoComparer : IComparer<Program.Choco> {
      public int Compare(Program.Choco cho1, Program.Choco cho2) {
        if (cho1.X > cho2.X) {
          return 1;
        } else if (cho1.X < cho2.X) {
          return -1;
        } else {
          if (cho1.Y > cho2.Y) {
            return 1;
          } else if (cho1.Y < cho2.Y) {
            return -1;
          } else {
            return 0;
          }
        }
      }
    }

    public class BoxComparer : IComparer<Program.Box> {
      public int Compare(Program.Box box1, Program.Box box2) {
        if (box1.Width > box2.Width) {
          return 1;
        } else if (box1.Width < box2.Width) {
          return -1;
        } else {
          if (box1.Height > box2.Height) {
            return 1;
          } else if (box1.Height < box2.Height) {
            return -1;
          } else {
            return 0;
          }
        }
      }
    }



  }
}