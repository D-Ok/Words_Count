using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace WordsCountSkyrtaOliinyk.DBModels
{
    [DataContract(IsReference = true)]
    public class User : IDBModel
    {
        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _firstName;
        [DataMember]
        private string _lastName;
        [DataMember]
        private string _login;
        [DataMember]
        private string _email;
        [DataMember]
        private string _password;
        [DataMember]
        private List<Request> _requests;
        [DataMember]
        private DateTime _dateOfEnter;
        #endregion

        #region Properties
        public Guid Guid
        {
            get
            {
                return _guid;
            }
            private set
            {
                _guid = value;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            private set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            private set
            {
                _lastName = value;
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }
            private set
            {
                _login = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            private set
            {
                _email = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set { _password = value; }
        }

        public virtual List<Request> Requests
        {
            get => _requests;
            set => _requests = value;
        }

        public DateTime DateOfEnter
        {
            get
            {
                return _dateOfEnter;
            }
            set
            {
                _dateOfEnter = value;
            }
        }
        #endregion

        #region Constructor

        public User(string firstName, string lastName, string email,string login, string password) : this()
        {
            _guid = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _login = login;
            _dateOfEnter = DateTime.Now.ToLocalTime();
            SetPassword(password);
        }
        
        public User()
        {
            _requests = new List<Request>();
        }
        #endregion

        private void SetPassword(string password)
        {
            _password = encryptPassword(password);
        }

        public bool CheckPassword(string password)
        {
            return _password == encryptPassword(password);
        }

        private string encryptPassword(string password)
        {
            String salt = "LastName" + "date";
            byte[] salt_byte = new byte[salt.Length];
            salt_byte = Encoding.UTF8.GetBytes(salt);

            Aes aes = new AesManaged();
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt_byte);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);

            using (MemoryStream encryptionStream = new MemoryStream())
            {
                using (CryptoStream encrypt = new CryptoStream(encryptionStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] utfD1 = new byte[password.Length];
                    utfD1 = Encoding.UTF8.GetBytes(password);
                    encrypt.Write(utfD1, 0, utfD1.Length);
                    encrypt.Close();
                    return Convert.ToBase64String(encryptionStream.ToArray());
                }
            }
        }


        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
