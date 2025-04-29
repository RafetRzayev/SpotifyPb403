namespace WhatIsSelect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<A> listA = new List<A>
            {
                new A { Id = "1", Name = "A1" },
                new A { Id = "2", Name = "A2" },
                new A { Id = "3", Name = "A3" },
                new A { Id = "4", Name = "A4" },
                new A { Id = "5", Name = "A5" },
                new A { Id = "6", Name = "A6" },
            };

            List<B> listB = new List<B>();


            var b = listA.Select(x => new B { Id = x.Id, Title = x.Name }).ToList();
        
            foreach (var item in listA)
            {
                listB.Add(new B { Id = item.Id, Title = item.Name });
            }
        }
    }

    public class  A
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class B
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
