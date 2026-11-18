using System.Globalization;
using Senac_prova_do_pedraaaaao.Models;

namespace Senac_prova_do_pedraaaaao.Services
{
    public class HangoutService
    {
        private readonly List<Hangout> _hangouts = [];

        public List<Hangout> GetAll()
        {
            return _hangouts;
        }

        public bool TryAdd(
            Hangout hangout,
            out Hangout createdHangout,
            out string errorMessage,
            out bool isConflict)
        {
            createdHangout = hangout;
            errorMessage = string.Empty;
            isConflict = false;

            if (string.IsNullOrWhiteSpace(hangout.Title))
            {
                errorMessage = "O título é obrigatório.";
                return false;
            }

            if (hangout.Date < DateOnly.FromDateTime(DateTime.Today))
            {
                errorMessage = "A data não pode estar no passado.";
                return false;
            }

            if (!TimeOnly.TryParseExact(
                    hangout.Time,
                    "HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out _))
            {
                errorMessage = "O horário deve estar no formato HH:mm.";
                return false;
            }

            if (hangout.MoneyNeeded < 0)
            {
                errorMessage = "O dinheiro necessário não pode ser negativo.";
                return false;
            }

            if (_hangouts.Any(existing => existing.Date == hangout.Date && existing.Time == hangout.Time))
            {
                errorMessage = "Já existe um rolê nesse dia e horário.";
                isConflict = true;
                return false;
            }

            hangout.Id = Guid.NewGuid();
            _hangouts.Add(hangout);
            createdHangout = hangout;

            return true;
        }
    }
}
