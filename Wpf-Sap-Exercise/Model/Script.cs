using System;
using System.ComponentModel;
using Wpf_Sap_Exercise.MVVMBase;

namespace Wpf_Sap_Exercise.Model
{
    public class Script : VMBase, IDataErrorInfo
    {
        private string _scriptTitle;
        public string ScriptTitle
        {
            get { return _scriptTitle; }
            set
            {
                _scriptTitle = value;
                OnPropertyChange("ScriptTitle");
            }
        }

        private string _scriptType;
        public string ScriptType
        {
            get { return _scriptType; }
            set { _scriptType = value; OnPropertyChange("ScriptType"); }
        }

        private int _initialValue;
        public int InitialValue
        {
            get { return _initialValue; }
            set
            {
                _initialValue = value;
                OnPropertyChange("InitialValue");
            }
        }

        private int _lastValue;
        public int LastValue
        {
            get { return _lastValue; }
            set { _lastValue = value; OnPropertyChange("LastValue"); }
        }

        private int _currentValue;
        public int CurrentValue
        {
            get { return _currentValue; }
            set { _currentValue = value; OnPropertyChange("CurrentValue"); }
        }

        #region IDataErrorInfo Members
        public string Error { get { return this[null]; } }

        public string this[string propertyName]
        {
            get
            {
                string result = string.Empty;
                if (propertyName == "ScriptTitle")
                {
                    if(string.IsNullOrEmpty(this.ScriptTitle))
                    {
                        result += "Script Title is mandatory.";
                    }
                }
                if (propertyName == "InitialValue")
                {
                    if (this.InitialValue < -50 || this.InitialValue > 50)
                    {
                        result += "Current value should be between -50 to +50.";
                    }            
                }
                return result.Trim();
            }
        }
        #endregion
    }
}
