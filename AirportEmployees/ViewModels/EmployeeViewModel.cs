using AirportEmployees.Models;
using AirportEmployees.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AirportEmployees.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private ConnectionService ConnectionService;
        private int _page = 1;
        public int Page
        {
            get => _page;
            set
            {
                if (_page != value)
                {
                    _page = value;
                    OnPropertyChanged(); // Aquí [CallerMemberName] sí envía "Page"
                }
            }
        }
        int pageSize = 20;
        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeeViewModel(ConnectionService connectionService)
        {
            this.ConnectionService = connectionService;
            Page = 1;
            Employees = new ObservableCollection<Employee>();
            GoToPage(1);
        }

        public void NextPage()
        {
            GoToPage(Page + 1);
        }

        public void PreviousPage()
        {
            GoToPage(Page - 1);
        }

        public void GoToPage(int targetPage)
        {
            if (targetPage < 1)
            {
                targetPage = 1;
            }

            int skip = (targetPage - 1) * pageSize;

            using var context = ConnectionService.CreateDbContext();

            var employees = context.Employees
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            Employees.Clear();
            foreach (var emp in employees)
            {
                Employees.Add(emp);
            }

            Page = targetPage;
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
