using System;

namespace BookService.Format
{
    public class BookProvider : ICustomFormatter, IFormatProvider
    {
        public object GetFormat(Type formatType)
        {
            return (formatType == typeof(ICustomFormatter)) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider provider)
        {
            if (arg == null)
                throw new ArgumentNullException();

            if (format == null)
            {
                return arg.ToString();
            }

            string result = "";

            for (int i = 0; i < format.Length; i++)
            {
                switch (format[i])
                {
                    case 'I':
                        result += arg.ToString();
                        break;
                    case 'A':
                        result += "Author: " + arg;
                        break;
                    case 'T':
                        result += "Title: " + arg;
                        break;
                    case 'P':
                        result += "Publisher: " + arg;
                        break;
                    case 'Y':
                        result += arg.ToString();
                        break;
                    case 'N':
                        result += arg.ToString();
                        break;
                    case 'C':
                        result += "Price: " + arg;
                        break;
                    default:
                        throw new ArgumentException();
                }
                if (i != format.Length - 1)
                {
                    result += ", ";
                }
            }
            return result;
        }
    }
}