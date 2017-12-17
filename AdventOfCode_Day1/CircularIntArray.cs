// Yeah, i can do this assignment in one function i know.
// I probably make a second version without creating my own
// datatype and all of this mess. But it works ¯\_(ツ)_/¯

namespace AdventOfCode_Day1
{
    class CircularIntArray
    {
        private readonly int[] _array;
        private int _index = 0;

        public CircularIntArray(int[] input)
        {
            _array = input;
        }

        public int Current()
        {
            return _array[_index];
        }

        public int GetValueOfIndex(int input)
        {
            return _array[input];
        }

        public int MoveNext()
        {
            if (++_index >= _array.Length)
            {
                _index = 0;
            }

            return _array[_index];
        }

        public int SkipAndMoveNext(int skipAmount)
        {
            int tempIndex;
            if (_index + skipAmount >= _array.Length)
            {
                tempIndex = skipAmount - TillEnd();
                _index++;
            }  
            else
            {
                tempIndex = _index + skipAmount;
                _index++;
            }

            return _array[tempIndex];
        }

        private int TillEnd()
        {
            int counter = 0;
            for (int i = _index; i < _array.Length; i++)
            {
                counter++;
            }

            return counter;
        }
    }
}
