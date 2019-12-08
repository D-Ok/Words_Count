using System;
using System.Runtime.Serialization;

namespace WordsCountSkyrtaOliinyk.DBModels
{
    [DataContract(IsReference = true)]
    public class Request
    {
        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private String _path;
        [DataMember]
        private long _charsNumber;
        [DataMember]
        private int _wordsNumber;
        [DataMember]
        private int _stringsNumber;
        [DataMember]
        private DateTime _dateOfRequest;
        [DataMember]
        private Guid _ownerGuid;
        [DataMember]
        private User _owner;
        #endregion

        #region Properties
        public Guid Guid
        {
            get => _guid;
            set => _guid = value;
        }

        public string Path
        {
            get => _path;
            set => _path = value;
        }

        public long CharsNumber
        {
            get => _charsNumber;
            set => _charsNumber = value;
        }

        public int WordsNumber
        {
            get => _wordsNumber;
            set => _wordsNumber = value;
        }

        public int StringsNumber
        {
            get => _stringsNumber;
            set => _stringsNumber = value;
        }

        public DateTime DateOfRequest
        {
            get => _dateOfRequest;
            set => _dateOfRequest = value;
        }

        public virtual User Owner
        {
            get => _owner;
            set => _owner = value;
        }

        public Guid OwnerGuid
        {
            get => _ownerGuid;
            set => _ownerGuid = value;
        }
        #endregion

        #region Constructor
        public Request(string path, long charsNum, int wordsNum, int stringsNum) : this()
        {
            _guid = Guid.NewGuid();
            _path = path;
            _dateOfRequest = DateTime.Now.ToLocalTime();
            _charsNumber = charsNum;
            _wordsNumber = wordsNum;
            _stringsNumber = stringsNum;
        }

        public Request()
        {

        }
        #endregion

    }
}
