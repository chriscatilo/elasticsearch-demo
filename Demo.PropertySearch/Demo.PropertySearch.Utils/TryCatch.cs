using System;

namespace Demo.PropertySearch.Utils
{
    public static class TryCatch
    {
        public static Container<TResult> Do<TResult>(Func<TResult> action)
        {
            return new Container<TResult>(action);
        }

        public class Container<TResult>
        {
            private readonly Func<TResult> _action;
            private Func<TResult> _onException;

            internal Container(Func<TResult> action)
            {
                _action = action;
            }

            public Container<TResult> OnException(Func<TResult> onException)
            {
                _onException = onException;
                return this;
            }

            public TResult Execute()
            {
                try
                {
                    return _action();
                }
                catch (Exception)
                {
                    return _onException();
                }
            }
        }
    }
}