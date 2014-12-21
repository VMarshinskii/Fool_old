using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoolService
{
    public class Table
    {
        Deck desk = new Deck();

        int max_users = 6;
        
        // кто ходит
        User attack_user = new User();

        // карты на столе
        List<int[]> table_cards = new List<int[]>();

        public List<User> users = new List<User>();

        public bool AddUser(User new_user)
        {
            if(this.users.Count < this.max_users)
            {
                this.users.Add(new_user);
                return true;
            }
            return false;
        }

        public void ExitUser(User current_user)
        {
            foreach(var user in this.users)
            {
                if (user.id == current_user.id)
                    this.users.Remove(user);
            }
        }


        // НАЧАТЬ ИГРУ
        public void PlayGame()
        {

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
            report(attack_user);
            attack_user.Go();

            //остальные - ожидайте
            foreach(var user in users)
            {
                if(user.id != attack_user.id)
                {
                    report(user);
                    user.Wait();
                }
            }
        }

        
        // ПОШЕЛ
        public void Go(User attack_user, int current_card)
        {
            this.attack_user = attack_user;

            // тут мы запоминаем карту, которую нужно отбить
            // нападпющему говорим - жди
            // посылаем отбивающемуся команжу - отбивайся
            // остальным - ждите

            // положили карту, которую будем крыть, на стол 
            if(table_cards.Count < 6)
            {
                int[] new_hod = new int[2];
                new_hod[1] = current_card;

                table_cards.Add(new_hod);
            }

            // отбивающийся
            int beat_index = (users.LastIndexOf(attack_user) + 1) % users.Count;
            User beat_user = users[beat_index];

            report(beat_user);
            beat_user.Beat();

            foreach (var user in users)
            {
                if (user.id != beat_user.id)
                {
                    report(user);
                    user.Wait();
                }
            }
            
        }


        // ВЗЯЛ
        public void Take(User take_user)
        {
            foreach(var table_card in table_cards)
            {
                take_user.cards.Add(table_card[0]);
                if(table_card[1] != null)
                    take_user.cards.Add(table_card[1]);
            }

            // убираем карты на столе
            table_cards = new List<int[]>();

            // новый нападающий
            int attack_index = (users.LastIndexOf(take_user) + 1) % users.Count;
            attack_user = users[attack_index];

            report(attack_user);
            attack_user.Go();

            //остальные - ожидайте
            foreach (var user in users)
            {
                if (user.id != attack_user.id)
                {
                    report(user);
                    user.Wait();
                }
            }
        }


        // докласть карты Юзеру
        public void report(User user)
        {
            while(user.cards.Count < 6 && desk.cards.Count > 0)
            {
                user.cards.Add(desk.cards.Last());
                desk.cards.Remove(desk.cards.Last());
            }
        }
        
    }
}