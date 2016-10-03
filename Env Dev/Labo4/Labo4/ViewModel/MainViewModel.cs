using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Labo4.Model;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Labo4.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                RaisePropertyChanged("Students");
            }
        }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                if(_selectedStudent != null)
                {
                    RaisePropertyChanged("SelectedStudent");
                }
            }
        }

        private ICommand _editStudentCommand;
        public ICommand EditStudentCommand
        {
            get
            {
                if (this._editStudentCommand == null)
                    this._editStudentCommand = new RelayCommand(() => EditStudent());
                return this._editStudentCommand;
            }
        }

        private INavigationService _navigationService;
        [PreferredConstructor]
        public MainViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            Students = new ObservableCollection<Student>(AllStudents.GetAllStudents());
        }

        private void EditStudent()
        {
            if (CanExecute() == true)
                _navigationService.NavigateTo("SecondPage", SelectedStudent);
        }

        public bool CanExecute()
        {
            return (SelectedStudent == null) ? false : true;
        }
    }
}