using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoolService
{
	public class Cards
	{
		public List<int> deck = new List<int>(36);	// Колода карт
		public int suit;	// Масть
		public int trump;	// Козырь
		public int weight;	// Вес

		// Задаем колоду карт по типу 1-"6", 2-"7", 3-"8", 4-"9", 5-"10", 6-"В", 7-"Д", 8-"К", 9-"Т"
		// Масть задается первой цифрой двухзначного числа 1-"Буби", 2-"Крести", 3-"Пики", 4-"Червы"
		public void FillingDeck()
		{
			for (int i = 11; i < 19; i++)
			{
				deck.Add(i);
			}
			for (int i = 21; i < 29; i++)
			{
				deck.Add(i);
			}
			for (int i = 31; i < 39; i++)
			{
				deck.Add(i);
			}
			for (int i = 41; i < 49; i++)
			{
				deck.Add(i);
			}
			// Перемешаем массив алгоритмом Фишера-Ятеса
			Random random = new Random();
			int n = deck.Count;
			while (n > 1)
			{
				n--;
				int k = random.Next(n + 1);
				int value = deck[k];
				deck[k] = deck[n];
				deck[n] = value;
			}
			// Выбираем козырь.
			trump = deck[35]%10; 

		}

		// Функция взятия карты из колоды, принимает значение количества необходимых карт, возвращает массив карт(1-6)
		// Реализация через List.
		public List<int> TakeACardFromTheDeck(int cards)
		{
			List<int> returnCards = new List<int>(cards);
			for (int i = 0; i < cards; i++)
			{
				returnCards.Add(deck[0]);
				deck.RemoveAt(0);
			}
			return returnCards;
		}

		// Сравнение карт: Карта А бьет карту В?
		public bool CompareCards(int cardA, int cardB)
		{
			int A = cardA%10;
			int B = cardB%10;
			// Проверка совпадения масти
			if (A == B){
				if (cardA > cardB)
					return true;
				return false;
			}
			// Если масть козырная, то прибавим ей значение
			if (A == trump)
				cardA += 40;
			if (B == trump)
				cardB += 40;
			if (cardA > cardB)
				return true;
			return false;
		}
	}
}