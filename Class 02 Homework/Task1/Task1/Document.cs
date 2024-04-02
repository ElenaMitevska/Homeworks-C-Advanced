using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Document : ISearch
    {
        public string Text { get; set; }
        public string Word { get; set; }
        public Document(string text, string word)
        {
            Text = text;
            Word = word;

        }
        public string Search(string word)
        {
            if (Text.Contains(word))
            {
                return $"The word is found";
            }
            else return  "The word is not found.";
        }
    }
}
