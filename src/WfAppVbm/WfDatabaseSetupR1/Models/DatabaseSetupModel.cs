// DatabaseSetupModel.cs

namespace WfDatabaseSetupR1.Models {
    public class DatabaseSetupModel {
        public string ServerName { get; set; }
        public string InstanceName { get; set; }
        public string InstanceVersion { get; set; }
        public string ConnectionString {
            get {
                return $"Server={ServerName}\\{InstanceName};Database=accelerometer_data;Integrated Security=True;";
            }
        }
    }
}
