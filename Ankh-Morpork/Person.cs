namespace Ankh_Morpork
{
    class Person
    {
        public string name { get; private set; }
        public int price { get; private set; }

        public Person(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
