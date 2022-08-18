using System;
using System.Collections.Generic;

namespace HyperGistCommon
{
    public static class CounterHelper
    {
        private static char[] FirstSequenceRule = new char[] { 'c', 'w', '0', 'v', 'B', 'Z', '.', '_', 'u', '~', 'z', '8', 'T', 't', 'h', 'S', 'K', 'E', 'Y', 'l', 'g', 'U', '-', '7', 'q', 'j', 'V', 'I', 'C', 'L', 'e', 'H', 'a', 'p', 'W', 'n', '5', 'N', 'D', 'd', 'O', 'Q', 'J', '4', 's', 'M', '1', 'b', '3', 'r', 'G', 'm', 'P', 'o', 'k', 'y', '6', 'i', 'R', 'A', '9', '2', 'f', 'F' };
        private static char[] SecondSequenceRule = new char[] { 'V', '3', 'c', 'w', 't', 'T', 'v', '1', 'f', 'e', 'y', 'a', 'o', 'G', 'm', 'W', 'd', '2', 'g', 'Z', 'q', 'U', '5', 'E', 'H', 'O', 'R', '7', 'M', 'j', '4', 'D', '-', 'L', 'F', '~', 'z', 'Y', 'B', 'b', 'S', 'P', 'Q', 'I', '.', 'h', 'K', '6', 'A', '_', 'i', 'C', 'p', 'u', 'k', 'J', '9', 'N', 'l', '8', '0', 'r', 's', 'n' };
        private static char[] ThirdSequenceRule = new char[] { 'u', 'f', 'A', 'e', 'y', '3', 'L', '_', 'G', 'v', 't', 'n', 'c', 'D', 'p', '~', 'h', 'U', 'g', 'S', 'H', 'k', 's', 'B', 'Y', 'a', '8', '.', '6', 'd', 'z', 'V', 'I', 'J', 'R', 'W', 'T', 'l', 'o', 'q', '-', '4', 'O', 'P', 'm', 'w', 'C', 'b', 'F', 'i', 'M', 'Z', 'K', '2', '7', 'j', '5', 'E', 'Q', 'r', '9', '1', 'N', '0' };
        private static char[] FourthSequenceRule = new char[] { 'b', '3', 'E', 'q', 'f', '9', 'w', 'Q', 'A', 'o', 'N', 'k', '2', 'x', '1', 'O', '_', '-', 'H', '7', '5', 'a', 'g', 'V', 'X', 'M', 'd', 'W', 'G', 'n', 'z', 'I', 'm', 'K', 'J', 'D', '6', 'l', 'c', 'i', 'j', 'e', 'Z', 'F', 'P', 'L', 'T', 'h', 'R', 'B', 'r', '~', '0', '.', 'u', 'v', 't', 'S', 'U', '8', 'C', 's', '4', 'p', 'Y', 'y' };
        private static char[] GetSequenceRule(int digitIndex)
        {
            if (digitIndex % 4 == 0)
            {
                return FourthSequenceRule;
            }
            if (digitIndex % 3 == 0)
            {
                return ThirdSequenceRule;
            }
            if (digitIndex % 2 == 0)
            {
                return SecondSequenceRule;
            }
            return FirstSequenceRule;
        }
        private static char GetMinChar(int digitIndex)
        {
            return GetSequenceRule(digitIndex)[0];
        }
        public static string GetMinimumSequence(int digitNo)
        {
            var result = "";
            for (int i = 1; i <= digitNo; i++)
            {
                result = $"{result}{GetMinChar(i)}";
            }
            return result;
        }
        
        public static string IncrementSequence(string sequence)
        {
            int digitNo = sequence.Length;
            var result = sequence.ToCharArray();
            char nextChar;
            for (int i = 1; i <= digitNo; i++)
            {
                var sequnceRule = GetSequenceRule(i);
                nextChar = Increment(sequence[i-1], sequnceRule);
                if (!nextChar.Equals(sequence[i-1]))
                {
                    result[i-1] = nextChar;
                    return string.Join("",result);
                }
            }
            //if anything wasn't found to increment add another digit
            return $"{string.Join("", result)}{ GetMinChar(digitNo + 1)}";
        }
        private static char Increment(char sequence, char[] sequenceRule)
        {
            var index=Array.FindIndex(sequenceRule, x => x.Equals(sequence));
            //if the sequence was maxed out return the same char
            if(index== sequenceRule.Length - 1)
            {
                return sequenceRule[index];
            }
            return sequenceRule[index + 1];
        }
    }
}
