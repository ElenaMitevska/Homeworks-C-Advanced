using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class WebPage : ISearch

    {
        public string Text { get; set; }
        public string Word { get; set; }
        public WebPage(string text, string word)
        {
            Text = text;
            Word = word;
        }
        public string Search(string word)
        {
            if (word == null)
            {
                return $"The word is not found.";
            }
            else return "The word is found";
        }
    }
}
