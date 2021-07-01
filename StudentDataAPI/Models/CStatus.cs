using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataAPI.Models
{
    public class CStatus
    {
        #region Memeber Variables
        private bool _bSuccess; // to store status
        private string _strStatusDetails; // to store status details
        private string _strErrorCode; //To store error code

        #endregion

        #region Constructors
        public CStatus()
        {
            _bSuccess = false;
            _strStatusDetails = "";
            _strErrorCode = "";
        }
        public CStatus(bool strStatus, string strStatusDetails, string strErrorCode)
        {
            _bSuccess = strStatus;
            _strStatusDetails = strStatusDetails;
            _strErrorCode = strErrorCode;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Used to store status
        /// </summary>
        public bool Success
        {
            get { return _bSuccess; }
            set { _bSuccess = value; }
        }

        /// <summary>
        /// Used to store status details
        /// </summary>
        public string StatusDetails
        {
            get { return _strStatusDetails; }
            set { _strStatusDetails = value; }
        }

        /// <summary>
        /// Used To Store Error Code
        /// </summary>
        public string ErrorCode
        {
            get { return _strErrorCode; }
            set { _strErrorCode = value; }
        }

        #endregion
    }
}
