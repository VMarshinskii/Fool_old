using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoolService
{
    public class User
    {
        public int id;

        public string name;

        public List<Card> cards = new List<Card>();

        //команда - ходи
        public void go()
        {
            //код команды
        }

        //команда - жди
        public void wait()
        {
            //код команды
        }

        //команда - отбивайся
        public void beat()
        {
            //код команды
        }
    }
}