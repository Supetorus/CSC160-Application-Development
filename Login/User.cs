using System;
using System.Collections.Generic;
using System.Text;

namespace Login
{
	public class User
	{
		public string Name;
		public string Email;
		public string Username;
		public string Password;
		public string Note;
		public User(string name, string email, string username, string password)
		{
			Name = name;
			Email = email;
			Username = username;
			Password = password;
		}

		public User(string name, string email, string username, string password, string note)
		{
			Name = name;
			Email = email;
			Username = username;
			Password = password;
			Note = note;
		}
	}
}
