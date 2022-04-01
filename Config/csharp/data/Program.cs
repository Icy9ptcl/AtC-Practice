using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace d {
  class Program {
    static void Main(string[] args) {
      var asp = Icylib.StdinTools.GetArgs<int>();
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
    public static T[] GetArgs<T>() {
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

  public class Map {
    public List<T> items;

    Map(List<T> inputItems) {
      this.items = inputItems;
    }

    int removeDuplicates() {
      int count = this.items.Count;
      List<T> newItems = new List<T>();
      foreach (T item in this.items) {
        if (!newItems.Contains(item)) {
          newItems.Add(item);
          count--;
        }
      }

      this.items = newItems;
      return count;
    }

    bool Add(T item) {
      if (!this.items.Contains(item)) {
        this.items.Add(item);
        return true;
      } else {
        return false;
      }
    }

    int AddAll(T[] items) {
      int count = 0;
      foreach (T item in items) {
        if (this.items.Add(item)) {
          count++;
        }
      }

      return count;
    }

    int AddAll(List<T> items) {
      int iniCount = items.Count;
      this.items.AddRange(items);
      int ttlCount = items.Count;
      int dupes = removeDuplicatedItems();
      return (ttlCount - iniCount - dupes);
    }

    bool Remove(T item) {
      return this.items.Remove(item);
    }

    bool Contains(T item) {
      return this.items.Contains(item);
    }
  }
}