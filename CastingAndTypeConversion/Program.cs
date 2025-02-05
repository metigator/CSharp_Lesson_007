namespace CastingAndTypeConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Int16 s;  // short s; => 16 bit
            Int32 x;  // int x; => 32 bit
            Int64 l;  // long l; => 64 bit

            short sh;    // -32767 - 32768
            ushort ush;  // 0 - 65???;

            //1. Implicit Conversion

            var num = 16;
            // string str = num;// cannot implicitly convert type int to string

            // Implicitly convert
            int numberInt = 100;
            long numberLong = numberInt;

            //2. Explicit Casting 
            long nL = 1000;
            if (nL <= Int32.MaxValue)
            {
                int nI = (int)nL;
            }

            double d = 1234.8;
            int i = (int)d;
            Console.WriteLine(i);

            //3. Boxing / Unboxing
            // Boxing : convert value type to  reference type
            // Unboxing : convert reference type to value type

            int a = 10; // value type
            Object obj;  // reference type

            obj = a;     // conversion done implicitly => Boxing
            int y = (int)obj;  // => Unboxing

            //4. Convert from string to a Numeric one (Parse/TryParse)
            //a- Parse
            string stringValue = "120";

            // int number = stringValue;  --> Error

            int number = int.Parse(stringValue);
            Console.WriteLine(number);

            stringValue = "w120";
            // number = int.Parse(stringValue);  // Exception :the input dtring was not in acorrect format -->We need TryParse

            // b- TryParse

            string stringVal = "9999999999999999999";
            if (int.TryParse(stringVal, out number))
            {
                Console.WriteLine(number);

            }
            else
            {
                Console.WriteLine("Invalid number provided or doesnt fit integer ");
            }

            //5. Convert Class
            stringValue = "66s";
            // number= Convert.ToInt32(stringVal);// --->Exception:the input string was not in a correct format
            Console.WriteLine(number);

            //-------------------

            //decimal       ToDecimal(string)
            //float         ToSingle(string)
            //double        ToDouble(string)
            //short         ToInt16(string)
            //int           ToInt32(string)
            //long          ToInt64(string)
            //ushort        ToUInt16(string)
            //uint          ToUInt32(string)
            //ulong         ToUInt64(string)

            //-------------------------------

            // 6. BitConvert and Value
            // int to binary
            number = 255;
            var bytes = BitConverter.GetBytes(number);

            foreach (var b in bytes)
            {
                Console.WriteLine(b);       // 255 0 0 0
            }


            foreach (var b in bytes)
            {
                var binary = Convert.ToString(b, 2).PadLeft(8, '0'); // convert to binary 
                Console.WriteLine(binary);       // 11111111 00000000 00000000 00000000
            }

            //string to binary

            var name = "Issam";
            char[] letters = name.ToCharArray();
            foreach (char c in letters)
            {
                int ascii = Convert.ToInt32(c);
                var output = $"'{c}' -> ASCII:{ascii}, Binary: {Convert.ToString(ascii, 2).PadLeft(8, '0')}, Hexadecimal:{ascii:x}";
                Console.WriteLine(output);
            }
            // convert hexadecimal to string

            string[] hexValue = { "49", "73", "73", "61", "6d" };
            //..1
            foreach (var hex in hexValue)
            {
                int value = Convert.ToInt32(hex, 16);
                stringValue = Char.ConvertFromUtf32(value);//  convert integer value to charecter 
                Console.WriteLine(stringValue);

            }
            Console.WriteLine("-----");
            //..2
            foreach (var hex in hexValue)
            {
                int value = Convert.ToInt32(hex, 16);
                var ch = (char)value;
                Console.WriteLine(ch);

            }

            // convert hexadecimal to integer
            var hexa = "8E2";
            number = Int32.Parse(hexa, System.Globalization.NumberStyles.HexNumber);

            Console.WriteLine(number);    //2274

            Console.ReadKey();
        }
    }
}