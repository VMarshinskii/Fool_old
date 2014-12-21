using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoolService
{
    public class Table
    {
        int max_users = 6;
        
        // козырь
        Card trump = new Card();

        // кто ходит
        User attack_user = new User();

        // карты на столе
        List<Card[]> table_cards = new List<Card[]>();

        public List<User> users = new List<User>();

        public bool add_user(User new_user)
        {
            if(this.users.Count < this.max_users)
            {
                this.users.Add(new_user);
                return true;
            }
            return false;
        }

        public void exit_user(User current_user)
        {
            foreach(var user in this.users)
            {
                if (user.id == current_user.id)
                    this.users.Remove(user);
            }
        }


        // НАЧАТЬ ИГРУ
        public void play_game()
        {
            //Берём колоду карт, перемешиваем её
            Deck desk = new Deck();
            desk.mix();

            // козырь - первая карта
            trump = desk.cards.First();

            //В цикле проходим по всем юзерам и раздаём по 6 карт
            for (int i = 0; i < 6; i++)
            {
                foreach (var user in users)
                {
                    user.cards.Add(desk.cards.Last());
                    desk.cards.Remove(desk.cards.Last());
                }
            }

            //Рандомно назначаем того, кто ходит
            Random rand = new Random();
            attack_user = users[rand.Next(users.Count - 1)];


            //Отправляем информацию юзерам
            //user - ходи
            attack_user.go();

            //остальные - ожидайте
            foreach(var user in users)
            {
                if(user.id != attack_user.id)
                {
                    user.wait();
                }
            }
        }

        
        // ПОШЕЛ
        public void go(User attack_user, Card current_card)
        {
            this.attack_user = attack_user;

            // тут мы запоминаем карту, которую нужно отбить
            // нападпющему говорим - жди
            // посылаем отбивающемуся команжу - отбивайся
            // остальным - ждите

            // положили карту, которую будем крыть, на стол 
            if(table_cards.Count < 6)
            {
                Card[] new_hod = new Card[2];
                new_hod[1] = current_card;

                table_cards.Add(new_hod);
            }

            // отбивающийся
            int beat_index = users.LastIndexOf(attack_user);
            User beat_user = users[(beat_index + 1) % users.Count];

            beat_user.beat();

            foreach (var user in users)
            {
                if (user.id != beat_user.id)
                {
                    user.wait();
                }
            }
            
        }


        
    }
}