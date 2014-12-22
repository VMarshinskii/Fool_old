using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoolService
{
    public class User : IService
    {
        public int id;

        public string name;

        public List<Card> cards = new List<Card>();

        //команда - ходи
        public void Go()
        {
            //код команды
        }

        //команда - жди
        public void Wait()
        {
            //код команды
        }

        //команда - отбивайся
        public void Beat()
        {
            //код команды
        }
    }
}