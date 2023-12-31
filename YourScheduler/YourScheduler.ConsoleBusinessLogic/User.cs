﻿using System.ComponentModel;
using System.Net.Http.Headers;

namespace YourScheduler.ConsoleBusinessLogic
{
    public class User
    {
        private bool IsInputValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;
            else
            {
                return true;
            }

        }

        public Guid Id { get; set; } = Guid.NewGuid();

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (IsInputValid(value))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentNullException("Wrong Input");
                }
            }
        }

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (IsInputValid(value))
                {
                    _surname = value;
                }
                else
                {
                    throw new ArgumentNullException("Wrong Input");
                }
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                if (IsInputValid(value))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentNullException("Wrong Input");
                }
            }
        }

        private string _displayname;

        public string DisplayName
        {
            get { return _displayname; }
            set
            {
                if (IsInputValid(value))
                {
                    _displayname = value;
                }
                else
                {
                    throw new ArgumentNullException("Wrong Input");
                }
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (IsInputValid(value))
                {
                    _password = value;
                }
                else
                {
                    throw new ArgumentNullException("Wrong Input");
                }
            }
        }


        public User(string name, string surname, string email, string displayName, string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DisplayName = displayName;
            Password = password;
        }
    }
}