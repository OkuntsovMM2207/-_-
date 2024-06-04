using System;

public class ConsoleApp1
{
    public static void Main(string[] args)
    {
        // Создание собаки
        Dog myDog = new Dog.Builder()
            .WithName("Барсик")
            .WithBreed("Сибирский кот")
            .WithAge(3)
            .WithToys(new List<string> { "Мышка", "Шнурок" })
            .Build();

        // Вывод информации о собаке
        Console.WriteLine($"Имя: {myDog.Name}");
        Console.WriteLine($"Порода: {myDog.Breed}");
        Console.WriteLine($"Возраст: {myDog.Age}");
        Console.WriteLine($"Игрушки: {string.Join(", ", myDog.Toys)}");
    }
    public class Dog
    {
        private string _name;
        private string _breed;
        private int _age;
        private List<string> _toys;

        // Конструктор по умолчанию (приватный)
        private Dog() { }

        // Класс-строитель
        public class Builder
        {
            private Dog _dog = new Dog();

            public Builder WithName(string name)
            {
                _dog._name = name;
                return this; // Возвращаем this для цепочки методов
            }

            public Builder WithBreed(string breed)
            {
                _dog._breed = breed;
                return this;
            }

            public Builder WithAge(int age)
            {
                _dog._age = age;
                return this;
            }

            public Builder WithToys(List<string> toys)
            {
                _dog._toys = toys;
                return this;
            }

            public Dog Build()
            {
                return _dog;
            }
        }

        // Методы-аксессоры
        public string Name => _name;
        public string Breed => _breed;
        public int Age => _age;
        public List<string> Toys => _toys;

        // Методы-мутаторы
        public void SetName(string name) => _name = name;
        public void SetBreed(string breed) => _breed = breed;
        public void SetAge(int age) => _age = age;
        public void AddToy(string toy) => _toys.Add(toy);
    }
}