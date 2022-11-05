using System;
using System.Configuration;
using System.Reflection;
using CustomAttribute;

namespace CustomAttribute
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customItem = new CustomItem("propName", 14);

            var customManager = new CustomItemManager();
            customManager.ReturnItemProperties(typeof(CustomItem));
        }
    }
}
