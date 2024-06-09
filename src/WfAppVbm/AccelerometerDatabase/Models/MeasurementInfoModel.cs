using System;

namespace AccelerometerDatabase.Models {
    public class MeasurementInfoModel {
        public int MeasurementId { get; set; }
        public DateTime? FirstStartTime { get; set; }
        public string SensorDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SerialPort { get; set; }
    }
}
