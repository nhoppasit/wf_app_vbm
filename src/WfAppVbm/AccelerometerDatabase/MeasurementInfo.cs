using DB_Management.Generic;
using System;

namespace AccelerometerDatabase {
    public class MeasurementInfo {

        private readonly string _connectionString;

        public MeasurementInfo(string connectionString) {
            _connectionString = connectionString;
        }

        public string AddNew() {
            try {
                using (GenericManagement_MSSQL db = new GenericManagement_MSSQL()) {
                    db.ConnectionString = _connectionString;
                    ResultTypeDS result = new ResultTypeDS();
                    return JsonConvert.SerializeObject(result);
                }
            } catch (Exception ex) {
                return JsonConvert.SerializeObject(new { Code = -2, Message = ex.Message });
            }
        }
    }

}
