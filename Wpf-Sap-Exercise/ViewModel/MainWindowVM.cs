using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Wpf_Sap_Exercise.Model;
using Wpf_Sap_Exercise.MVVMBase;

namespace Wpf_Sap_Exercise.ViewModel
{
    public class MainWindowVM : VMBase
    {
        public string WindowTitle { get; set; }

        public ObservableCollection<Script> ScriptList { get; set; }
        private Script _newScript;
        public Script NewScript
        {
            get { return _newScript; }
            set { _newScript = value; OnPropertyChange("NewScript"); }
        }
        private string _duplicateRecordMsg;
        public string DuplicateRecordMsg
        {
            get { return _duplicateRecordMsg; }
            set { _duplicateRecordMsg = value; OnPropertyChange("DuplicateRecordMsg"); }
        }

        public ICommand AddNewScript { get; set; }

        private Random _randome = new Random();
        
        public MainWindowVM()
        {
            WindowTitle = "Script Manager";
            NewScript = new Script() { ScriptType = "A", InitialValue = 0 };
            ScriptList = new ObservableCollection<Script>();
            ScriptList.Add(new Script() { ScriptTitle = "MSFT", ScriptType = "A", InitialValue = 10, CurrentValue = 0 });
            ScriptList.Add(new Script() { ScriptTitle = "YHOO", ScriptType = "B", InitialValue = 10, CurrentValue = 0 });
            AddNewScript = new RelayCommand<Script>(addNewScript);

            DispatcherTimer dt4TypeA = new DispatcherTimer();
            dt4TypeA.Tick += TypeA_Tick;
            dt4TypeA.Interval = new TimeSpan(0, 0, 5);
            dt4TypeA.Start();

            DispatcherTimer dt4TypeB = new DispatcherTimer();
            dt4TypeB.Tick += TypeB_Tick;
            dt4TypeB.Interval = new TimeSpan(0, 0, 10);
            dt4TypeB.Start();
        }

        private void TypeA_Tick(object sender, EventArgs e)
        {
            var items = ScriptList.Where(s => s.ScriptType == "A");
            foreach(var item in items)
            {
                item.LastValue = item.CurrentValue;
                item.CurrentValue = _randome.Next(-50, 50);
            }
        }


        private void TypeB_Tick(object sender, EventArgs e)
        {
            var items = ScriptList.Where(s => s.ScriptType == "B");
            foreach (var item in items)
            {
                item.LastValue = item.CurrentValue;
                item.CurrentValue = _randome.Next(-50, 50);
            }
        }

        private void addNewScript(Script obj)
        {
            if (string.IsNullOrEmpty(obj.ScriptTitle) == false)
            {
                var sameTitleObj = ScriptList.FirstOrDefault(s => s.ScriptTitle == obj.ScriptTitle);
                if (sameTitleObj != null)
                {
                    DuplicateRecordMsg = "Same name '" + sameTitleObj.ScriptTitle + "' script already exists.";
                }
                else
                {
                    DuplicateRecordMsg = string.Empty;
                    ScriptList.Add(obj);
                }
                NewScript = new Script() { ScriptType = "A", InitialValue = 0 };
            }
        }
    }
}
