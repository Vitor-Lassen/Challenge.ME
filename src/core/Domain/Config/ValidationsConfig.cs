namespace Domain.Config
{
    public static class ValidationsConfig
    {
        public static List<Validation> GetValidations()
        {
            return new List<Validation>()
            {
                new Validation()
                {
                    Expression = (db,val) => (val.AmountApproved <= 0 && val.AmountApproved <= 0) || val.Status =="REPROVADO",
                    Status = "REPROVADO"
                },
                new Validation()
                {
                    Expression = (db,val) => db.Qtd == val.ItensApproved && db.Amount == val.AmountApproved && val.Status=="APROVADO",
                    Status = "APROVADO"
                },
                new Validation()
                {
                    Expression = (db,val) => db.Amount > val.AmountApproved  && val.Status=="APROVADO",
                    Status = "APROVADO_VALOR_A_MENOR"
                },
                new Validation()
                {
                    Expression = (db,val) => db.Qtd > val.ItensApproved   && val.Status=="APROVADO",
                    Status = "APROVADO_QTD_A_MENOR"
                },
                new Validation()
                {
                    Expression = (db,val) => db.Amount < val.AmountApproved   && val.Status=="APROVADO",
                    Status = "APROVADO_VALOR_A_MAIOR"
                },
                 new Validation()
                {
                    Expression = (db,val) => db.Qtd < val.ItensApproved  && val.Status=="APROVADO",
                    Status = "APROVADO_QTD_A_MAIOR"
                },
            };
        }
    }
}
