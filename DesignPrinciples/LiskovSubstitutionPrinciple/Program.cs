using System;

namespace LiskovSubstitutionPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            //1、里氏替换原则是针对继承而言的，如果继承是为了实现代码重用，也就是为了共享方法，那么共享的父类方法就应该保持不变，不能被子类重新定义。
            //子类只能通过新添加方法来扩展功能，父类和子类都可以实例化，而子类继承的方法和父类是一样的，父类调用方法的地方，子类也可以调用同一个继承得来的，
            //逻辑和父类一致的方法，这时用子类对象将父类对象替换掉时，当然逻辑一致，相安无事。

            //2、如果继承的目的是为了多态，而多态的前提就是子类覆盖并重新定义父类的方法，为了符合LSP，我们应该将父类定义为抽象类，并定义抽象方法，
            //让子类重新定义这些方法，当父类是抽象类时，父类就是不能实例化，所以也不存在可实例化的父类对象在程序里。
            //也就不存在子类替换父类实例（根本不存在父类实例了）时逻辑不一致的可能。 

            //1、子类可以实现父类的抽象方法，但不能覆盖父类的非抽象方法
            //2、子类可以增加自己特有的方法
            //3、当子类的方法重载父类的方法时，方法的形参要比父类方法的输入参数更宽松
            //4、当子类的方法实现父类的抽象方法时，方法的返回值应比父类更严格

            IVideoPlayer videoPlayer = new MoviePlayer();
            User vipUser = new VIPUser(videoPlayer);
            vipUser.UserName = "userA";
            User normalUser = new NormalUser(videoPlayer);
            normalUser.UserName = "userB";

            vipUser.Login();
            normalUser.Login();

            vipUser.WatchMovie();
            normalUser.WatchMovie();

        }
    }
}
