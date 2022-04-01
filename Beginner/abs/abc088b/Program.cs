using System;
using System.Collections.Generic;
using System.Linq;

namespace abs_abc088b {
  class Program {

    enum Turn {
      Alice, Bob
    };

    static void Main(string[] args) {
      int cardCount = Int32.Parse(Console.ReadLine());
      List<int> cards = new List<int>();
      cards = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), Int32.Parse).ToList<int>();
      cards.Sort();
      cards.Reverse();

      int AliceScore = 0;
      int BobScore = 0;
      
      Turn TurnPlayer = Turn.Alice;

      do {
        switch (TurnPlayer) {
          case Turn.Alice: {
              AliceScore += cards[0];
              cards.RemoveAt(0);
              TurnPlayer = Turn.Bob;
              break;
            }
          case Turn.Bob: {
              BobScore += cards[0];
              cards.RemoveAt(0);
              TurnPlayer = Turn.Alice;
              break;
            }
        }
      } while (cards.Count > 0);

      Console.WriteLine(AliceScore - BobScore);

    }
  }
}
