namespace XMLWebApiCore.BL
{
    public interface IJsonService
    {
        public string getDrawingDetail(string name);
        public string getEquipmentDetail(int drawingId);
        public string getPipeConnectorDetail(int drawingId);
        public string getProcessInstrumentDetail(int drawingId);
        public string getPropertyBreakDetail(int drawingId);
        public string getSignalLineDetail(int drawingId);
        public string getInstrumentComponentDetail(int drawingId);
        public string getPipingComponentDetail(int drawingId);
        public string getNozzleDetail(int drawingId);
        public string getProcessLineDetail(int drawingId);
        public string getIntermediateDetail(int drawingId);
        public string GetAllDetails(int drawingId);
    }
}