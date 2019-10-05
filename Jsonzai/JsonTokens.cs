using System;

namespace Jsonzai
{
    public class JsonTokens
    {

        public const char OBJECT_OPEN = '{';
        public const char OBJECT_END = '}';
        public const char ARRAY_OPEN = '[';
        public const char ARRAY_END = ']';
        public const char DOUBLE_QUOTES = '"';
        public const char COMMA = ',';
        public const char COLON = ':';

        private readonly char[] src;
        private int index;

        public JsonTokens(string src)
        {
            this.src = src.ToCharArray();
            this.index = 0;
        }

        public char Current => src[index];

        public bool MoveNext() {
            index++;
            return index == src.Length ? false : true;
        }

        public void Trim() {
            while (src[index] == ' ') MoveNext();
        }

        public char Pop()
        {
            char token = src[index];
            index++;
            return token;
        }
        public void Pop(char expected)
        {
            if (Current != expected)
                throw new InvalidOperationException("Expected " + expected + " but found " + Current);
            index++;
        }

        /// <summary>
        /// Consumes all characters until find delimiter and accumulates into a string.
        /// </summary>
        /// <param name="delimiter">May be one of DOUBLE_QUOTES, COLON or COMA</param>
        public string PopWordFinishedWith(char delimiter)
        {
            Trim();
            string acc = "";
            for ( ; Current != delimiter; MoveNext())
            {
                acc += Current;
            }
            MoveNext(); // Discard delimiter
            Trim();
            return acc;
        }
        public string popWordPrimitive()
        {
            Trim();
            string acc = "";
            for( ;  !IsEnd(Current); MoveNext())
            {
                acc += Current;
            }
            Trim();
            return acc;
        }

        private bool IsEnd(char curr)
        {
            return curr == OBJECT_END || curr == ARRAY_END || curr == COMMA;
        }
    }
}
