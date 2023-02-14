namespace UIH.MicroConsole.Common.Unity.Aspects
{
    public class AspectContext
    {
        public AspectContext()
        {
            IsContinue = true;
        }

        public bool IsContinue { get; set; }

        public object LastHandleResult { get; set; }
    }
}
