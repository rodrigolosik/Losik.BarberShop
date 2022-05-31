using System.Collections.Generic;

namespace Losik.BarberShop.Domain.Dtos.Base
{
    public abstract class ResponseBaseDto
    {
        public ResponseBaseDto()
        {
            Errors = new List<string>();
            Success = true;
        }

        public bool Success { get; set; }
        public IList<string> Errors { get; private set; }

        public void AddError(string message)
        {
            Errors.Add(message);
            Success = false;
        }
    }
}
