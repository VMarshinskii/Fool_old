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
        int trump = 0;

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

        public void play_game()
        {
            //Берём колоду карт, перемешиваем её
            

            //В цикле проходим по всем юзерам и раздаём по 6 карт

            //Рандомно назначаем того, кто ходит
        }
    }
}