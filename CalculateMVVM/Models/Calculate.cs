using System;
using System.Data;

namespace CalculateMVVM.Models
{
    public static class Calculate
    {
        private static DataTable Table = new DataTable();

        public static string Calc(string Expression)
        {
            string result = "0";
            try
            {
                if (Expression != null)
                    //calculate our expression
                    result = Convert.ToDouble(Table.Compute(Expression, string.Empty)).ToString();
            }
            catch (System.FormatException) { result = "Nan"; }
            catch (System.Data.SyntaxErrorException) { result = "Nan"; }
            catch (System.InvalidCastException) { result = "Nan"; }

            return result;
        }
    }
}
