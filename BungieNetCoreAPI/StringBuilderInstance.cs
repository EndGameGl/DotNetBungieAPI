using System.Text;

namespace NetBungieAPI
{
    public class StringBuilderInstance
    {
        private StringBuilder _sb = new StringBuilder();
        private object _lock = new object();

        public bool IsBusy { get; private set; }

        public StringBuilderInstance()
        {
            IsBusy = false;
        }
        public StringBuilderInstance PrepareForUse()
        {
            lock (_lock)
            {
                IsBusy = true;
                return this;
            }
        }
        public StringBuilderInstance Append(string value)
        {
            _sb.Append(value);
            return this;
        }
        public StringBuilderInstance Append(long value)
        {
            _sb.Append(value);
            return this;
        }
        public StringBuilderInstance Append(char value)
        {
            _sb.Append(value);
            return this;
        }
        public StringBuilderInstance Append(int value)
        {
            _sb.Append(value);
            return this;
        }
        public override string ToString()
        {
            lock (_lock)
            {
                IsBusy = false;
                var result = _sb.ToString();
                _sb.Clear();
                return result;
            }
        }
    }
}
