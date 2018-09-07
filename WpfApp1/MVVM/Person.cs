using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.MVVM
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class PersonDataHelper
    {
        public static ObservableCollection<Person> GetPersons()
        {
            ObservableCollection<Person> samplePersons = new ObservableCollection<Person>();
            samplePersons.Add(new Person() { Name = "张三", Age = 33 });
            samplePersons.Add(new Person() { Name = "王五", Age = 22 });
            samplePersons.Add(new Person() { Name = "李四", Age = 35 });
            samplePersons.Add(new Person() { Name = "LearningHard", Age = 27 });
            return samplePersons;
        }
    }
    public class QueryCommand : ICommand
    {
        #region Fields
        private Action _execute;
        private Func<bool> _canExecute;
        #endregion 

        public QueryCommand(Action execute)
            : this(execute, null)
        {
        }
        public QueryCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        #region ICommand Member

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;

                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;

                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
        #endregion
    }
    public class PersonListViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _searchText;
        private ObservableCollection<Person> _resultList;
        #endregion 

        #region Properties

        public ObservableCollection<Person> PersonList { get; private set; }

        // 查询关键字
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        // 查询结果
        public ObservableCollection<Person> ResultList
        {
            get { return _resultList; }
            set
            {
                _resultList = value;
                RaisePropertyChanged("ResultList");
            }
        }

        public ICommand QueryCommand
        {
            get { return new QueryCommand(Searching, CanSearching); }
        }

        #endregion 

        #region Construction
        public PersonListViewModel()
        {
            PersonList = PersonDataHelper.GetPersons();
            _resultList = PersonList;
        }

        #endregion

        #region Command Handler
        public void Searching()
        {
            ObservableCollection<Person> personList = null;
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                ResultList = PersonList;
            }
            else
            {
                personList = new ObservableCollection<Person>();
                foreach (Person p in PersonList)
                {
                    if (p.Name.Contains(SearchText))
                    {
                        personList.Add(p);
                    }
                }
                if (personList != null)
                {
                    ResultList = personList;
                }
            }
        }

        public bool CanSearching()
        {
            return true;
        }

        #endregion 

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods
        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion 
    }
}
