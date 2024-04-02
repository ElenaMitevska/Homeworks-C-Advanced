namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Write a program to create an interface Searchable with a method Search(string word) that searches 
             * for a given keyword in a text document. Create two classes Document and WebPage that implement the 
             * Searchable interface and provide their own implementations of the Search() method.*/
            WebPage page1 = new WebPage("I am listening to music", "music");
            Console.WriteLine(page1.Search("music"));

            Document doc1 = new Document("He is traveling around the world", "world"); 
            Console.WriteLine(doc1.Search("world"));




        }
    }
}
