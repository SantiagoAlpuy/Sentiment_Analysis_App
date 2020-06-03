using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IAlert
    {
        bool Activated { get; set; }
        void ValidateAlert();
        void EvaluateAlert(List<Phrase> phrases);
    }
}
