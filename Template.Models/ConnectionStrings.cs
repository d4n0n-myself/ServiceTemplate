﻿namespace Template.Models
{
	public class ConnectionStrings
	{
		public ConnectionStrings(string valueString)
		{
			Value = valueString;
		}

		public static ConnectionStrings Current { get; set; }

		public static void Change(string newConn)
		{
			Current.Value = newConn;
		}
		
		public string Value { get; private set; }
	}
}