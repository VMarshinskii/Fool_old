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

        //rename on Cards type
        public List<string> cards = new List<string>();
    }
}