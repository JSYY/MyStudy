using System;

namespace AbstractAndInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //抽象类中的定义属性都是属于一个抽象事物的固有属性，如动物类这个抽象的概念中，每一个动物都有自己的名称，动物喝水和进食都是固有的动作，因此
            //这些方法和属性可以定义在抽象类Animal中，Mammal和Reptile都继承Animal类，但是Reptile会有自己的特殊动作：冬眠，因此该
            //抽象类多了一个方法，下面到了具体的实体类，蛇继承了Animal的吃喝，和爬行动物的冬眠功能，而老虎继承了animal的吃喝
            //牛继承了animal的吃喝，由于不是所有动物都需要捕猎，因此捕猎技能作为一个接口让其他实体类进行接口的实现来完成捕猎
            //引发思考：在编写模块时应该首先考虑该模块的总体抽象是怎么样的，然后再取设计具体的类和接口
            Animal tiger = new Tiger("tiger");
            Mammal cow = new Cow("cow");
            Animal snake = new Snake("snake");
            tiger.drink();
            tiger.eat();
            ((IHunt)tiger).hunt();
            Console.WriteLine(tiger.getAnimalName()); 

            cow.drink();
            cow.eat();
            Console.WriteLine(cow.getAnimalName());

            snake.eat();
            snake.drink();
            Console.WriteLine(snake.getAnimalName());
            ((IHunt)snake).hunt();
        }
    }

    public abstract class Animal
    {
        public Animal(string name)
        {
            animalName = name;
        }

        private string animalName { get; set; }
        public abstract void eat();
        public abstract void drink();

        public string getAnimalName()
        {
            return animalName;
        }
    }

    public abstract class Mammal : Animal
    {
        public Mammal(string name):base(name)
        {
            
        }
    }

    public abstract class Reptile : Animal
    {
        public Reptile(string name) : base(name)
        {

        }

        public abstract void Hibernation();
    }

    public class Tiger : Mammal,IHunt
    {
        public Tiger(string name) : base(name)
        {

        }

        public override void drink()
        {
            Console.WriteLine("老虎 低头喝水");
        }

        public override void eat()
        {
            Console.WriteLine("老虎 进食");
        }

        public void hunt()
        {
            Console.WriteLine("老虎 捕杀猎物");
        }
    }

    public interface IHunt
    {
        void hunt();
    }

    public class Snake : Reptile, IHunt
    {
        public Snake(string name) : base(name)
        {

        }

        public override void drink()
        {
            Console.WriteLine("蛇 喝水");
        }

        public override void eat()
        {
            Console.WriteLine("蛇 进食");
        }

        public override void Hibernation()
        {
            Console.WriteLine("蛇 挖洞冬眠");
        }

        public void hunt()
        {
            Console.WriteLine("蛇 捕杀猎物");
        }
    }

    public class Cow : Mammal
    {
        public Cow(string name) : base(name)
        {

        }

        public override void drink()
        {
            Console.WriteLine("牛 低头喝水");
        }

        public override void eat()
        {
            Console.WriteLine("牛 低头吃草");
        }
    }
}
