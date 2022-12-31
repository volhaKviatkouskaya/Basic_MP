using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UI
{
    public static class ShowConsole<T>
    {
        public static void ShowItems(List<T> itemsList)
        {
            foreach (var item in itemsList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
