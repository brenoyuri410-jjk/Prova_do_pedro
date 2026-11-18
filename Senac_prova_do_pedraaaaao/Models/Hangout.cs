namespace Senac_prova_do_pedraaaaao.Models
{
    public class Hangout
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateOnly Date { get; set; }

        public string Time { get; set; } = string.Empty;

        public decimal MoneyNeeded { get; set; }
    }
}
