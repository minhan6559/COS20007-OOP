using System;
namespace HelloWorld
{
    internal class Message
    {
        internal string _text;

        public Message(string text)
        {
            _text = text;
        }

        public void Print()
        {
            Console.WriteLine(_text);
        }
    }
}