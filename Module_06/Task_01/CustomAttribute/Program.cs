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
            var CustomItem = new CustomItem("propName", "propValue");

            var customManager = new CustomItemManager();
            var l = customManager.ReturnItemProperties(typeof(CustomAttribute));
        }
    }
}
