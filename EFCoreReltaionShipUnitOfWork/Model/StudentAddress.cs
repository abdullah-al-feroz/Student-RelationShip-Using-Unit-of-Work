namespace EFCoreReltaionShipUnitOfWork.Model
{
    public class StudentAddress
    {
        public int StudentAddressId { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
       


    }
}
