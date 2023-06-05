namespace AAB_KATM_SERVER.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public float NumberOfContracts { get; set; }

        public float NumberOfDeviations { get; set; }

        public float LoanAgreementAmount { get; set; }

        public float AmountOfOverdueDebt { get; set; }

        public float AmountOfOverdueInterests { get; set; }

        public float TheAmountOfUrgentDebt { get; set; }    
    }
}
