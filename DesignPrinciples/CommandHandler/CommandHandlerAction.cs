using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommandHandler
{
    /// <summary>
    /// 输入byte[],无返回处理，TArg为输入的解析值，解析的值用于后续handler处理
    /// </summary>
    /// <typeparam name="TArg"></typeparam>
    public class CommandHandlerAction<TArg>
    {
        private Func<byte[], TArg> _input;
        private Action<TArg> _handle;

        public CommandHandlerAction(Func<byte[], TArg> input,Action<TArg> handle)
        {
            _input = input;
            _handle = handle;
        }

        public void DoCommand(byte[] inputValue)
        {
            try
            {
                TArg arg = _input(inputValue);
                _handle(arg);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    /// <summary>
    /// 输入byte[],TArg为输入的解析值，解析的值用于后续handler处理成TOut作为最终返回
    /// </summary>
    /// <typeparam name="TArg"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public class OutPutCommandHandlerAction<TArg, TOut>
    {
        private Func<byte[], TArg> _input;
        private Func<TArg,TOut> _handle;

        public OutPutCommandHandlerAction(Func<byte[], TArg> input, Func<TArg, TOut> handle)
        {
            _input = input;
            _handle = handle;
        }

        public TOut DoCommand(byte[] inputValue)
        {
            try
            {
                TArg arg = _input(inputValue);
                TOut res = _handle(arg);
                return res;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
