﻿namespace Artech.MiniMvc
{
    public class RouteTable
    {
        public static RouteDictionary Routes { get; private set; }

        static RouteTable()
        {
            Routes = new RouteDictionary();
        }
    }
}