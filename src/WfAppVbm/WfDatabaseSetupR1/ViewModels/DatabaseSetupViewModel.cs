// DatabaseSetupViewModel.cs
using System.ComponentModel;
using WfDatabaseSetupR1.Models;

namespace WfDatabaseSetupR1.ViewModels {
    public class DatabaseSetupViewModel : INotifyPropertyChanged {
        private DatabaseSetupModel _model;

        public string ServerName {
            get { return _model.ServerName; }
            set {
                _model.ServerName = value;
                OnPropertyChanged(nameof(ServerName));
                OnPropertyChanged(nameof(ConnectionString));
            }
        }

        public string InstanceName {
            get { return _model.InstanceName; }
            set {
                _model.InstanceName = value;
                OnPropertyChanged(nameof(InstanceName));
                OnPropertyChanged(nameof(ConnectionString));
            }
        }

        public string InstanceVersion {
            get { return _model.InstanceVersion; }
            set {
                _model.InstanceVersion = value;
                OnPropertyChanged(nameof(InstanceVersion));
            }
        }

        public string ConnectionString {
            get { return _model.ConnectionString; }
        }

        public DatabaseSetupViewModel() {
            _model = new DatabaseSetupModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
