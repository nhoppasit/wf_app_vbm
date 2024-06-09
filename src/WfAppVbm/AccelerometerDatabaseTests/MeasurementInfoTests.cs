using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccelerometerDatabase.Tests {
    [TestClass()]
    public class MeasurementInfoTests {
        [TestMethod()]
        public void AddNewTest() {
            try {
                AccelerometerDatabase.MeasurementInfo measurementInfo = new AccelerometerDatabase.MeasurementInfo("Server=nhop\\SQLEXPRESS02;Database=accelerometer_data;Trusted_Connection=True;");
                measurementInfo.AddNew();
            } catch {
                Assert.Fail();
            }
        }
    }
}