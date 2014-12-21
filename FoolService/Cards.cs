using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoolService
{
    public class Deck
    {
        public Deck()
        {
            // записываем в колоду все карты
            // пока сделал так, можно сделать получше через массив
            cards.Add(new Card("Шесть крести", 6, 0));
            cards.Add(new Card("Семь крести", 7, 0));
            cards.Add(new Card("Восемь крести", 8, 0));
            cards.Add(new Card("Девять крести", 9, 0));
            cards.Add(new Card("Десять крести", 10, 0));
        }

        // массив из 36 карт
        public List<Card> cards = new List<Card>();

        // ф-я перемешивания
        public void mix()
        {
            // код перемешивания листа cards
        }
    }

    public class Card
    {
        public Card() { }
        public Card(string name, int weight, int suit)
        {
            this.title = name;
            this.weight = weight;
            this.suit = suit;
        }

        // масть: 0-крести,1-вини,2-черви,3-буби
        public int suit;

        // вес карты
        public int weight;

        // Название: "Валет, вини"
        public string title;
    }
}