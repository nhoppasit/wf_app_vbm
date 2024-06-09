using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DB_Management {
    public class DbCommand_MYSQL : IDisposable {
        #region Dispose

        // Implement IDisposable. 
        // Do not make this method virtual. 
        // A derived class should not be able to override this method. 
        private bool disposed = false;
        public void Dispose() {
            Dispose(true);
            // This object will be cleaned up by the Dispose method. 
            // Therefore, you should call GC.SupressFinalize to 
            // take this object off the finalization queue 
            // and prevent finalization code for this object 
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios. 
        // If disposing equals true, the method has been called directly 
        // or indirectly by a user's code. Managed and unmanaged resources 
        // can be disposed. 
        // If disposing equals false, the method has been called by the 
        // runtime from inside the finalizer and you should not reference 
        // other objects. Only unmanaged resources can be disposed. 
        protected virtual void Dispose(bool disposing) {
            // Check to see if Dispose has already been called. 
            if (!this.disposed) {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources. 
                if (disposing) {
                    // Dispose managed resources.
                    this.CloseConnection();
                    this.ReturnConnection();
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here. 
                // If disposing is false, 
                // only the following code is executed.                                

                // Note disposing has been done.
                disposed = true;
            }
        }

        #endregion

        #region Variables

        /// <summary>
        /// Get connection string of BO23 database
        /// </summary>
        public string ConnectionString { get; private set; }
        private Object _SqlCommand;
        private int _TIMEOUT = 14400;

        #endregion

        #region Constructor & destructor

        public DbCommand_MYSQL() {
            //ConnectionString = Properties.Settings.Default.ConnectionString + ";Password=" + DB_Security.Settings.Password;
            ConnectionString = DB_Security.Settings.ConnectionString;
            _SqlCommand = new MySqlCommand();
        }
        ~DbCommand_MYSQL() { Dispose(); }

        #endregion

        #region Set command

        public void SetCommandText(string cmdText) {
            ((MySqlCommand)(this._SqlCommand)).Parameters.Clear();
            ((MySqlCommand)(this._SqlCommand)).CommandText = cmdText;
            ((MySqlCommand)(this._SqlCommand)).CommandType = CommandType.Text;
        }
        public void SetCommandStoredProcedure(string storedProcName) {
            ((MySqlCommand)(this._SqlCommand)).Parameters.Clear();
            ((MySqlCommand)(this._SqlCommand)).CommandText = storedProcName;
            ((MySqlCommand)(this._SqlCommand)).CommandType = CommandType.StoredProcedure;
        }
        public void AddInputParameter(string paramName, MySqlDbType paramType, object paramValue) {
            MySqlParameter param = new MySqlParameter(paramName, paramType);
            if (paramValue == null) param.Value = DBNull.Value;
            else param.Value = paramValue;
            param.Direction = ParameterDirection.Input;
            ((MySqlCommand)(this._SqlCommand)).Parameters.Add(param);
        }

        /// <summary>
        /// เพิ่ม SqlParameter("ReturnValue",DBNull.Value) , ParameterDirection.ReturnValue
        /// </summary>
        public void SetReturnValue() {
            MySqlParameter RetParam = new MySqlParameter("ReturnValue", DBNull.Value);
            RetParam.Direction = ParameterDirection.ReturnValue;
            ((MySqlCommand)(this._SqlCommand)).Parameters.Add(RetParam);
        }

        /// <summary>
        /// รับค่า Return Value สำหรับแจ้งผลเป็นเลขใดๆ
        /// </summary>
        /// <returns>เลขใด ๆ แจ้งผลลัพธ์การทำงานของคำสั่ง, 0 = SUCCESS, -1 = NOT FOUND / DO NOTHING, -2 = ERROR</returns>
        public int GetReturnValue() {
            return Convert.ToInt32(((MySqlCommand)(this._SqlCommand)).Parameters["ReturnValue"].Value);
        }

        /// <summary>
        /// เพิ่มพารามิเตอร์ แบบ OUTPUT
        /// </summary>
        /// <param name="paramName">Samples are @IntResult or @MessageResult</param>
        /// <param name="paramType">Samples are int or nvarchar(100)</param>
        public void AddOutputParameter(string paramName, MySqlDbType paramType, int paramSize = 0) {
            MySqlParameter param;
            if (paramSize > 0) param = new MySqlParameter(paramName, paramType, paramSize);
            else param = new MySqlParameter(paramName, paramType);
            param.Direction = ParameterDirection.Output;
            ((MySqlCommand)(this._SqlCommand)).Parameters.Add(param);
        }

        /// <summary>
        /// รับค่าจาก OUTPUT อ่างอิงตามชื่อ
        /// </summary>
        /// <param name="paramName">Sample is @IntResult</param>
        /// <returns>จำนวนแถวถูกที่ดำเนินการ</returns>
        public int OutputParameterToInt(string paramName) {
            return Convert.ToInt32(((MySqlCommand)(this._SqlCommand)).Parameters[paramName].Value);
        }

        /// <summary>
        /// รับค่าจาก OUTPUT อ่างอิงตามชื่อ
        /// </summary>
        /// <param name="paramName">Sample is @MessageResult</param>
        /// <returns>ข้อความใด ๆ</returns>
        public string OutputParameterToString(string paramName) {
            return Convert.ToString(((MySqlCommand)(this._SqlCommand)).Parameters[paramName].Value);
        }

        public object OutputParameterToObject(string paramName) {
            return ((MySqlCommand)(this._SqlCommand)).Parameters[paramName].Value;
        }

        #endregion

        #region Execute

        public DataSet ExecuteToDataSet() {
            DataSet dts = new DataSet();
            using (MySqlConnection conn = new MySqlConnection()) {
                conn.ConnectionString = this.ConnectionString;
                ((MySqlCommand)(this._SqlCommand)).Connection = conn;
                //((SqlCommand)(this._SqlCommand)).CommandTimeout = _TIMEOUT;
                MySqlDataAdapter adapter = new MySqlDataAdapter(((MySqlCommand)(this._SqlCommand)));
                adapter.Fill(dts);
            }
            return dts;
        }
        public DataSet ExecuteToDataSet(DataSet typedDataSet, string tableName) {
            using (MySqlConnection conn = new MySqlConnection()) {
                conn.ConnectionString = this.ConnectionString;
                ((MySqlCommand)(this._SqlCommand)).Connection = conn;
                ((MySqlCommand)(this._SqlCommand)).CommandTimeout = _TIMEOUT;
                MySqlDataAdapter adapter = new MySqlDataAdapter(((MySqlCommand)(this._SqlCommand)));
                adapter.Fill(typedDataSet, tableName);
            }
            return typedDataSet;
        }
        public int ExecuteNonQuery() {
            int result = 0;
            using (MySqlConnection conn = new MySqlConnection()) {
                conn.ConnectionString = this.ConnectionString;
                ((MySqlCommand)(this._SqlCommand)).Connection = conn;
                //((SqlCommand)(this._SqlCommand)).CommandTimeout = _TIMEOUT;
                this.OpenConnection();
                result = ((MySqlCommand)(this._SqlCommand)).ExecuteNonQuery();
                this.CloseConnection();
            }
            return result;
        }
        public int ExecuteNonQuery(MySqlConnection conn, MySqlTransaction tx) {
            int result = 0;
            try {
                //conn.ConnectionString = this.ConnectionString;
                ((MySqlCommand)(this._SqlCommand)).Connection = conn;
                //((SqlCommand)(this._SqlCommand)).CommandTimeout = _TIMEOUT;
                //this.OpenConnection();
                //tx = conn.BeginTransaction();
                ((MySqlCommand)(this._SqlCommand)).Transaction = tx;
                result = ((MySqlCommand)(this._SqlCommand)).ExecuteNonQuery();
                //this.CloseConnection();
            } catch (Exception ex) { throw ex; }
            return result;
        }

        #endregion

        #region Connection

        public void OpenConnection() {
            if (((MySqlCommand)(this._SqlCommand)).Connection.State != ConnectionState.Open) {
                ((MySqlCommand)(this._SqlCommand)).Connection.Open();
            }
        }
        public void CloseConnection() {
            if (((MySqlCommand)(this._SqlCommand)).Connection.State != ConnectionState.Closed) {
                ((MySqlCommand)(this._SqlCommand)).Connection.Close();
            }
        }
        public void ReturnConnection() {
            ConnectionString = null;
        }

        #endregion
    }
}
