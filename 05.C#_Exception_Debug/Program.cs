using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Exceptions_Debug
{

    public class Program
    {
        static void Main(string[] args)
        {
            //Division(2, 0);

            //var temp = new Temperature(0);
            //temp.ShowTemperature();

            // will show in the output window
            //Debug.WriteLine("Test Debug");

            var customDefine = new ConditionalCompilation();
            customDefine.ShowIfDebug();
        }


        //Create methods which checks input arguments and throws exceptions
        //Create custom exceptions and throw them
        //Write Try-catch-Finally block with multiple catch statements
        //Rethrow exception
        //Add conditional compilation symbols
        //Use debug class to write debug information to output window

        public static void Division(int num1, int num2)
        {
            var result = 0;

            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Log(e);
                throw;
            }
            catch (Exception e)
            {
                Log(e);
                throw;
            }
            finally
            {
                Console.WriteLine(result);
            }
        }
        private static void Log(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }

        private static void CustomRethrow()
        {
            try
            {
                // code
            }
            catch (IOException one)
            {
                Log(one);
                // don't throw
            }
            catch (DivideByZeroException two)
            {
                // something else
                throw new Exception("Other exception occupered - Wrapped");
            }
            catch
            {
                Debug.WriteLine("The error will be handled higher up the call stack");
            }
        }

    }

    public class CustomTemperatureException : Exception
    {
        public CustomTemperatureException(string message) : base(message)
        {
        }
    }
    public class Temperature
    {
        private int _temperature;

        public Temperature(int temp)
        {
            this._temperature = temp;
        }

        public void ShowTemperature()
        {
            if (_temperature == 0)
            {
                Debug.Write("Temperature is 0");
                throw (new CustomTemperatureException("Zero Temperature found"));
            }
            else if (_temperature > 100)
            {
                Debug.Write("Temperature > 100");
                throw (new CustomTemperatureException("Temperature too high"));
            }
            else
            {
                Console.WriteLine(_temperature);
            }
        }
    }


    public class ConditionalCompilation
    {
        // conditional can be used only on void or classes 
        [Conditional("DEBUG")]
        public void ShowIfDebug()
        {
#if DEBUG
            Console.WriteLine("Debug Mode ON!");
#else
            Console.WriteLine("Debug mode off!");
#endif


            Console.WriteLine("Debug mode ON, Conditional!");
        }
    }
    
}
