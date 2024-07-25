using System.Collections.Generic;

namespace UniState
{
    public class LimitedStack_sliding_array<T>  : ILimitedStack<T>
    {
        private readonly  T[] _list;
        private int _top = 0;
        private int _bot = 0;
        private int _maxSize;
        // count: (_top - _bot) % _maxSize
        // top index: (_top - 1) % _maxSize
        // isNotEmpty: _top != _bot

        public LimitedStack_sliding_array(int maxSize)
        {
            _maxSize = maxSize;
            _list = new T[_maxSize];
        }

        public T Push(T element)
        {
            if (_top != _bot && (_top - _bot) % _maxSize == 0)
            {
                _bot++;
            }

            _top++;
            _list[(_top-1)%_maxSize] = element;
            return element;
        }

        public T Peek() => _top != _bot ? _list[(_top-1)%_maxSize] : default(T);

        public T Pop()
        {
            var result = Peek();

            if (_top != _bot)
            {
                _list[(_top-1)%_maxSize] = default(T);
                _top--;
            }

            return result;
        }

        public int Capacity() => _maxSize;
    }
}