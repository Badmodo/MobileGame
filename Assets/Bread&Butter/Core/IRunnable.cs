namespace BreadAndButter
{
    public interface IRunnable
    {
        bool Enabled { get; set; }

        //This is how you take in any number of any type if paramater
        void Setup(params object[] _params);
        void Run(params object[] _params);
    }
}

